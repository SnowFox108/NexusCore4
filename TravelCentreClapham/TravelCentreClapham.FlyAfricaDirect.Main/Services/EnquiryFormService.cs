using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using NexusCore.Infrastructure.Mappers;
using TravelCentreClapham.FlyAfricaDirect.Dal.Entities;
using TravelCentreClapham.FlyAfricaDirect.Dal.Models;
using TravelCentreClapham.FlyAfricaDirect.Dal.Repositories;
using System.Transactions;
using TravelCentreClapham.FlyAfricaDirect.Dal;
using NexusCore.Infrastructure.Messager;

namespace TravelCentreClapham.FlyAfricaDirect.Main.Services
{
    public class EnquiryFormService : IEnquiryFormService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailTemplateRepository _emailTemplateRepository;
        private readonly IEmailSender _emailSender;

        public EnquiryFormService(
            ICustomerRepository customerRepository, 
            IEmailTemplateRepository emailTemplateRepository, 
            IEmailSender emailSender)
        {
            _customerRepository = customerRepository;
            _emailTemplateRepository = emailTemplateRepository;
            _emailSender = emailSender;
        }

        public void Add(EnquiryForm01Dto customer)
        {
            using (var transaction = new TransactionScope())
            {
                customer.Email = customer.Email.ToLower().Trim();
                if (CheckEmailExist(customer.Email, customer.PromotionGroupType))
                {
                    _customerRepository.Insert(customer.MapTo<Customer>());
                    // send out email
                    var emailTemplate =
                        _emailTemplateRepository.GetEmailTemplate(new Guid("BFFF3CBF-D9F5-4699-A593-16DDD016E158"));
                    transaction.Complete();

                    _emailSender.SendEmail(
                        emailTemplate.Subject,
                        emailTemplate.BodyTemplate,
                        emailTemplate.IsBodyHtml,
                        MailPriority.Normal,
                        Encoding.UTF8,
                        emailTemplate.From,
                        customer.Email,
                        emailTemplate.ReplyTo,
                        emailTemplate.Bcc,
                        GetTokenValues(customer)
                        );
                }
            }
        }

        private IDictionary<string, string> GetTokenValues(EnquiryForm01Dto customer)
        {
            var tokens = new Dictionary<string, string>();

            tokens.Add("FirstName", customer.FirstName);
            tokens.Add("LastName", customer.LastName);

            return tokens;
        } 

        public bool CheckEmailExist(string email, PromotionGroupType promotionGroupType)
        {
            var result = _customerRepository.GetCustomerByEmail(email, promotionGroupType);
            return (result == null);
        }

        public void OptEmailOut(string email, PromotionGroupType promotionGroupType)
        {
            using (var transaction = new TransactionScope())
            {
                _customerRepository.UpdateCustomerOptStatus(email, promotionGroupType, false);
                transaction.Complete();
            }
        }
    }
}
