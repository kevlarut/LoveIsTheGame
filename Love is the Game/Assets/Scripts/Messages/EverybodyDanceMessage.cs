using Assets.Scripts.Shared.Enumerations;

namespace Assets.Scripts.Messages
{
	public class EverybodyDanceMessage
	{
	    public GirlType GirlType { get; set; }

	    public EverybodyDanceMessage(GirlType girlType)
	    {
	        GirlType = girlType;
	    }
	}
}
