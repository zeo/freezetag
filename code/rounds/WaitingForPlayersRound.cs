using FreezeTag.Utils;
using Sandbox;

namespace FreezeTag.Rounds
{
	public partial class WaitingForPlayersRound : BaseRound
	{
		public override string RoundName => "Waiting for Players";
		public override bool HasDuration => false;

		public override void OnPlayerJoined( Client client )
		{
			if ( GameUtils.HasEnoughPlayers() )
			{
				Finish();
			}
		}

		public override void OnFinished()
		{
			Game.ChangeRound( new PreparationRound() );
		}
	}
}
