using System;

namespace Modules
{
	// Token: 0x02000050 RID: 80
	[Serializable]
	public class DebugModule : Module
	{
		// Token: 0x060000F9 RID: 249 RVA: 0x0000C910 File Offset: 0x0000AB10
		public DebugModule()
		{
			this.name = "Debug";
		}

		// Token: 0x060000FA RID: 250 RVA: 0x0000C928 File Offset: 0x0000AB28
		public override void Update()
		{
			foreach (Window window in ModMain.cwm.wnds)
			{
				bool flag = window.name == "Debug";
				if (flag)
				{
					window.render = this.enabled;
				}
			}
		}
	}
}
