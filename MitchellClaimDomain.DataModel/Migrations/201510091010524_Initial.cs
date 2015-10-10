namespace MitchellClaimDomain.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LossInfoTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CauseOfLoss = c.Int(nullable: false),
                        ReportedDate = c.DateTime(nullable: false),
                        LossDescription = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        ClaimId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MitchellClaimTypes", t => t.ClaimId)
                .Index(t => t.ClaimId);
            
            CreateTable(
                "dbo.MitchellClaimTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimNumber = c.String(nullable: false, maxLength: 255),
                        ClaimantFirstName = c.String(),
                        ClaimantLastName = c.String(),
                        Status = c.Int(nullable: false),
                        LossDate = c.DateTime(nullable: false),
                        AssignedAdjusterID = c.Long(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.ClaimNumber, unique: true);
            
            CreateTable(
                "dbo.VehicleInfoTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModelYear = c.Int(nullable: false),
                        MakeDescription = c.String(),
                        ModelDescription = c.String(),
                        EngineDescription = c.String(),
                        ExteriorColor = c.String(),
                        Vin = c.String(),
                        LicPlate = c.String(),
                        LicPlateState = c.String(),
                        LicPlateExpDate = c.DateTime(nullable: false),
                        DamageDescription = c.String(),
                        Mileage = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VehicleInfoTypeMitchellClaimTypes",
                c => new
                    {
                        VehicleInfoType_Id = c.Int(nullable: false),
                        MitchellClaimType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VehicleInfoType_Id, t.MitchellClaimType_Id })
                .ForeignKey("dbo.VehicleInfoTypes", t => t.VehicleInfoType_Id, cascadeDelete: true)
                .ForeignKey("dbo.MitchellClaimTypes", t => t.MitchellClaimType_Id, cascadeDelete: true)
                .Index(t => t.VehicleInfoType_Id)
                .Index(t => t.MitchellClaimType_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleInfoTypeMitchellClaimTypes", "MitchellClaimType_Id", "dbo.MitchellClaimTypes");
            DropForeignKey("dbo.VehicleInfoTypeMitchellClaimTypes", "VehicleInfoType_Id", "dbo.VehicleInfoTypes");
            DropForeignKey("dbo.LossInfoTypes", "ClaimId", "dbo.MitchellClaimTypes");
            DropIndex("dbo.VehicleInfoTypeMitchellClaimTypes", new[] { "MitchellClaimType_Id" });
            DropIndex("dbo.VehicleInfoTypeMitchellClaimTypes", new[] { "VehicleInfoType_Id" });
            DropIndex("dbo.MitchellClaimTypes", new[] { "ClaimNumber" });
            DropIndex("dbo.LossInfoTypes", new[] { "ClaimId" });
            DropTable("dbo.VehicleInfoTypeMitchellClaimTypes");
            DropTable("dbo.VehicleInfoTypes");
            DropTable("dbo.MitchellClaimTypes");
            DropTable("dbo.LossInfoTypes");
        }
    }
}
