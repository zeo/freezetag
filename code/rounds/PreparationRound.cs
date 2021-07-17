using System.Linq;
using FreezeTag.UI.Hud;
using Sandbox;

namespace FreezeTag.Rounds
{
	public partial class PreparationRound : BaseRound
	{
		public override string RoundName => "Preparation";
		public override float RoundTime => 10f;

		public override void OnStarted()
		{
			base.OnStarted();

			Local.Hud.ChildrenOfType<GameRoundCountdown>()
				.First().Start();
		}

		public override void OnFinished()
		{
			Log.Info( "ok" );
			GameRoundCountdown.Instance?.Hide();
			Game.ChangeRound( new GameRound() );
		}
	}
}
