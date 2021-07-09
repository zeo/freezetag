using Sandbox;

namespace FreezeTag.Rounds
{
	public partial class PreparationRound : BaseRound
	{
		public override string RoundName => "Preparation";
		public override float RoundTime => 10f;

		public override void OnFinished()
		{
			Log.Info( "called" );
			Game.ChangeRound( new GameRound() );
		}
	}
}
