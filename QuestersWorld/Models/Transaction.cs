namespace QuestersWorld.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Transaction")]
    public partial class Transaction
    {
        public string ID { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Date Created")]
        public DateTime? DateCreated { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Date of Release")]
        public DateTime? DateOfRelease { get; set; }
        [Display(Name = "PH Amount")]
        public decimal? PHAmount { get; set; }
        [Display(Name = "GH Amount")]
        public decimal? GHAmount { get; set; }

        [StringLength(128)]
        [Display(Name = "Type")]
        public string Type { get; set; }

        [StringLength(128)]
        [Display(Name = "Status")]
        public string Status { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}
