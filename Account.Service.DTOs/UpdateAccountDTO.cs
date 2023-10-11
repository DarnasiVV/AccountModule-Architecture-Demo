using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Service.DTOs
{
    public class UpdateAccountDTO
    {
        public Guid Id { get; set; }
        public string Address { get; set; } = string.Empty;
        public int PhoneNumber { get; set; }
    }
}
