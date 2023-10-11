using Account.DataAccess;
using Account.Service.DTOs;
using Account.Service.Entities.Domain;
using Account.Service.Entities.Projections;
using Marten;
using Marten.Internal.Sessions;
using Marten.Linq.SoftDeletes;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Account.Service.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IDataStore _dataStore;
        public AccountRepository(IDataStore dataStore)
        {
            _dataStore = dataStore;
        }
        public async Task CreateAccount(CreateAccount account, bool iscommit)
        {
            //List<Proofs> proofsList1  = new List<Proofs>();
            //Proofs proof1 = new Proofs
            //{
            //    ProofType = "Type1",
            //    ProofValue = "Value1"
            //};
            //proofsList1 .Add(proof1);



            //List<DTOs.Proofs> dto = new List<DTOs.Proofs>();
            //List<Entities.Domain.Proofs> targetList = dto
            //.Select(dto => new Entities.Domain.Proofs
            //{
            //    ProofType = dto.ProofType,
            //    ProofValue = dto.ProofValue
            //})
            //.ToList();


            var Id = Guid.NewGuid();
            _dataStore.Session.Events.StartStream<CreateAccount>(Id,
                new AccountCreated(Id, account.AccountholderName, account.Address, account.PhoneNumber,account.Proofslist));






            if (iscommit)
                    _dataStore.CommitChanges();
            
            
        }
        public async Task UpdateAccount (UpdateAccount updateAccount)
        {
            if (updateAccount.Id != Guid.Empty)
            {
                _dataStore.Session.Events.Append(updateAccount.Id, new AccountUpdated(updateAccount.Id, updateAccount.PhoneNumber, updateAccount.Address));
                _dataStore.CommitChanges();
            }
        }
        public async Task<AccountHolderDetails> GetAccount(Guid Id)
        {
            var projectionsdata = await _dataStore.Session.LoadAsync<AccountHolderDetails>(Id);
            return projectionsdata;
        }

        public async Task CreateAccountHolderIdentityProofs(AccountHolderIdentityProofs accountHolderIdentityProofs)
        {
            var ID = Guid.NewGuid();
            _dataStore.Session.Events.StartStream<AccountHolderIdentityProofs>(ID,new AccountHolderIdentityProofscreated(
             accountHolderIdentityProofs.ProofType,accountHolderIdentityProofs.ProofValue,accountHolderIdentityProofs.AccountId));
            _dataStore.CommitChanges();
        }
        public async Task<List<AccountHolderDetails>> GetAccountList(GetAccountList getAccountList)
        {
            var projectionsdata = _dataStore.Session.Query<AccountHolderDetails>().ToList();
            return projectionsdata;
            
        }
        public async Task DeleteAccount(DeleteAccount delete)
        {
            _dataStore.Session.Events.Append(delete.Id,new AccountDeleted(delete.Id,true));
            _dataStore.CommitChanges();
        }
    }
}
