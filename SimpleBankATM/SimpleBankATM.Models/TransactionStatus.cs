using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankATM.Models
{
    public class TransactionStatus
    {
        public bool IsValid { get; set; }
        public string WarningMessage { get; set; }
    }
}
