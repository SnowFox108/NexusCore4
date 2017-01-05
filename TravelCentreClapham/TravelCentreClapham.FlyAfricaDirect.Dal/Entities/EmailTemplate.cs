using NexusCore.Infrastructure.Data;

namespace TravelCentreClapham.FlyAfricaDirect.Dal.Entities
{
    public class EmailTemplate : LogableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string BodyTemplate { get; set; }
        public string Subject { get; set; }
        public bool IsBodyHtml { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Cc { get; set; }
        public string Bcc { get; set; }
        public string ReplyTo { get; set; }
        public int Priority { get; set; }
    }
}
