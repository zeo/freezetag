using Sandbox;
using Sandbox.UI;

namespace FreezeTag.UI.Hud
{
	public class Hud : HudEntity<RootPanel>
	{
		public Hud()
		{
			if ( !IsClient )
				return;
			
			// TODO: hud
			RootPanel.AddChild<RoundInfo>();
			RootPanel.AddChild<ChatBox>();
		}
	}
}
