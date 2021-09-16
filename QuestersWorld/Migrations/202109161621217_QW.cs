namespace QuestersWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QW : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(),
                        Address = c.String(),
                        Country = c.String(),
                        ActiveStatus = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GH",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(maxLength: 128),
                        Amount = c.Decimal(precision: 18, scale: 0),
                        DateCreated = c.DateTime(storeType: "date"),
                        Status = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Matched",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        GHID = c.String(maxLength: 128),
                        PHID = c.String(maxLength: 128),
                        GHAmount = c.Decimal(precision: 18, scale: 0),
                        PHAmount = c.Decimal(precision: 18, scale: 0),
                        DateCreated = c.DateTime(storeType: "date"),
                        TimeCreated = c.Time(precision: 7),
                        ExpectedPaymentDate = c.DateTime(storeType: "date"),
                        ExpectedPaymentTime = c.Time(precision: 7),
                        PaymentDate = c.DateTime(storeType: "date"),
                        PaymentTime = c.Time(precision: 7),
                        ImageLink = c.String(maxLength: 128),
                        Status = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PH", t => t.PHID)
                .ForeignKey("dbo.GH", t => t.GHID, cascadeDelete: true)
                .Index(t => t.GHID)
                .Index(t => t.PHID);
            
            CreateTable(
                "dbo.PH",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(maxLength: 128),
                        Amount = c.Decimal(precision: 18, scale: 0),
                        DateCreated = c.DateTime(storeType: "date"),
                        Status = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.MatchedTemp",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        GHID = c.String(maxLength: 128),
                        PHID = c.String(maxLength: 128),
                        GHAmount = c.Decimal(precision: 18, scale: 0),
                        PHAmount = c.Decimal(precision: 18, scale: 0),
                        DateCreated = c.DateTime(storeType: "date"),
                        TimeCreated = c.Time(precision: 7),
                        ExpectedPaymentDate = c.DateTime(storeType: "date"),
                        ExpectedPaymentTime = c.Time(precision: 7),
                        PaymentDate = c.DateTime(storeType: "date"),
                        PaymentTime = c.Time(precision: 7),
                        ImageLink = c.String(maxLength: 128),
                        Status = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PH", t => t.PHID)
                .ForeignKey("dbo.GH", t => t.GHID, cascadeDelete: true)
                .Index(t => t.GHID)
                .Index(t => t.PHID);
            
            CreateTable(
                "dbo.Transaction",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(maxLength: 128),
                        DateCreated = c.DateTime(storeType: "date"),
                        DateOfRelease = c.DateTime(storeType: "date"),
                        PHAmount = c.Decimal(precision: 18, scale: 0),
                        GHAmount = c.Decimal(precision: 18, scale: 0),
                        Type = c.String(maxLength: 128),
                        Status = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserAccount",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        AccountName = c.String(maxLength: 128),
                        AccountNumber = c.String(maxLength: 128),
                        AccountType = c.String(maxLength: 128),
                        BankName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserSupport",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(maxLength: 128),
                        Complaint = c.String(),
                        DateCreated = c.DateTime(storeType: "date"),
                        Status = c.String(maxLength: 128),
                        Remarks = c.String(),
                        DateTreated = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Setting",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        PercentageInterest = c.Int(),
                        ReleaseDays = c.Int(),
                        PaymentDays = c.Int(),
                        UserLimit = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUserLogins");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId });
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(),
                        Address = c.String(),
                        Country = c.String(),
                        ActiveStatus = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId });
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.UserSupport", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserAccount", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Transaction", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PH", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.GH", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.MatchedTemp", "GHID", "dbo.GH");
            DropForeignKey("dbo.Matched", "GHID", "dbo.GH");
            DropForeignKey("dbo.MatchedTemp", "PHID", "dbo.PH");
            DropForeignKey("dbo.Matched", "PHID", "dbo.PH");
            DropIndex("dbo.UserSupport", new[] { "UserId" });
            DropIndex("dbo.UserAccount", new[] { "UserId" });
            DropIndex("dbo.Transaction", new[] { "UserId" });
            DropIndex("dbo.MatchedTemp", new[] { "PHID" });
            DropIndex("dbo.MatchedTemp", new[] { "GHID" });
            DropIndex("dbo.PH", new[] { "UserId" });
            DropIndex("dbo.Matched", new[] { "PHID" });
            DropIndex("dbo.Matched", new[] { "GHID" });
            DropIndex("dbo.GH", new[] { "UserId" });
            DropTable("dbo.Setting");
            DropTable("dbo.UserSupport");
            DropTable("dbo.UserAccount");
            DropTable("dbo.Transaction");
            DropTable("dbo.MatchedTemp");
            DropTable("dbo.PH");
            DropTable("dbo.Matched");
            DropTable("dbo.GH");
            DropTable("dbo.AspNetUsers");
            CreateIndex("dbo.AspNetUserLogins", "UserId");
            CreateIndex("dbo.AspNetUserClaims", "UserId");
            CreateIndex("dbo.AspNetUsers", "UserName", unique: true, name: "UserNameIndex");
            CreateIndex("dbo.AspNetUserRoles", "RoleId");
            CreateIndex("dbo.AspNetUserRoles", "UserId");
            CreateIndex("dbo.AspNetRoles", "Name", unique: true, name: "RoleNameIndex");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
        }
    }
}
