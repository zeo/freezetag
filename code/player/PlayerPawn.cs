using Sandbox;

namespace FreezeTag.Player
{
	public partial class PlayerPawn : Sandbox.Player
	{
		[Net] public PlayerTeam Team { get; set; } = PlayerTeam.Undetermined;
		[Net, OnChangedCallback] public bool IsFrozen { get; set; } = false;
		
		private ICamera LastCamera { get; set; }
		private ModelEntity collisionVolume { get; set; }

		public override void Spawn()
		{
			base.Spawn();

			LastCamera = new FirstPersonCamera();
		}

		public override void Respawn()
		{
			base.Respawn();
			
			SetModel( "models/citizen/citizen.vmdl" );

			Controller = new WalkController();
			Animator = new StandardPlayerAnimator();
			Camera = LastCamera;

			if ( DevController is NoclipController )
			{
				DevController = null;
			}

			EnableAllCollisions = true;
			EnableDrawing = true;
			EnableHideInFirstPerson = true;
			EnableShadowInFirstPerson = true;
			
			collisionVolume = new ModelEntity {
				CollisionGroup = CollisionGroup.Trigger,
				Transmit = TransmitType.Never, 
				Position = Position,
				EnableTouch = true,
				Parent = this,
			};

			Vector3 collOffset = new Vector3( 2, 2, 2 );
			collisionVolume.SetupPhysicsFromAABB( PhysicsMotionType.Keyframed, CollisionBounds.Mins - collOffset, CollisionBounds.Maxs + collOffset );
		}

		public void OnIsFrozenChanged()
		{
			Controller = IsFrozen ? null : new WalkController();
		}
		
		public override void StartTouch( Entity other )
		{
			base.StartTouch( other );
			
			if ( other is not PlayerPawn player ) return;
		
			Log.Info( "---" );
			Log.Info( player.GetClientOwner().Name );
			Log.Info( player.Team.ToString() );
			Log.Info( "----" );
			
			if ( Team == PlayerTeam.Tagger && player.Team == PlayerTeam.Player && !player.IsFrozen )
			{
				Log.Info( "TAGGED" );
				player.IsFrozen = true;
			} 
			else if ( !IsFrozen && Team == PlayerTeam.Player && player.Team == PlayerTeam.Player && player.IsFrozen )
			{
				Log.Info( "UNTAGGED" );
				player.IsFrozen = false;
			}
		}
	}
}
