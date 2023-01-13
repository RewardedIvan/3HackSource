using System;

namespace Modules
{
	// Token: 0x02000053 RID: 83
	[Serializable]
	public class PlayerModule : Module
	{
		// Token: 0x060000FF RID: 255 RVA: 0x0000CA94 File Offset: 0x0000AC94
		public PlayerModule()
		{
			this.name = "Player";
		}

		// Token: 0x06000100 RID: 256 RVA: 0x0000CAAC File Offset: 0x0000ACAC
		public override void Update()
		{
			foreach (Window window in ModMain.cwm.wnds)
			{
				bool flag = window.name == "Player";
				if (flag)
				{
					window.render = this.enabled;
				}
			}
		}
	}
}
