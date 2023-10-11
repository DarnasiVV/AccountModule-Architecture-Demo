using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Service.DTOs
{
    public class AccountHolderIdentityProofDTO
    {
        public Guid AccountId { get; set; }
        public string ProofType  { get; set; }
        public string ProofValue { get; set; }
    }
}
