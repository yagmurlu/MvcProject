namespace DataAccsessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _deneme : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminName", c => c.String());
            AlterColumn("dbo.Admins", "AdminUserName", c => c.String());
            AlterColumn("dbo.Admins", "AdminPassword", c => c.String());
            DropColumn("dbo.Admins", "AdminRole");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "AdminRole", c => c.String(maxLength: 1));
            AlterColumn("dbo.Admins", "AdminPassword", c => c.String(maxLength: 50));
            AlterColumn("dbo.Admins", "AdminUserName", c => c.String(maxLength: 50));
            DropColumn("dbo.Admins", "AdminName");
        }
    }
}
