namespace QuestersWorld.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MatchedTemp")]
    public partial class MatchedTemp
    {
        public string ID { get; set; }

        [StringLength(128)]
        public string GHID { get; set; }

        [StringLength(128)]
        public string PHID { get; set; }
        [Display(Name = "GH Amount")]
        public decimal? GHAmount { get; set; }
        [Display(Name = "PH Amount")]
        public decimal? PHAmount { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Date Created")]
        public DateTime? DateCreated { get; set; }
        [Display(Name = "Time Created")]
        public TimeSpan? TimeCreated { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Expected Payment Date")]
        public DateTime? ExpectedPaymentDate { get; set; }
        [Display(Name = "Expected Payment Time")]
        public TimeSpan? ExpectedPaymentTime { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Payment Date")]
        public DateTime? PaymentDate { get; set; }
        [Display(Name = "Payment Time")]
        public TimeSpan? PaymentTime { get; set; }

        [StringLength(128)]
        [Display(Name = "Image Link")]
        public string ImageLink { get; set; }

        [StringLength(128)]
        [Display(Name = "Status")]
        public string Status { get; set; }

        public virtual GH GH { get; set; }

        public virtual PH PH { get; set; }
    }
}
