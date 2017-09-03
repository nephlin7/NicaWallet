namespace NicaWallet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAccount5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Account", "CreatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Account", "CreatedDate", c => c.DateTime(nullable: false));
        }
    }
}
