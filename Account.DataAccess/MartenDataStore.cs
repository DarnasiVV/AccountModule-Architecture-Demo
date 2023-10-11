using Marten;
using Marten.Internal.Sessions;
using Marten.Services;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;


namespace Account.DataAccess
{
    public class MartenDataStore : IDataStore 
    {

        private readonly IDocumentSession _session;
        private readonly IQuerySession _querrySession; 
        public IDocumentSession Session { get { return _session; } }

        public IQuerySession querySession { get { return _querrySession; } }

        public MartenDataStore(IDocumentStore documentStore, IQuerySession querrySession)
        {
            _session = documentStore.LightweightSession();
        }
        public async Task CommitChanges()
        {
            await _session.SaveChangesAsync();
        }

        //objects are disposed if we use this
        //public void Dispose()
        //{
        //    Dispose(true);
        //}

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (disposing) _session.Dispose();
        //}
    }
}
