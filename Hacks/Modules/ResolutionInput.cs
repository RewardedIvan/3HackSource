using System;
using ModuleType;
using UnityEngine;

namespace Modules
{
	// Token: 0x02000041 RID: 65
	public class ResolutionInput : TextInput
	{
		// Token: 0x060000D8 RID: 216 RVA: 0x0000BC53 File Offset: 0x00009E53
		public ResolutionInput()
		{
			this.name = "Resolution";
			this.text = PlayerPrefs.GetString("Res", "960x540");
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x0000BC7D File Offset: 0x00009E7D
		public override void Update()
		{
			PlayerPrefs.SetString("Res", this.text);
		}
	}
}
