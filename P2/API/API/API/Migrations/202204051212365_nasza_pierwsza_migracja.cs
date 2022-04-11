namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nasza_pierwsza_migracja : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Currencies", "base_currency_", c => c.String());
            AddColumn("dbo.Currencies", "final_currency_", c => c.String());
            AddColumn("dbo.Currencies", "date_", c => c.String());
            AddColumn("dbo.Currencies", "rate_", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Currencies", "rate_");
            DropColumn("dbo.Currencies", "date_");
            DropColumn("dbo.Currencies", "final_currency_");
            DropColumn("dbo.Currencies", "base_currency_");
        }
    }
}
