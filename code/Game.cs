using System.Collections.Generic;
using System.Linq;
using FreezeTag.Player;
using FreezeTag.Rounds;
using FreezeTag.UI.Hud;
using Sandbox;

namespace FreezeTag
{
	[Library("freezetag", Title = "Freeze Tag")]
	public partial class Game : Sandbox.Game
	{
		public static Game Instance => Current as Game;
		public static IEnumerable<PlayerPawn> Players => All.OfType<PlayerPawn>();

		public Game()
		{
			Round = new WaitingForPlayersRound();
			
			if ( IsServer )
			{
				_ = new Hud();
			}
		}
		
		public override void ClientJoined( Client client )
		{
			base.ClientJoined( client );

			var pawn = new PlayerPawn();
			pawn.Respawn();

			client.Pawn = pawn;
			
			Round.OnPlayerJoined( client );
		}

		public override void ClientDisconnect( Client cl, NetworkDisconnectionReason reason )
		{
			
		}

		[Event.Tick]
		public void OnTick()
		{
			Round?.Tick();
		}
	}
}
