using System.Data.Common;

namespace NexusCore.Infrastructure.Data
{
    public abstract class StoredProcedureParsable
    {
       public abstract void  DbReaderParser(DbDataReader reader);
    }
}
