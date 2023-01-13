using System;

namespace Modules
{
	// Token: 0x02000054 RID: 84
	public class StatusModule : Module
	{
		// Token: 0x06000101 RID: 257 RVA: 0x0000CB24 File Offset: 0x0000AD24
		public StatusModule()
		{
			this.name = "Status";
		}

		// Token: 0x06000102 RID: 258 RVA: 0x0000CB3C File Offset: 0x0000AD3C
		public override void Update()
		{
			foreach (Window window in ModMain.cwm.wnds)
			{
				bool flag = window.name == "Status";
				if (flag)
				{
					window.render = this.enabled;
				}
			}
		}
	}
}
