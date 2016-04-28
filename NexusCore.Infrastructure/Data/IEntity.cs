using System;

namespace NexusCore.Infrastructure.Data
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
