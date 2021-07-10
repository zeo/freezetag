namespace FreezeTag.Rounds
{
	public partial class PreparationRound : BaseRound
	{
		public override string RoundName => "Preparation";
		public override float RoundTime => 10f;

		public override void OnFinished()
		{
			Game.ChangeRound( new GameRound() );
		}
	}
}
