using System;

namespace Modules
{
	// Token: 0x02000052 RID: 82
	[Serializable]
	public class OptionsModule : Module
	{
		// Token: 0x060000FD RID: 253 RVA: 0x0000CA04 File Offset: 0x0000AC04
		public OptionsModule()
		{
			this.name = "Options";
		}

		// Token: 0x060000FE RID: 254 RVA: 0x0000CA1C File Offset: 0x0000AC1C
		public override void Update()
		{
			foreach (Window window in ModMain.cwm.wnds)
			{
				bool flag = window.name.StartsWith("Options");
				if (flag)
				{
					window.render = this.enabled;
				}
			}
		}
	}
}
