using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

namespace FreezeTag.UI.Hud
{
	public class GameRoundCountdown : Panel
	{
		public static GameRoundCountdown Instance { get; private set; }

		private bool Hidden { get; set; } = true;
		
		private readonly Label _countLabel;

		private int CountValue { get; set; } = 3;
		
		public int Count
		{
			get => CountValue;
			set
			{
				CountValue = value;
				_countLabel.Text = value.ToString();
			}
		}

		private TimeSince TimeSinceLastCountUp { get; set; }
		
		public GameRoundCountdown()
		{
			StyleSheet.Load( "/ui/hud/GameRoundCountdown.scss" );
			AddClass( "Hidden" );
			
			TimeSinceLastCountUp = 0;
			Instance = this;
			
			_countLabel = Add.Label( "3", "Count" );
		}

		public void Start()
		{
			Log.Info( "ran" );
			Count = 3;
			RemoveClass( "Hidden" );
			Hidden = false;
		}

		public void Hide()
		{
			Hidden = true;
			AddClass( "Hidden" );
		}
		
		public override void Tick()
		{
			base.Tick();

			Instance = this;
			
			if ( Hidden ) return;
			
			if ( TimeSinceLastCountUp >= 1 )
			{
				RemoveClass( "ScalingDown" );
				Count--;

				TimeSinceLastCountUp = 0;
				AddClass( "ScalingUp" );
			}
			else if ( TimeSinceLastCountUp >= 0.8 )
			{
				RemoveClass( "ScalingUp" );
				AddClass( "ScalingDown" );
			}
		}
	}
}
