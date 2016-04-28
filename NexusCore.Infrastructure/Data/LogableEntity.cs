using System;

namespace NexusCore.Infrastructure.Data
{
    public class LogableEntity : Entity, ILogable
    {
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
