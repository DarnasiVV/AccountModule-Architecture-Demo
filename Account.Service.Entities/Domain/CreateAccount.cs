using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Service.Entities.Domain
{
    public record AccountCreated(Guid Id, string AccountHolderName, string Address, int PhoneNumber
       , List<Proof> Proofslist
        );
    // public record AccountCreated(CreateAccount CreateAccount);
    public class CreateAccount
    {
        public string AccountholderName { get; set; } = string.Empty;
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public List<Proof> Proofslist { get; set; }
    }
    public class Proof 
    {
        public string ProofType { get; set; }
        public string ProofValue { get; set; }
    }
}
