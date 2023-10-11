using Account.Service;
using Account.Service.DTOs;
using Account.Service.Entities.Domain;

namespace AccountModule_Architectur_Demo.Handlers
{
    public class UpdateAccountHandler
    {
        private IAccountService _accountservice;
        private IBaseService _baseSevice;
        public UpdateAccountHandler(IAccountService accountservice, IBaseService baseSevice)
        {
            _accountservice = accountservice;
            _baseSevice = baseSevice;
        }
        public void Handle(UpdateAccountDTO accountvm)
        {
            UpdateAccount updateAccount = new UpdateAccount();
            updateAccount.Id = accountvm.Id;
            updateAccount.PhoneNumber = accountvm.PhoneNumber;
            updateAccount.Address = accountvm.Address;
            _accountservice.UpdateAccount(updateAccount);
        }
    }
}
