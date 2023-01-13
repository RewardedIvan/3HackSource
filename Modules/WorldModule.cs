using System;

namespace Modules
{
	// Token: 0x02000056 RID: 86
	[Serializable]
	public class WorldModule : Module
	{
		// Token: 0x06000105 RID: 261 RVA: 0x0000CC44 File Offset: 0x0000AE44
		public WorldModule()
		{
			this.name = "World";
		}

		// Token: 0x06000106 RID: 262 RVA: 0x0000CC5C File Offset: 0x0000AE5C
		public override void Update()
		{
			foreach (Window window in ModMain.cwm.wnds)
			{
				bool flag = window.name == "World";
				if (flag)
				{
					window.render = this.enabled;
				}
			}
		}
	}
}
