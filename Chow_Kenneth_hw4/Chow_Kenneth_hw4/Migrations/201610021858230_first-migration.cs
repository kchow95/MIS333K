namespace Chow_Kenneth_hw4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigration : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Members");
        }
    }
}
