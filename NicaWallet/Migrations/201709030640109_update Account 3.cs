namespace NicaWallet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateAccount3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Account", "LastUpdate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Account", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Account", "UserId", c => c.String(nullable: false));
            AlterColumn("dbo.Account", "LastUpdate", c => c.DateTime());
        }
    }
}
