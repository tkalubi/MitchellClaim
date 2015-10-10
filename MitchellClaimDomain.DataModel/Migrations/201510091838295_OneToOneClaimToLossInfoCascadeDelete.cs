namespace MitchellClaimDomain.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OneToOneClaimToLossInfoCascadeDelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LossInfoTypes", "ClaimId", "dbo.MitchellClaimTypes");
            AddForeignKey("dbo.LossInfoTypes", "ClaimId", "dbo.MitchellClaimTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LossInfoTypes", "ClaimId", "dbo.MitchellClaimTypes");
            AddForeignKey("dbo.LossInfoTypes", "ClaimId", "dbo.MitchellClaimTypes", "Id");
        }
    }
}
