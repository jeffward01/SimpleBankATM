using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankATM.Models
{
   public abstract class BaseEntity
    {
        public DateTime? CreatedDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public DateTime? Deleted { get; set; }
    }
}


