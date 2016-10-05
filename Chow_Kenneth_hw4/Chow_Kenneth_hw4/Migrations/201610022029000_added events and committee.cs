namespace Chow_Kenneth_hw4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedeventsandcommittee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        EventDate = c.DateTime(nullable: false),
                        Location = c.String(),
                        MembersOnly = c.Boolean(nullable: false),
                        SponsoringCommittee_CommitteeID = c.Int(),
                    })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.Committees", t => t.SponsoringCommittee_CommitteeID)
                .Index(t => t.SponsoringCommittee_CommitteeID);
            
            CreateTable(
                "dbo.Committees",
                c => new
                    {
                        CommitteeID = c.Int(nullable: false, identity: true),
                        CommitteeName = c.String(),
                    })
                .PrimaryKey(t => t.CommitteeID);
            
            CreateTable(
                "dbo.EventMembers",
                c => new
                    {
                        Event_EventID = c.Int(nullable: false),
                        Member_int_MemberID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Event_EventID, t.Member_int_MemberID })
                .ForeignKey("dbo.Events", t => t.Event_EventID, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.Member_int_MemberID, cascadeDelete: true)
                .Index(t => t.Event_EventID)
                .Index(t => t.Member_int_MemberID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "SponsoringCommittee_CommitteeID", "dbo.Committees");
            DropForeignKey("dbo.EventMembers", "Member_int_MemberID", "dbo.Members");
            DropForeignKey("dbo.EventMembers", "Event_EventID", "dbo.Events");
            DropIndex("dbo.EventMembers", new[] { "Member_int_MemberID" });
            DropIndex("dbo.EventMembers", new[] { "Event_EventID" });
            DropIndex("dbo.Events", new[] { "SponsoringCommittee_CommitteeID" });
            DropTable("dbo.EventMembers");
            DropTable("dbo.Committees");
            DropTable("dbo.Events");
        }
    }
}
