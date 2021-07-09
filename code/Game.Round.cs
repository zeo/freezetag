using FreezeTag.Rounds;
using Sandbox;

namespace FreezeTag
{
	public partial class Game
	{
		[Net] public BaseRound Round { get; set; }

		public void ChangeRound( BaseRound newRound )
		{
			Round = newRound;
			Round.Start();
		}
	}
}
