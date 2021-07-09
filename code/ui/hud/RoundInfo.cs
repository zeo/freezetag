using FreezeTag.Player;
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

namespace FreezeTag.UI.Hud
{
	public class RoundInfo : Panel
	{
		private readonly Label _label;
		
		public RoundInfo()
		{
			_label = Add.Label( "dwadwa" );
		}

		public override void Tick()
		{
			base.Tick();

			var round = Game.Instance?.Round;
			if ( round is null ) return;

			if ( Local.Pawn is not PlayerPawn player ) return;

			var team = player.Team.ToString();
			
			var time = round.HasDuration ? round.TimeUntilRoundEnd.ToString() : "no time";
			
			_label.Text = round.RoundName + " - " + time + " - " + team;
		}
	}
}
