using Account.Service.Entities.Domain;
using Marten.Events.Aggregation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Service.Entities.Projections
{
    public class AccountReview
    {
        public Guid Id { get; set; }
        public string AccountHolderName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int PhoneNumber { get; set; }
        public int AccountHolderIdentityProof { get; set; }
    }

    public class AccountProjection : SingleStreamProjection<AccountReview>
    {
        public AccountReview Create(AccountCreated accountCreated)
        {

            var result = new AccountReview();
            result.Id = accountCreated.Id;
            result.AccountHolderName = accountCreated.AccountHolderName;
            return result;
        }
        public void Apply(AccountUpdated accountUpdated, AccountReview accountReview)
        {
            accountReview.PhoneNumber = accountUpdated.PhoneNumber;
            accountReview.Address = accountUpdated.Address;
        }
    }
  

}
