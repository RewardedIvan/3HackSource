using System;

namespace Modules
{
	// Token: 0x02000046 RID: 70
	[Serializable]
	public class SpeedhackModule : Module
	{
		// Token: 0x060000E2 RID: 226 RVA: 0x0000BFE0 File Offset: 0x0000A1E0
		public SpeedhackModule()
		{
			this.name = "Speedhack";
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x0000BFF8 File Offset: 0x0000A1F8
		public override void Update()
		{
			foreach (Window window in ModMain.cwm.wnds)
			{
				bool flag = window.name == "Speedhack";
				if (flag)
				{
					window.render = this.enabled;
				}
			}
		}
	}
}
