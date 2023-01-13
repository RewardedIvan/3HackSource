using System;

namespace Modules
{
	// Token: 0x02000055 RID: 85
	[Serializable]
	public class CreatorModule : Module
	{
		// Token: 0x06000103 RID: 259 RVA: 0x0000CBB4 File Offset: 0x0000ADB4
		public CreatorModule()
		{
			this.name = "Creator";
		}

		// Token: 0x06000104 RID: 260 RVA: 0x0000CBCC File Offset: 0x0000ADCC
		public override void Update()
		{
			foreach (Window window in ModMain.cwm.wnds)
			{
				bool flag = window.name == "Creator";
				if (flag)
				{
					window.render = this.enabled;
				}
			}
		}
	}
}
