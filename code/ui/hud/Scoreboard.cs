using FreezeTag.Player;
using Sandbox;
using Sandbox.UI;

namespace FreezeTag.UI.Hud
{
	[UseTemplate]
	public class Scoreboard : Panel
	{
		public Scoreboard()
		{
			StyleSheet.Load( "/ui/hud/Scoreboard.scss" );

			PlayerScore.OnPlayerAdded += AddPlayer;
			PlayerScore.OnPlayerUpdated += UpdatePlayer;
			PlayerScore.OnPlayerRemoved += RemovePlayer;

			foreach ( PlayerScore.Entry player in PlayerScore.All )
			{
				AddPlayer( player );
			}
		}

		public override void Tick()
		{
			base.Tick();
			
			SetClass( "open", Input.Down( InputButton.Score ) );
		}

		protected virtual void AddPlayer(PlayerScore.Entry entry)
		{
			
		}
		
		protected virtual void UpdatePlayer(PlayerScore.Entry entry)
		{
			
		}
		
		protected virtual void RemovePlayer(PlayerScore.Entry entry)
		{
			
		}
	}
}
