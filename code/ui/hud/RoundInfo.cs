using System;
using FreezeTag.Player;
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

namespace FreezeTag.UI.Hud
{
	public class RoundInfo : Panel
	{
		private readonly Panel _container;
		private readonly Label _name;
		private readonly Label _time;

		public RoundInfo()
		{
			StyleSheet.Load( "/ui/hud/RoundInfo.scss" );

			_container = Add.Panel( "RoundContainer" );
			_name = _container.Add.Label( classname: "RoundName" );
			_time = _container.Add.Label( classname: "RoundTime" );
		}

		public override void Tick()
		{
			base.Tick();

			var round = Game.Instance?.Round;
			if ( round is null ) return;

			_container.SetClass( "HasDuration", round.HasDuration );
			_name.Text = round.RoundName;

			_time.Style.Display = round.HasDuration ? DisplayMode.Flex : DisplayMode.None;
			_time.Style.Dirty();

			if ( round.HasDuration )
			{
				_time.Text = Math.Ceiling( round.TimeUntilRoundEnd ) + " seconds left";
			}

			if ( Local.Pawn is not PlayerPawn player ) return;
		}
	}
}
