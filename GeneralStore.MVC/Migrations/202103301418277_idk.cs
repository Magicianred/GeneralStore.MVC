namespace GeneralStore.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class idk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "Transaction_Id", "dbo.Transactions");
            DropIndex("dbo.Transactions", new[] { "Transaction_Id" });
            DropColumn("dbo.Transactions", "Transaction_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "Transaction_Id", c => c.Int());
            CreateIndex("dbo.Transactions", "Transaction_Id");
            AddForeignKey("dbo.Transactions", "Transaction_Id", "dbo.Transactions", "Id");
        }
    }
}
