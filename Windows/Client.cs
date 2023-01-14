using System;
using Modules;
using UnityEngine;
using static Windows.Client;

namespace Windows
{
	// Token: 0x0200001C RID: 28
	public class Client : Window
	{
		// Token: 0x0600005D RID: 93 RVA: 0x00005688 File Offset: 0x00003888
		public class ResetToDefaults : Module
		{
			public ResetToDefaults()
			{
				this.name = "Reset to defaults";
				this.description = "Resets the configuration";
				// TODO
			}
		}

        public Client()
		{
			this.rect.position = new Vector2(480f, 20f);
			this.name = "Client";
			this.modules.Add(new Keybinds());
			this.modules.Add(new Discord());
			this.modules.Add(new ClickGUI());
			this.modules.Add(new CatMode()); // you cant keep this secret
			this.modules.Add(new ResetToDefaults());
			this.modules.Add(new Quit());
		}
	}
}
