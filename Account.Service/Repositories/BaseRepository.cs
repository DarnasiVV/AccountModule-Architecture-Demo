using Account.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Service.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        public readonly IDataStore _dataStore;
        public BaseRepository(IDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public async Task SaveChanges()
        {
            await _dataStore.CommitChanges();
        }
    }
}

