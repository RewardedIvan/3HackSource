using System;
using UnityEngine;

namespace Modules
{
	// Token: 0x02000051 RID: 81
	[Serializable]
	internal class InfiniteDistance : Module
	{
		// Token: 0x060000FB RID: 251 RVA: 0x0000C9A0 File Offset: 0x0000ABA0
		public InfiniteDistance()
		{
			this.name = "InfRenDis";
		}

		// Token: 0x060000FC RID: 252 RVA: 0x0000C9B8 File Offset: 0x0000ABB8
		public override void Update()
		{
			bool flag = GameObject.Find("WorldGenerator") != null;
			if (flag)
			{
				GameObject.Find("WorldGenerator").GetComponent<WorldGenerator>().renderDistance = (this.enabled ? float.PositiveInfinity : 14f);
			}
		}
	}
}
