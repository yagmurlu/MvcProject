namespace DataAccsessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _hash_Admin_Writer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminPasswordHash", c => c.Binary());
            AddColumn("dbo.Admins", "AdminPasswordSalt", c => c.Binary());
            AddColumn("dbo.Writers", "WriterPasswordHash", c => c.Binary());
            AddColumn("dbo.Writers", "WriterPasswordSalt", c => c.Binary());
            AlterColumn("dbo.Admins", "AdminUserName", c => c.Binary());
            DropColumn("dbo.Admins", "AdminPassword");
            DropColumn("dbo.Writers", "WriterPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Writers", "WriterPassword", c => c.String(maxLength: 200));
            AddColumn("dbo.Admins", "AdminPassword", c => c.String());
            AlterColumn("dbo.Admins", "AdminUserName", c => c.String());
            DropColumn("dbo.Writers", "WriterPasswordSalt");
            DropColumn("dbo.Writers", "WriterPasswordHash");
            DropColumn("dbo.Admins", "AdminPasswordSalt");
            DropColumn("dbo.Admins", "AdminPasswordHash");
        }
    }
}
