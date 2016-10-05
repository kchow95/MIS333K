namespace Chow_Kenneth_hw3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "str_FName", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "str_LName", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "str_Email", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "Major", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "Major", c => c.String());
            AlterColumn("dbo.Members", "str_Email", c => c.String());
            AlterColumn("dbo.Members", "str_LName", c => c.String());
            AlterColumn("dbo.Members", "str_FName", c => c.String());
        }
    }
}
