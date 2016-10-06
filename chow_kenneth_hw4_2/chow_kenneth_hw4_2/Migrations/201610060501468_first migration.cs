namespace chow_kenneth_hw4_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Committees",
                c => new
                    {
                        CommitteeID = c.Int(nullable: false, identity: true),
                        CommitteeName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CommitteeID);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        EventDate = c.DateTime(nullable: false),
                        Location = c.String(nullable: false),
                        MembersOnly = c.Boolean(nullable: false),
                        SponsoringCommittee_CommitteeID = c.Int(),
                    })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.Committees", t => t.SponsoringCommittee_CommitteeID)
                .Index(t => t.SponsoringCommittee_CommitteeID);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        int_MemberID = c.Int(nullable: false, identity: true),
                        str_FName = c.String(nullable: false),
                        str_LName = c.String(nullable: false),
                        str_Email = c.String(nullable: false),
                        str_Phone = c.String(nullable: false),
                        bool_OKToText = c.Boolean(nullable: false),
                        Major = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.int_MemberID);
            
            CreateTable(
                "dbo.MemberEvents",
                c => new
                    {
                        Member_int_MemberID = c.Int(nullable: false),
                        Event_EventID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Member_int_MemberID, t.Event_EventID })
                .ForeignKey("dbo.Members", t => t.Member_int_MemberID, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.Event_EventID, cascadeDelete: true)
                .Index(t => t.Member_int_MemberID)
                .Index(t => t.Event_EventID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "SponsoringCommittee_CommitteeID", "dbo.Committees");
            DropForeignKey("dbo.MemberEvents", "Event_EventID", "dbo.Events");
            DropForeignKey("dbo.MemberEvents", "Member_int_MemberID", "dbo.Members");
            DropIndex("dbo.MemberEvents", new[] { "Event_EventID" });
            DropIndex("dbo.MemberEvents", new[] { "Member_int_MemberID" });
            DropIndex("dbo.Events", new[] { "SponsoringCommittee_CommitteeID" });
            DropTable("dbo.MemberEvents");
            DropTable("dbo.Members");
            DropTable("dbo.Events");
            DropTable("dbo.Committees");
        }
    }
}
