using Account.Service.Entities.Domain;
using Account.Service.Entities.Projections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Service.Repositories
{
    public interface IAccountRepository
    {
        Task CreateAccount(CreateAccount accountvm,bool iscommit = true);
        Task UpdateAccount(UpdateAccount updateAccount);
        Task<AccountHolderDetails> GetAccount(Guid Id);
        Task CreateAccountHolderIdentityProofs(AccountHolderIdentityProofs accountHolderIdentityProofs);
        Task<List<AccountHolderDetails>> GetAccountList(GetAccountList getAccountList);
        Task DeleteAccount(DeleteAccount delete);
    }
}
