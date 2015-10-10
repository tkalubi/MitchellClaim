namespace MitchellClaimDomain.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OneToOneClaimToLossInfo_2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.LossInfoTypes", new[] { "ClaimId" });
            AlterColumn("dbo.LossInfoTypes", "ClaimId", c => c.Int(nullable: false));
            CreateIndex("dbo.LossInfoTypes", "ClaimId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.LossInfoTypes", new[] { "ClaimId" });
            AlterColumn("dbo.LossInfoTypes", "ClaimId", c => c.Int());
            CreateIndex("dbo.LossInfoTypes", "ClaimId");
        }
    }
}
