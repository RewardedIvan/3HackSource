using System;
using UnityEngine;

namespace Modules
{
	// Token: 0x02000049 RID: 73
	[Serializable]
	internal class InstantComplete : Module
	{
		// Token: 0x060000EA RID: 234 RVA: 0x0000C24C File Offset: 0x0000A44C
		public InstantComplete()
		{
			this.name = "Instant Complete";
			this.description = "Instantly completes the level";
		}

		// Token: 0x060000EB RID: 235 RVA: 0x0000C26C File Offset: 0x0000A46C
		public override void Update()
		{
			bool enabled = this.enabled;
			if (enabled)
			{
				bool flag = UnityEngine.Object.FindObjectOfType<PlayerScript>() != null;
				if (flag)
				{
					UnityEngine.Object.FindObjectOfType<PlayerScript>().Win();
				}
			}
		}
	}
}
