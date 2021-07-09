using FreezeTag.Utils;

namespace FreezeTag.Rounds
{
	public class StatisticsRound : BaseRound
	{
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
