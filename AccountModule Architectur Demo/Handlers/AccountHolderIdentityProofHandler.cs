using Account.Service.DTOs;
using Account.Service.Entities.Domain;
using Account.Service;

namespace AccountModule_Architectur_Demo.Handlers
{
    public class AccountHolderIdentityProofHandler
    {
        private IAccountService _accountservice;
        private IBaseService _baseSevice;
        public AccountHolderIdentityProofHandler(IAccountService accountservice, IBaseService baseSevice)
        {
            _accountservice = accountservice;
            _baseSevice = baseSevice;
        }
        public void Handle(AccountHolderIdentityProofDTO accountHolderIdentityProofDTO)
        {
            AccountHolderIdentityProofs AccountHolderProof = new AccountHolderIdentityProofs();
            AccountHolderProof.AccountId = accountHolderIdentityProofDTO.AccountId;
            AccountHolderProof.ProofType = accountHolderIdentityProofDTO.ProofType;
            AccountHolderProof.ProofValue = accountHolderIdentityProofDTO.ProofValue;
            _accountservice.CreateAccountHolderIdentityProofs(AccountHolderProof);
        }
    }
}
