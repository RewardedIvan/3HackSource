using System;
using UnityEngine;

namespace Modules
{
	// Token: 0x02000034 RID: 52
	public class Autocheckpoints : Module
	{
		// Token: 0x060000BA RID: 186 RVA: 0x0000A701 File Offset: 0x00008901
		public Autocheckpoints()
		{
			this.name = "Autocheckpoints";
			this.description = "Automatically places checkpoints when you fall";
		}

		// Token: 0x060000BB RID: 187 RVA: 0x0000A724 File Offset: 0x00008924
		public override void Update()
		{
			try
			{
				bool flag = UnityEngine.Object.FindObjectOfType<PlayerScript>() != null;
				if (flag)
				{
					bool onGround = UnityEngine.Object.FindObjectOfType<PlayerScript>().onGround;
					if (onGround)
					{
						bool inPracticeMode = PauseMenuManager.inPracticeMode;
						if (inPracticeMode)
						{
							UnityEngine.Object.FindObjectOfType<PracticeButtonScript>().MakeCP();
						}
					}
				}
			}
			catch
			{
			}
		}
	}
}
