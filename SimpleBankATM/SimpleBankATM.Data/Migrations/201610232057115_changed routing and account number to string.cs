namespace SimpleBankATM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedroutingandaccountnumbertostring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "RoutingNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Accounts", "RoutingNumber", c => c.Int(nullable: false));
        }
    }
}
