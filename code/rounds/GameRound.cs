﻿using System.Linq;
using FreezeTag.Player;
using Sandbox;

namespace FreezeTag.Rounds
{
	public class GameRound : BaseRound
	{
		public override string RoundName => "PLAY!";
		public override float RoundTime => 500f;

		public override void OnStarted()
		{
			Log.Info( "test" );
			
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
			var players = Game.Players.ToList();
			for (var i = 0; i < players.Count; i++)
			{
				Log.Info( "dwadaw" );
				players[i].Team = i == 0 ? PlayerTeam.Tagger : PlayerTeam.Player;
			}
		}

		public override void OnFinished()
		{
			Game.ChangeRound( new StatisticsRound() );
		}
	}
}