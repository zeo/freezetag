namespace FreezeTag
{
	public partial class Game
	{
		[ServerVar( "freezetag_players_needed", Help = "How many players are required to start a game round." )]
		public static int PlayersNeeded { get; set; } = 2;

		[ServerVar( "freezetag_players_per_tagger", Help = "How many players there are per 1 tagger." )]
		public static int PlayersPerTagger { get; set; } = 3;
	}
}
