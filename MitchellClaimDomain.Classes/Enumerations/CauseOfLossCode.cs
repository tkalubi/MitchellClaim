using MitchellClaimDomain.Classes.Attributes;

namespace MitchellClaimDomain.Classes.Enumerations
{
    public enum CauseOfLossCode
    {
        [StringValue("Collision")]
        Collision = 1,
        [StringValue("Explosion")]
        Explosion = 2,
        [StringValue("Fire")]
        Fire = 3,
        [StringValue("Hail")]
        Hail = 4,
        [StringValue("Mechanical Breakdown")]
        MechanicalBreakdown = 5,
        [StringValue("Other")]
        Other = 6
    }
}
