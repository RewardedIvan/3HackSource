using System;
using ModuleType;
using UnityEngine;

namespace Modules
{
	// Token: 0x02000035 RID: 53
	public class Die : Button
	{
		// Token: 0x060000BC RID: 188 RVA: 0x0000A784 File Offset: 0x00008984
		public Die()
		{
			this.name = "Kill";
			this.description = "Kills The Player";
		}

		// Token: 0x060000BD RID: 189 RVA: 0x0000A7A4 File Offset: 0x000089A4
		public override void OnClick()
		{
			bool flag = UnityEngine.Object.FindObjectOfType<PlayerScript>() != null;
			if (flag)
			{
				UnityEngine.Object.FindObjectOfType<PlayerScript>().Die(true);
			}
			this.canClick = true;
		}
	}
}
