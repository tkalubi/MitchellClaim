namespace MitchellClaimDomain.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelYearRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VehicleInfoTypes", "LicPlateExpDate", c => c.DateTime());
            AlterColumn("dbo.VehicleInfoTypes", "Mileage", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VehicleInfoTypes", "Mileage", c => c.Int(nullable: false));
            AlterColumn("dbo.VehicleInfoTypes", "LicPlateExpDate", c => c.DateTime(nullable: false));
        }
    }
}
