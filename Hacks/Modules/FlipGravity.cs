using System;
using ModuleType;
using UnityEngine;

namespace Modules
{
	// Token: 0x0200003A RID: 58
	public class FlipGravity : Button
	{
		// Token: 0x060000C8 RID: 200 RVA: 0x0000AC85 File Offset: 0x00008E85
		public FlipGravity()
		{
			this.name = "Flip Gravity";
			this.description = "Flips The Players Gravity";
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x0000ACA8 File Offset: 0x00008EA8
		public override void OnClick()
		{
			bool flag = UnityEngine.Object.FindObjectOfType<PlayerScript>() != null;
			if (flag)
			{
				UnityEngine.Object.FindObjectOfType<PlayerScript>().grav *= -1f;
				UnityEngine.Object.FindObjectOfType<PlayerScript>().vsp *= 0.5f;
			}
			this.canClick = true;
		}
	}
}
