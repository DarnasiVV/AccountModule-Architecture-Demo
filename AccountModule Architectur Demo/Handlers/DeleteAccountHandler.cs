using Account.Service.DTOs;
using Account.Service.Entities.Domain;
using Account.Service;
using Account.Service.Entities.Projections;

namespace AccountModule_Architectur_Demo.Handlers
{
    public class DeleteAccountHandler
    {
        private IAccountService _AccountService;
        public DeleteAccountHandler(IAccountService AccountService)
        {
            _AccountService = AccountService;
        }
        public void Handle(DeleteAccountDTO delete)
        {
            DeleteAccount deletedetails = new DeleteAccount();
            deletedetails.Id = delete.Id;
            _AccountService.DeleteAccount(deletedetails);
        }
    }
}
