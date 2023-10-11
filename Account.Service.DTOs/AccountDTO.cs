using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Service.DTOs
{
    public class AccountDTO
    {
        public string AccountholderName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int PhoneNumber { get; set; }
        public List<Proofs> Proofslist  { get; set; }
    }
    public class Proofs
    {
        public string ProofType { get; set; }
        public string ProofValue { get; set; }
    }
}
