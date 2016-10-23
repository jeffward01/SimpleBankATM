namespace SimpleBankATM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refactoreddboclassesandfinishedrepositories : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Accounts", name: "UserId", newName: "CustomerId");
            RenameIndex(table: "dbo.Accounts", name: "IX_UserId", newName: "IX_CustomerId");
            AlterColumn("dbo.Accounts", "AccountNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Accounts", "AccountNumber", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.Accounts", name: "IX_CustomerId", newName: "IX_UserId");
            RenameColumn(table: "dbo.Accounts", name: "CustomerId", newName: "UserId");
        }
    }
}
