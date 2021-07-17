using FreezeTag.Utils;

namespace FreezeTag.Rounds
{
	public class StatisticsRound : BaseRound
	{
		public override string RoundName => "Round Ended";
		public override float RoundTime => 10f;
		
		public override void OnStarted()
		{
			// TODO: open statistics panel
		}

		public override void OnFinished()
		{
			// TODO: close statistics panel
			
			Game.ChangeRound( GameUtils.HasEnoughPlayers() ? new PreparationRound() : new WaitingForPlayersRound() );
		}
	}
}
