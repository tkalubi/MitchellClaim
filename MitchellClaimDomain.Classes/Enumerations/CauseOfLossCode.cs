using MitchellClaimDomain.Classes.Attributes;

namespace MitchellClaimDomain.Classes.Enumerations
{
    public enum CauseOfLossCode
    {
        [StringValue("Explosion")]
        Explosion = 1,
        [StringValue("Fire")]
        Fire = 2,
        [StringValue("Hail")]
        Hail = 3,
        [StringValue("Mechanical Breakdown")]
        MechanicalBreakdown = 4,
        [StringValue("Other")]
        Other = 5
    }
}
