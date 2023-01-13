using System;
using ModuleType;
using UnityEngine;

namespace Modules
{
	// Token: 0x02000036 RID: 54
	public class Discord : Button
	{
		// Token: 0x060000BE RID: 190 RVA: 0x0000A7D6 File Offset: 0x000089D6
		public Discord()
		{
			this.name = "Discord";
			this.description = "Opens a link to the 3Dash Discord server";
		}

		// Token: 0x060000BF RID: 191 RVA: 0x0000A7F6 File Offset: 0x000089F6
		public override void OnClick()
		{
			Application.OpenURL("https://discord.com/invite/tC9r89h3zp");
		}
	}
}
