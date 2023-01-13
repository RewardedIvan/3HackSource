using System;

namespace Modules
{
	// Token: 0x02000044 RID: 68
	[Serializable]
	public class DisplayModule : Module
	{
		// Token: 0x060000DE RID: 222 RVA: 0x0000BEC2 File Offset: 0x0000A0C2
		public DisplayModule()
		{
			this.name = "Display";
		}

		// Token: 0x060000DF RID: 223 RVA: 0x0000BED8 File Offset: 0x0000A0D8
		public override void Update()
		{
			foreach (Window window in ModMain.cwm.wnds)
			{
				bool flag = window.name == "Display";
				if (flag)
				{
					window.render = this.enabled;
				}
			}
		}
	}
}
