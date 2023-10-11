using Account.Service;
using Account.Service.DTOs;
using Account.Service.Entities.Domain;

namespace AccountModule_Architectur_Demo.Handlers
{
    public class AccountHandler 
    {
        private IAccountService _accountservice;
        private IBaseService _baseSevice;
        public AccountHandler(IAccountService accountservice, IBaseService baseSevice)
        {
            _accountservice = accountservice;
            _baseSevice = baseSevice;
        }
        public void Handle(AccountDTO accountvm)
        {
            CreateAccount account = new CreateAccount();
            account.AccountholderName = accountvm.AccountholderName;
            account.PhoneNumber = accountvm.PhoneNumber;

            account.Proofslist = accountvm.Proofslist.Select(dto => new Account.Service.Entities.Domain.Proof
            {
                ProofType = dto.ProofType,
                ProofValue = dto.ProofValue
            }).ToList();

            account.Address = accountvm.Address;
            _accountservice.CreateAccount(account);
        }
    }
}
