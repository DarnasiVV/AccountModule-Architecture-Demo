using Account.Service;
using Account.Service.Entities.Domain;
using Account.Service.Entities.Projections;

namespace AccountModule_Architectur_Demo.Handlers
{
    public class GetAccountListHandler
    {
        private readonly IAccountService _IaccountService;
        public GetAccountListHandler(IAccountService accountService)
        {
            _IaccountService = accountService;
        }
        public Task<List<AccountHolderDetails>> Handle(GetAccountList getAccountList)
        {
            return _IaccountService.GetAccountList(getAccountList);
        }
    }
}
