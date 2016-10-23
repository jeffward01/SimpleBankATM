namespace SimpleBankATM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeddecimaltoint : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "Balance", c => c.Int(nullable: false));
            AlterColumn("dbo.Transactions", "TransactionAmount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transactions", "TransactionAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Accounts", "Balance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
