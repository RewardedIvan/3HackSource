using System;

namespace Modules
{
	// Token: 0x02000045 RID: 69
	[Serializable]
	public class ReplayModule : Module
	{
		// Token: 0x060000E0 RID: 224 RVA: 0x0000BF50 File Offset: 0x0000A150
		public ReplayModule()
		{
			this.name = "Replay";
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x0000BF68 File Offset: 0x0000A168
		public override void Update()
		{
			foreach (Window window in ModMain.cwm.wnds)
			{
				bool flag = window.name == "Replay";
				if (flag)
				{
					window.render = this.enabled;
				}
			}
		}
	}
}
