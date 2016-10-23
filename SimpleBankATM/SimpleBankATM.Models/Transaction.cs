using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleBankATM.Models
{
    public class Transaction : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }

        public int AccountId { get; set; }

        public int TransactionTypeId { get; set; }

        public decimal TransactionAmount { get; set; }

        public virtual LU_TransactionType TransactionType { get; set; }
    }
}