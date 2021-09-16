namespace QuestersWorld.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QWModel : DbContext
    {
        public QWModel()
            : base("name=QWModel")
        {
        }

        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
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
            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.GHs)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete();

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.PHs)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete();

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Transactions)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete();

            modelBuilder.Entity<AspNetUser>()
                .HasOptional(e => e.UserAccount)
                .WithRequired(e => e.AspNetUser)
                .WillCascadeOnDelete();

            modelBuilder.Entity<AspNetUser>()
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
}
