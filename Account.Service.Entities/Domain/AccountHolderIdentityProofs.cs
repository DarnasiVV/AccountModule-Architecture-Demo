using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Service.Entities.Domain
{
    public record AccountHolderIdentityProofscreated(//Guid Id,
                                                     string ProofType, string ProofValue 
    //  Dictionary<string,string> Proofs,
       , Guid AccountId
        );
    public class AccountHolderIdentityProofs
    {
        // public Guid Id { get; set; }
        //   public  Dictionary<string,string>   Proofs { get; set; }

        public Guid AccountId { get; set; }
        public string ProofType { get; set; }
        public string ProofValue { get; set; }
    }
}
