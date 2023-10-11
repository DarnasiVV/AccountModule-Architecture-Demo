
using Marten;
using Marten.Internal.Sessions;

namespace Account.DataAccess
{
    public interface IDataStore 
    {
        IDocumentSession Session { get; }
        Task CommitChanges();
        IQuerySession querySession { get; }
    }
}
