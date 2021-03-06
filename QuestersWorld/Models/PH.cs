namespace QuestersWorld.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PH")]
    public partial class PH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PH()
        {
            Matcheds = new HashSet<Matched>();
            MatchedTemps = new HashSet<MatchedTemp>();
        }

        public string ID { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }
        [Display(Name = "Amount")]
        public decimal? Amount { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Date Created")]
        public DateTime? DateCreated { get; set; }

        [StringLength(128)]
        public string Status { get; set; }

        public virtual ApplicationUser AspNetUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Matched> Matcheds { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MatchedTemp> MatchedTemps { get; set; }
    }
}
