namespace QuotesApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuoteTyperemoved : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Quotes", "Title", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Quotes", "Title", c => c.String(nullable: false, maxLength: 25));
        }
    }
}
