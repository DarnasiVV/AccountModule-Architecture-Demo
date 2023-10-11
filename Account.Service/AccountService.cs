using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Account.Service.DTOs;
using Account.Service.Entities.Domain;
using Account.Service.Entities.Projections;
using Account.Service.Repositories;

namespace Account.Service
{
    public class AccountService : IAccountService
    {
        public IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public void CreateAccount(CreateAccount account,bool iscommit)
        {
            _accountRepository.CreateAccount(account, iscommit);
        }
        public void UpdateAccount(UpdateAccount updateaccount)
        {
            _accountRepository.UpdateAccount(updateaccount);
        }
        public async  Task<AccountHolderDetails> GetAccount(Guid Id)
        {
           return await _accountRepository.GetAccount(Id);
        }
        public void CreateAccountHolderIdentityProofs(AccountHolderIdentityProofs accountHolderIdentityProofs)
        {
             _accountRepository.CreateAccountHolderIdentityProofs(accountHolderIdentityProofs);
        }
       public async Task<List<AccountHolderDetails>> GetAccountList(GetAccountList getAccountList)
        {
            return await _accountRepository.GetAccountList(getAccountList);
        }

        public void DeleteAccount(DeleteAccount delete)
        {
            _accountRepository.DeleteAccount(delete); 
        }
        
    }
}
