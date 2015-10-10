using MitchellClaimDomain.Classes.Attributes;

namespace MitchellClaimDomain.Classes.Enumerations
{
    public enum StatusCode
    {
			[StringValue("OPEN")]
            OPEN=0,
			[StringValue("CLOSED")]
            CLOSED=1
    }
}
