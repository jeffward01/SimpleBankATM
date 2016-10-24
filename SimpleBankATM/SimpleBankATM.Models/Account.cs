using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBankATM.Models.LookupModels;

namespace SimpleBankATM.Models
{
    public class Account : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountId { get; set; }

        public int CustomerId { get; set; }

        public string AccountNumber { get; set; }

        public string RoutingNumber { get; set; }

        public int AccountTypeId { get; set; }

        public int Balance { get; set; }

        public int TransactionCount { get; set; }

        public virtual LU_AccountType AccountType { get; set; }

        public virtual IList<Transaction> Transactions { get; set; }
    }
}
