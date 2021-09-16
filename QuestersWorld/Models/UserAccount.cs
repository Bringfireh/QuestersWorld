namespace QuestersWorld.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserAccount")]
    public partial class UserAccount
    {
        [Key]
        public string UserId { get; set; }

        [StringLength(128)]
        [Display(Name = "Account Name")]
        public string AccountName { get; set; }

        [StringLength(128)]
        [Display(Name = "Account Number")]
        public string AccountNumber { get; set; }

        [StringLength(128)]
        [Display(Name = "Account Type")]
        public string AccountType { get; set; }

        [StringLength(128)]
        [Display(Name = "Bank Name")]
        public string BankName { get; set; }

        public virtual ApplicationUser AspNetUser { get; set; }
    }
}
