using System.Collections.Generic;

namespace NexusCore.Infrastructure.Data
{
    public interface IStoredProcedure
    {
        string StoredProcedureName { get; }
        IEnumerable<StoredProcedureParameter> GetParameters();
    }
}
