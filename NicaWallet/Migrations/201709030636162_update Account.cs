namespace NicaWallet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateAccount : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Account", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Account", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Account", "IsActive", c => c.Boolean());
            AlterColumn("dbo.Account", "CreatedDate", c => c.DateTime());
        }
    }
}
