using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleBankATM.Models
{
    public class Customer : BaseEntity
    {
       // [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => FirstName + " " + LastName;

        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public int SocialSecurityNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public virtual IList<Account> Accounts { get; set; }
    }
}