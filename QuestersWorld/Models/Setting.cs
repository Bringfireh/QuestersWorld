namespace QuestersWorld.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Setting")]
    public partial class Setting
    {
        public string ID { get; set; }
        [Display(Name = "Percentage Interest")]
        public int? PercentageInterest { get; set; }
        [Display(Name = "Release Days")]
        public int? ReleaseDays { get; set; }
        [Display(Name = "Payment Days")]
        public int? PaymentDays { get; set; }
        [Display(Name = "User Limit")]
        public int? UserLimit { get; set; }
    }
}
