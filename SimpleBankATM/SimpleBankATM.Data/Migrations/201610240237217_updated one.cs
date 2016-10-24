namespace SimpleBankATM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedone : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "SocialSecurityNumber", c => c.String());
            AlterColumn("dbo.Customers", "DateOfBirth", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "DateOfBirth", c => c.DateTime());
            AlterColumn("dbo.Customers", "SocialSecurityNumber", c => c.Int(nullable: false));
        }
    }
}
