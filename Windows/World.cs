using System;
using Modules;
using UnityEngine;

namespace Windows
{
	// Token: 0x02000023 RID: 35
	public class World : Window
	{
		// Token: 0x0600006B RID: 107 RVA: 0x0000663C File Offset: 0x0000483C
		public World()
		{
			this.rect.position = new Vector2(300f, 20f);
			this.name = "World";
			this.modules.Add(new InfiniteDistance());
			this.modules.Add(new PracticeMusic());
		}
	}
}
