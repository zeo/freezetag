using System.Linq;
using FreezeTag.Config;
using FreezeTag.Player;
using Sandbox;

namespace FreezeTag.Utils
{
	public static class GameUtils
	{
		public static int GetTaggersCount()
		{
			var playerCount = Entity.All.OfType<PlayerPawn>().Count();

			return (int) MathX.Floor( playerCount / FreezeTagConfig.TaggersPerPlayers ) + 1;
		}
		
		public static bool HasEnoughPlayers()
		{
			return Entity.All.OfType<PlayerPawn>().Count() >= FreezeTagConfig.PlayersNeeded;
		}
	}
}
