using System;
using FreezeTag.Player;
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

namespace FreezeTag.UI.Hud
{
	public class RoundInfo : Panel
	{
		private Panel Container;
		private readonly Label RoundName;
		private readonly Label RoundTime;
		
		public RoundInfo()
		{
			StyleSheet.Load( "/ui/hud/RoundInfo.scss" );

			Container = Add.Panel( "RoundContainer" );
			RoundName = Container.Add.Label( "", "RoundName" );
			RoundTime = Container.Add.Label( "", "RoundTime" );
		}

		public override void Tick()
		{
			base.Tick();

			var round = Game.Instance?.Round;
			if ( round is null ) return;

			if ( Local.Pawn is not PlayerPawn player ) return;

			var team = player.Team.ToString();
			
			var time = round.HasDuration ? round.TimeUntilRoundEnd.ToString() : "no time";
			
			RoundName.Text = round.RoundName;
			RoundTime.Text = round.HasDuration ? Math.Round(round.TimeUntilRoundEnd) + " seconds left" : "";
		}
	}
}
