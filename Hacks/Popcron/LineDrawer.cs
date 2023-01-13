using System;
using UnityEngine;

namespace Popcron
{
	// Token: 0x02000027 RID: 39
	public class LineDrawer : Drawer
	{
		// Token: 0x06000073 RID: 115 RVA: 0x00006BE0 File Offset: 0x00004DE0
		public override int Draw(ref Vector3[] buffer, params object[] args)
		{
			buffer[0] = (Vector3)args[0];
			buffer[1] = (Vector3)args[1];
			return 2;
		}
	}
}
