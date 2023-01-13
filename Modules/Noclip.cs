using System;
using UnityEngine;

namespace Modules
{
	// Token: 0x0200004B RID: 75
	[Serializable]
	internal class Noclip : Module
	{
		// Token: 0x060000EE RID: 238 RVA: 0x0000C328 File Offset: 0x0000A528
		public Noclip()
		{
			this.name = "Noclip";
			this.description = "Stops you from dying";
			this.keybind = (KeyCode)107;
			this.settings.Add(new BetterNoclip(this));
		}

		// Token: 0x060000EF RID: 239 RVA: 0x0000C364 File Offset: 0x0000A564
		public override void Update()
		{
			Noclip.isNoclipEnabled = this.enabled;
			bool flag = UnityEngine.Object.FindObjectOfType<PlayerScript>() != null;
			if (flag)
			{
				UnityEngine.Object.FindObjectOfType<PlayerScript>().noDeath = this.enabled;
			}
		}

		// Token: 0x04000075 RID: 117
		public static bool isNoclipEnabled;
	}
}
