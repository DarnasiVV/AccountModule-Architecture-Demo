using Account.Service;
using Account.Service.DTOs;
using Account.Service.Entities.Domain;
using Account.Service.Entities.Projections;

namespace AccountModule_Architectur_Demo.Handlers
{
    public class GetAccountHandler
    {
        private IAccountService _AccountService; 
        public GetAccountHandler(IAccountService AccountService)
        {
            _AccountService = AccountService;
        }
        public async Task<AccountHolderDetails> Handle(Guid Id) 
        {
            return  await _AccountService.GetAccount(Id);
        }
    }
}
