using System;

namespace Modules
{
	// Token: 0x0200004F RID: 79
	[Serializable]
	public class ClientModule : Module
	{
		// Token: 0x060000F7 RID: 247 RVA: 0x0000C881 File Offset: 0x0000AA81
		public ClientModule()
		{
			this.name = "Client";
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x0000C898 File Offset: 0x0000AA98
		public override void Update()
		{
			foreach (Window window in ModMain.cwm.wnds)
			{
				bool flag = window.name == "Client";
				if (flag)
				{
					window.render = this.enabled;
				}
			}
		}
	}
}
