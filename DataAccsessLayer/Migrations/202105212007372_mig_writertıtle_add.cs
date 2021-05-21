namespace DataAccsessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_writertıtle_add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterTıtle", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "WriterTıtle");
        }
    }
}
