using System;

namespace NexusCore.Infrastructure.Data
{
    public interface ILogable
    {
        DateTime CreatedDate { get; set; }
        Guid CreatedBy { get; set; }
    }
}
