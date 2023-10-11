using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Account.Service.DTOs;
using Account.Service.Entities.Domain;
using Account.Service.Entities.Projections;

namespace Account.Service
{
    public interface IAccountService
    {
        void CreateAccount(CreateAccount account,bool iscommit = true);
        void UpdateAccount(UpdateAccount updateAccount);
        Task<AccountHolderDetails> GetAccount(Guid Id);
        void CreateAccountHolderIdentityProofs(AccountHolderIdentityProofs accountHolderIdentityProofs);
        Task<List<AccountHolderDetails>> GetAccountList(GetAccountList getAccountList);
        void DeleteAccount(DeleteAccount delete);
    }
}
