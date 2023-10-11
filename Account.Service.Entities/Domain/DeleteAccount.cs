using Marten.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Service.Entities.Domain
{
    public record AccountDeleted(Guid Id,bool isdelete);
    public class DeleteAccount
    {
        public Guid Id { get; set; }
        public bool isdelete { get; set; }
    }
}
