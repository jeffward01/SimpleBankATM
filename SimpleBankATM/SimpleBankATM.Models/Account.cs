﻿using System;
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

        public int UserId { get; set; }

        public int AccountNumber { get; set; }

        public int RoutingNumber { get; set; }

        public decimal Balance { get; set; }

        public int TransactionCount { get; set; }

        public virtual IList<Transaction> Transactions { get; set; }
    }
}