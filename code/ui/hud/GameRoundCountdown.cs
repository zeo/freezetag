using Sandbox.UI;
using Sandbox.UI.Construct;

namespace FreezeTag.UI.Hud
{
	public class GameRoundCountdown : Panel
	{
		private readonly Label _text;
		
		public GameRoundCountdown()
		{
			StyleSheet.Load( "/ui/hud/GameRoundCountdown.scss" );

			_text = Add.Label( "3", "Text" );
		}

		public override void Tick()
		{
			base.Tick();
		}
	}
}
