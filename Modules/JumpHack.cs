using System;
using UnityEngine;

namespace Modules
{
	// Token: 0x0200004A RID: 74
	[Serializable]
	internal class JumpHack : Module
	{
		// Token: 0x060000EC RID: 236 RVA: 0x0000C2A2 File Offset: 0x0000A4A2
		public JumpHack()
		{
			this.name = "Jump Hack";
			this.description = "Allows you to jump in the air";
		}

		// Token: 0x060000ED RID: 237 RVA: 0x0000C2C4 File Offset: 0x0000A4C4
		public override void Update()
		{
			bool enabled = this.enabled;
			if (enabled)
			{
				PlayerScript playerScript = UnityEngine.Object.FindObjectOfType<PlayerScript>();
				bool flag = playerScript != null;
				if (flag)
				{
					playerScript.onGround = true;
					bool isCube = playerScript.isCube;
					if (isCube)
					{
						bool jumpInput = playerScript.jumpInput;
						if (jumpInput)
						{
							playerScript.vsp = playerScript.velocityForHeight(2.133f, 1f);
						}
					}
				}
			}
		}
	}
}
