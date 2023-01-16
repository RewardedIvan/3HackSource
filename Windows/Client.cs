using System;
using Modules;
using UnityEngine;
using System.IO;
using ModuleType;

namespace Windows
{
	// Token: 0x0200001C RID: 28
	public class Client : Window
	{
		public class Authors : Button
		{
			public Authors()
			{
				this.name = "Authors";
				this.description = "- Explodingbill\n- RewardedIvan";
			}
		}

        public Client()
		{
			this.rect.position = new Vector2(480f, 20f);
			this.name = "Client";
			this.modules.Add(new Keybinds());
			this.modules.Add(new Discord());
            this.modules.Add(new Authors());
            this.modules.Add(new ClickGUI());
			this.modules.Add(new CatMode()); // you cant keep this secret
			this.modules.Add(new ResetToDefaults());
			this.modules.Add(new Quit());
		}
	}
}
