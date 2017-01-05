using System;
using System.Linq;
using NexusCore.Infrastructure.Data.EntityFramework;
using TravelCentreClapham.FlyAfricaDirect.Dal.Entities;

namespace TravelCentreClapham.FlyAfricaDirect.Dal.Repositories
{
    public class EmailTemplateRepository : Repository<EmailTemplate>, IEmailTemplateRepository
    {
        public EmailTemplateRepository(IContentContext contentContext) : base(contentContext)
        {
        }

        public EmailTemplate GetEmailTemplate(Guid id)
        {
            return Get(c => c.Id == id).FirstOrDefault();
        }
    }
}
