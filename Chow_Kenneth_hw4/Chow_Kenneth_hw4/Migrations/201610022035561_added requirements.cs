namespace Chow_Kenneth_hw4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedrequirements : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.EventMembers", newName: "MemberEvents");
            DropPrimaryKey("dbo.MemberEvents");
            AlterColumn("dbo.Events", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "Location", c => c.String(nullable: false));
            AlterColumn("dbo.Committees", "CommitteeName", c => c.String(nullable: false));
            AddPrimaryKey("dbo.MemberEvents", new[] { "Member_int_MemberID", "Event_EventID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.MemberEvents");
            AlterColumn("dbo.Committees", "CommitteeName", c => c.String());
            AlterColumn("dbo.Events", "Location", c => c.String());
            AlterColumn("dbo.Events", "Title", c => c.String());
            AddPrimaryKey("dbo.MemberEvents", new[] { "Event_EventID", "Member_int_MemberID" });
            RenameTable(name: "dbo.MemberEvents", newName: "EventMembers");
        }
    }
}
