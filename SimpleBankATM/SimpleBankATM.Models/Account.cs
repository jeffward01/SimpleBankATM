using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public decimal Balance { get; set; }

        public int TransactionCount { get; set; }

        public virtual IList<Transaction> Transactions { get; set; }
    }
}
