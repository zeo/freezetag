using FreezeTag.Player;
using Sandbox;
using Sandbox.UI;

namespace FreezeTag.UI.Hud
{
	public class FrozenOverlay : Panel
	{
		public FrozenOverlay()
		{
			StyleSheet.Load( "/ui/hud/FrozenOverlay.scss" );
		}
		
		public override void Tick()
		{
			base.Tick();

			if ( Local.Pawn is not PlayerPawn player ) return;
			
			SetClass( "Frozen", player.IsFrozen );
		}
	}
}
