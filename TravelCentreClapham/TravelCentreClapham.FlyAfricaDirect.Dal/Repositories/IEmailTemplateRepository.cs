using System;
using TravelCentreClapham.FlyAfricaDirect.Dal.Entities;

namespace TravelCentreClapham.FlyAfricaDirect.Dal.Repositories
{
    public interface IEmailTemplateRepository
    {
        EmailTemplate GetEmailTemplate(Guid id);
    }
}
