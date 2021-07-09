using Sandbox;

namespace FreezeTag.Rounds
{
	public abstract partial class BaseRound : NetworkComponent
	{
		/// <summary>
		/// The name of the round, shown in the UI
		/// </summary>
		public virtual string RoundName => "Unknown Round";

		/// <summary>
		/// The icon of the round, shown in the UI
		/// </summary>
		public virtual string RoundIcon => "";

		/// <summary>
		/// Indicates if the round has a duration.
		/// For example this is disabled in the <see cref="WaitingForPlayersRound"/>
		/// </summary>
		public virtual bool HasDuration => true;
		
		/// <summary>
		/// The time the round lasts in seconds
		/// </summary>
		public virtual float RoundTime => 600f;
		
		/// <summary>
		/// The absolute time when the round ends (in seconds)
		/// </summary>
		[Net] public float RoundEndTime { get; set; }

		/// <summary>
		/// Time in seconds until the round ends
		/// </summary>
		public float TimeUntilRoundEnd => RoundEndTime - Time.Now;

		public Game Game => Game.Instance;
		
		public void Start()
		{
			RoundEndTime = Time.Now + RoundTime;
			
			OnStarted();
		}

		public void Finish()
		{
			OnFinished();
		}
		
		[Event.Tick]
		public void Tick()
		{
			if ( HasDuration && RoundEndTime < Time.Now )
			{
				Finish();
			}

			OnTick();
		}

		public virtual void OnStarted()
		{
			//
		}

		public virtual void OnFinished()
		{
			//
		}

		public virtual void OnTick()
		{
			//
		}

		public virtual void OnPlayerJoined( Client client )
		{
			//
		}
	}
}
