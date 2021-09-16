namespace QuestersWorld.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserSupport")]
    public partial class UserSupport
    {
        public string ID { get; set; }

        [StringLength(128)]
        
        public string UserId { get; set; }
        [Display(Name = "Complaint")]
        public string Complaint { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Date Created")]
        public DateTime? DateCreated { get; set; }

        [StringLength(128)]
        [Display(Name = "Status")]
        public string Status { get; set; }
        [Display(Name = "Remarks")]
        public string Remarks { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Date Answered")]
        public DateTime? DateTreated { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}
