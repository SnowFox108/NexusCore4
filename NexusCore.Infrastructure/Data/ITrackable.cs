using System;

namespace NexusCore.Infrastructure.Data
{
    public interface ITrackable : ILogable
    {
        DateTime UpdatedDate { get; set; }
        Guid UpdatedBy { get; set; }
        Guid PresetUpdatedBy { get; set; }
    }
}