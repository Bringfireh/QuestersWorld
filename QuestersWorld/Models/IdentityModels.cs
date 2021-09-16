using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace QuestersWorld.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "Active Status")]
        public string ActiveStatus { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GH> GHs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PH> PHs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaction> Transactions { get; set; }

        public virtual UserAccount UserAccount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserSupport> UserSupports { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //public virtual DbSet<ApplicationUser> AspNetUsers { get; set; }
        public virtual DbSet<GH> GHs { get; set; }
        public virtual DbSet<Matched> Matcheds { get; set; }
        public virtual DbSet<MatchedTemp> MatchedTemps { get; set; }
        public virtual DbSet<PH> PHs { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }
        public virtual DbSet<UserSupport> UserSupports { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.GHs)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.PHs)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.Transactions)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ApplicationUser>()
                .HasOptional(e => e.UserAccount)
                .WithRequired(e => e.AspNetUser)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.UserSupports)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete();

            modelBuilder.Entity<GH>()
                .Property(e => e.Amount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<GH>()
                .HasMany(e => e.Matcheds)
                .WithOptional(e => e.GH)
                .WillCascadeOnDelete();

            modelBuilder.Entity<GH>()
                .HasMany(e => e.MatchedTemps)
                .WithOptional(e => e.GH)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Matched>()
                .Property(e => e.GHAmount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Matched>()
                .Property(e => e.PHAmount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MatchedTemp>()
                .Property(e => e.GHAmount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MatchedTemp>()
                .Property(e => e.PHAmount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PH>()
                .Property(e => e.Amount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.PHAmount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.GHAmount)
                .HasPrecision(18, 0);
        }
    }

    //public partial class QWModel : DbContext
    //{
    //    public QWModel()
    //        : base("name=QWModel")
    //    {
    //    }

    
    //}

}