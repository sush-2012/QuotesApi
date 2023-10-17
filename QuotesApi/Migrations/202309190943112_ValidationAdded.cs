namespace QuotesApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidationAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Quotes", "Title", c => c.String(nullable: false, maxLength: 25));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Quotes", "Title", c => c.String());
        }
    }
}
