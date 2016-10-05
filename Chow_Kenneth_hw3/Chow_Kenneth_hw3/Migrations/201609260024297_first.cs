namespace Chow_Kenneth_hw3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        int_MemberID = c.Int(nullable: false, identity: true),
                        str_FName = c.String(),
                        str_LName = c.String(),
                        str_Email = c.String(),
                        int_Phone = c.Int(nullable: false),
                        bool_OKToText = c.Boolean(nullable: false),
                        Major = c.String(),
                    })
                .PrimaryKey(t => t.int_MemberID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Members");
        }
    }
}
