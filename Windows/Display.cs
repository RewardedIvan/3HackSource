using System;
using Modules;
using UnityEngine;

namespace Windows
{
	// Token: 0x02000019 RID: 25
	public class Display : Window
	{
		// Token: 0x06000057 RID: 87 RVA: 0x00005334 File Offset: 0x00003534
		public Display()
		{
			this.rect.position = new Vector2(980f, 20f);
			this.name = "Display";
			this.modules.Add(new Fullscreen());
			this.modules.Add(new ResolutionInput());
			this.modules.Add(new ResolutionApply());
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000053A2 File Offset: 0x000035A2
		public override void OnUpdate()
		{
		}
	}
}
