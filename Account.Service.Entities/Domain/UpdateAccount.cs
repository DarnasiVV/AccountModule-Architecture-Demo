using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Service.Entities.Domain
{
    public record AccountUpdated(Guid Id, int PhoneNumber, string Address);
    public class UpdateAccount
    {
        public Guid Id { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
