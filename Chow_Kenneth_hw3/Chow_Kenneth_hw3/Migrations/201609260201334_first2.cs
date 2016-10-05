namespace Chow_Kenneth_hw3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "str_Phone", c => c.String(nullable: false));
            DropColumn("dbo.Members", "int_Phone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Members", "int_Phone", c => c.Int(nullable: false));
            DropColumn("dbo.Members", "str_Phone");
        }
    }
}
