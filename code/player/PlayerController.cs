using Sandbox;

namespace FreezeTag.Player
{
	public partial class PlayerController : WalkController
	{
		[Net, Predicted, Local] public bool IsFrozen { get; set; }

		public override void FrameSimulate()
		{
			if ( IsFrozen ) return;
			
			base.FrameSimulate();
		}

		public override void Simulate()
		{
			if ( IsFrozen )
			{
				WishVelocity = Vector3.Zero;
				Velocity = WishVelocity;
				return;
			}
			
			base.Simulate();
		}
	}
}
