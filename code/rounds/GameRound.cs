using System.Linq;
using FreezeTag.Player;
using Sandbox;

namespace FreezeTag.Rounds
{
	public class GameRound : BaseRound
	{
		public override string RoundName => "In Game";
		public override float RoundTime => 500f;

		public override void OnStarted()
		{
			if ( Host.IsServer )
			{
				MovePlayersToSpawnpoints();
				AssignTeams();
			}
		}

		private void MovePlayersToSpawnpoints()
		{
			Host.AssertServer();
		}

		private void AssignTeams()
		{
			Host.AssertServer();

			var players = Game.Players.ToList();
			for ( var i = 0; i < players.Count; i++ )
			{
				players[i].Team = i == 1 ? PlayerTeam.Tagger : PlayerTeam.Player;
			}
		}

		public override void OnPlayerJoined( Client client, PlayerPawn pawn )
		{
			pawn.Team = PlayerTeam.Player;
		}

		public override void OnFinished()
		{
			// Unfreeze all players
			foreach (var playerPawn in Game.Players)
			{
				playerPawn.IsFrozen = false;
			}

			Game.ChangeRound( new StatisticsRound() );
		}

		public override void OnPlayerFrozen( PlayerPawn pawn )
		{
			var shouldContinue = Entity.All
				.OfType<PlayerPawn>()
				.Any( p => p.Team == PlayerTeam.Player && !p.IsFrozen );

			if ( !shouldContinue )
			{
				Finish();
			}
		}
	}
}
