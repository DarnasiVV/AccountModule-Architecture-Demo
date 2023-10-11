using Account.Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Service
{
    public class BaseService : IBaseService
    {
        private IBaseRepository _repository;
        public BaseService(IBaseRepository repository)
        {
            _repository = repository;
        }

        public void SaveChanges()
        {
            _repository.SaveChanges();
            
        }
    }
}
