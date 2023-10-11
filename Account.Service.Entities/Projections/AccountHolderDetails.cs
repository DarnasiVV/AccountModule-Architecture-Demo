using Account.Service.Entities.Domain;
using JasperFx.Core;
using Marten.Events.Aggregation;
using Marten.Events.Projections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Account.Service.Entities.Projections
{
    public class AccountProofs
    {
        public string ProofType { get; set; }
        public string ProofValue { get; set; }
    }

    public class AccountHolderDetails
    {
        public Guid Id { get; set; }
        public string AccountHolderName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int PhoneNumber { get; set; }
        //  public Dictionary<string, string> Proofs {get; set;}
        public List<AccountProofs> Proofs { get; set; } = new List<AccountProofs>();
    }
    public class AccountHolderDetailsProjection : MultiStreamProjection<AccountHolderDetails,Guid>
    {
        public AccountHolderDetailsProjection()
        {
            DeleteEvent<AccountDeleted>();
            Identity<AccountCreated>(x=>x.Id);
            Identity<AccountUpdated>(x => x.Id);
            Identity<AccountHolderIdentityProofscreated>(x=>x.AccountId);
            Identity<AccountDeleted>(x=>x.Id);
        }
        public AccountHolderDetails Create(AccountCreated accountCreated)
        {
            AccountHolderDetails details = new AccountHolderDetails();
            details.Id = accountCreated.Id;
            details.Address = accountCreated.Address;
            details.AccountHolderName = accountCreated.AccountHolderName;
            details.PhoneNumber = accountCreated.PhoneNumber;
            details.Proofs = accountCreated.Proofslist.Select(x => new AccountProofs
            {
                ProofType = x.ProofType,
                ProofValue = x.ProofValue
            })
            .ToList(); ;
            return details;
        }
        public void Apply(AccountUpdated accountUpdated, AccountHolderDetails accountHolderDetails)
        {
            accountHolderDetails.PhoneNumber = accountUpdated.PhoneNumber;
            accountHolderDetails.Address = accountUpdated.Address;
        }
        public void Apply(AccountHolderIdentityProofscreated accountHolderIdentityProofscreated, AccountHolderDetails accountHolderDetails)
        {
          //  accountHolderDetails.Proofs = accountHolderDetails.Proofs == null ? new Dictionary<string, string>() : accountHolderDetails.Proofs;
            accountHolderDetails.Proofs = accountHolderDetails.Proofs == null ? new List<AccountProofs>() : accountHolderDetails.Proofs;
           //   accountHolderDetails.Proofs.Add(accountHolderIdentityProofscreated.ProofType,accountHolderIdentityProofscreated.ProofValue);
            var Proofs = new AccountProofs() { ProofType = accountHolderIdentityProofscreated.ProofType, ProofValue = accountHolderIdentityProofscreated.ProofValue };
            accountHolderDetails.Proofs.Add(Proofs);
        }
    }
}
