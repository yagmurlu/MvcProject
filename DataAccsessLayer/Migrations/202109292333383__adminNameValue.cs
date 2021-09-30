namespace DataAccsessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _adminNameValue : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "AdminName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "AdminName", c => c.String());
        }
    }
}
