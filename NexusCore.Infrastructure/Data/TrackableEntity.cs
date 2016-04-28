using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexusCore.Infrastructure.Data
{
    public class TrackableEntity : LogableEntity , ITrackable
    {
        public DateTime UpdatedDate { get; set; }
        public Guid UpdatedBy { get; set; }
        [NotMapped]
        public Guid PresetUpdatedBy { get; set; }
    }
}
