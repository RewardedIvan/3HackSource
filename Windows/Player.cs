using System;
using Modules;
using UnityEngine;

namespace Windows
{
	// Token: 0x02000020 RID: 32
	public class Player : Window
	{
		// Token: 0x06000063 RID: 99 RVA: 0x00005F00 File Offset: 0x00004100
		public Player()
		{
			this.rect.position = new Vector2(440f, 20f);
			this.name = "Player";
			this.modules.Add(new Noclip());
			this.modules.Add(new Die());
			this.modules.Add(new JumpHack());
			this.modules.Add(new InstantComplete());
			this.modules.Add(new FlipGravity());
			this.modules.Add(new ShowAttemptCount());
			this.modules.Add(new ShowHitbox());
		}
	}
}
