using System;
using UnityEngine;

namespace Windows
{
	// Token: 0x0200001B RID: 27
	public class Speedhack : Window
	{
		// Token: 0x0600005C RID: 92 RVA: 0x00005618 File Offset: 0x00003818
		public Speedhack()
		{
			this.rect.position = new Vector2(300f, 20f);
			this.name = "Speedhack";
			this.modules.Add(new SpeedhackInput());
			this.modules.Add(new SpeedhackButton());
			this.modules.Add(new SpeedhackMusic());
		}
	}
}
