using FreezeTag.Rounds;
using Sandbox;

namespace FreezeTag.Player
{
	public partial class PlayerPawn : Sandbox.Player
	{
		[Net] public PlayerTeam Team { get; set; } = PlayerTeam.Undetermined;
		
		[Net, Predicted, Local]
		public bool IsFrozen { get; set; } = false;

		private ICamera LastCamera { get; set; }

		private ModelEntity CollisionVolume { get; set; }

		public override void Spawn()
		{
			base.Spawn();

			LastCamera = new ThirdPersonCamera();
		}

		public override void Respawn()
		{
			base.Respawn();

			SetModel( "models/citizen/citizen.vmdl" );

			Controller = new PlayerController();
			Animator = new StandardPlayerAnimator();
			Camera = LastCamera;

			if ( DevController is NoclipController )
			{
				DevController = null;
			}

			Dress();

			EnableAllCollisions = true;
			EnableDrawing = true;
			EnableHideInFirstPerson = true;
			EnableShadowInFirstPerson = true;

			CollisionVolume = new ModelEntity
			{
				CollisionGroup = CollisionGroup.Trigger,
				Transmit = TransmitType.Never,
				Position = Position,
				EnableTouch = true,
				Parent = this,
			};

			var collOffset = new Vector3( 2, 2, 2 );

			CollisionVolume.SetupPhysicsFromAABB(
				PhysicsMotionType.Keyframed,
				CollisionBounds.Mins - collOffset,
				CollisionBounds.Maxs + collOffset
			);
		}

		public void Freeze()
		{
			IsFrozen = true;
			((PlayerController) Controller).IsFrozen = true;
			
			Game.Instance.Round.OnPlayerFrozen( this );
		}

		public void Unfreeze()
		{
			IsFrozen = false;
			((PlayerController)Controller).IsFrozen = false;
		}

		public override void StartTouch( Entity other )
		{
			base.StartTouch( other );

			if ( other is not PlayerPawn player ) return;
			if ( Game.Instance.Round is not GameRound ) return;

			if ( Team == PlayerTeam.Tagger && player.Team == PlayerTeam.Player && !player.IsFrozen )
			{
				player.Freeze();
			}
			else if ( !IsFrozen && Team == PlayerTeam.Player && player.Team == PlayerTeam.Player && player.IsFrozen )
			{
				player.Unfreeze();
			}
		}
	}
}
