using Sandbox;

namespace FreezeTag.Player
{
	public partial class PlayerPawn
	{
		private ModelEntity Pants { get; set; }
		private ModelEntity Jacket { get; set; }
		private ModelEntity Shoes { get; set; }
		private ModelEntity Hat { get; set; }

		private bool IsDressed { get; set; } = false;

		public void Dress()
		{
			if ( IsDressed ) return;
			IsDressed = true;

			if ( true )
			{
				var model = Rand.FromArray( new[]
				{
					"models/citizen_clothes/trousers/trousers.jeans.vmdl",
					"models/citizen_clothes/trousers/trousers.lab.vmdl",
					"models/citizen_clothes/trousers/trousers.police.vmdl",
					"models/citizen_clothes/trousers/trousers.smart.vmdl",
					"models/citizen_clothes/trousers/trousers.smarttan.vmdl",
					"models/citizen/clothes/trousers_tracksuit.vmdl",
					"models/citizen_clothes/trousers/trousers_tracksuitblue.vmdl",
					"models/citizen_clothes/trousers/trousers_tracksuit.vmdl",
					"models/citizen_clothes/shoes/shorts.cargo.vmdl",
				} );

				Pants = new ModelEntity();
				Pants.SetModel( model );
				Pants.SetParent( this, true );
				Pants.EnableShadowInFirstPerson = true;
				Pants.EnableHideInFirstPerson = true;

				SetBodyGroup( "Legs", 1 );
			}

			if ( true )
			{
				var model = Rand.FromArray( new[]
				{
					"models/citizen_clothes/jacket/labcoat.vmdl", "models/citizen_clothes/jacket/jacket.red.vmdl",
					"models/citizen_clothes/jacket/jacket.tuxedo.vmdl",
					"models/citizen_clothes/jacket/jacket_heavy.vmdl",
				} );

				Jacket = new ModelEntity();
				Jacket.SetModel( model );
				Jacket.SetParent( this, true );
				Jacket.EnableShadowInFirstPerson = true;
				Jacket.EnableHideInFirstPerson = true;

				var propInfo = Jacket.GetModel().GetPropData();
				if ( propInfo.ParentBodyGroupName != null )
				{
					SetBodyGroup( propInfo.ParentBodyGroupName, propInfo.ParentBodyGroupValue );
				}
				else
				{
					SetBodyGroup( "Chest", 0 );
				}
			}

			if ( true )
			{
				var model = Rand.FromArray( new[]
				{
					"models/citizen_clothes/shoes/trainers.vmdl",
					"models/citizen_clothes/shoes/shoes.workboots.vmdl"
				} );

				Shoes = new ModelEntity();
				Shoes.SetModel( model );
				Shoes.SetParent( this, true );
				Shoes.EnableShadowInFirstPerson = true;
				Shoes.EnableHideInFirstPerson = true;

				SetBodyGroup( "Feet", 1 );
			}

			if ( true )
			{
				var model = Rand.FromArray( new[]
				{
					"models/citizen_clothes/hat/hat_hardhat.vmdl", "models/citizen_clothes/hat/hat_woolly.vmdl",
					"models/citizen_clothes/hat/hat_securityhelmet.vmdl",
					"models/citizen_clothes/hair/hair_malestyle02.vmdl",
					"models/citizen_clothes/hair/hair_femalebun.black.vmdl",
					"models/citizen_clothes/hat/hat_beret.red.vmdl", "models/citizen_clothes/hat/hat.tophat.vmdl",
					"models/citizen_clothes/hat/hat_beret.black.vmdl", "models/citizen_clothes/hat/hat_cap.vmdl",
					"models/citizen_clothes/hat/hat_leathercap.vmdl",
					"models/citizen_clothes/hat/hat_leathercapnobadge.vmdl",
					"models/citizen_clothes/hat/hat_securityhelmetnostrap.vmdl",
					"models/citizen_clothes/hat/hat_service.vmdl",
					"models/citizen_clothes/hat/hat_uniform.police.vmdl",
					"models/citizen_clothes/hat/hat_woollybobble.vmdl",
				} );

				Hat = new ModelEntity();
				Hat.SetModel( model );
				Hat.SetParent( this, true );
				Hat.EnableShadowInFirstPerson = true;
				Hat.EnableHideInFirstPerson = true;
			}
		}
	}
}
