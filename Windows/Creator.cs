using System;
using Modules;
using UnityEngine;

namespace Windows
{
	// Token: 0x02000022 RID: 34
	public class Creator : Window
	{
		// Token: 0x06000069 RID: 105 RVA: 0x000065A4 File Offset: 0x000047A4
		public Creator()
		{
			this.rect.position = new Vector2(730f, 20f);
			this.name = "Creator";
			this.modules.Add(new InfiniteObjectLimit());
			this.modules.Add(new InfLevels());
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00006604 File Offset: 0x00004804
		public override void OnUpdate()
		{
			Creator.inEditor = !(UnityEngine.Object.FindObjectOfType<FlatEditor>() == null);
			bool flag = Creator.inEditor;
			if (flag)
			{
				Creator.editor = UnityEngine.Object.FindObjectOfType<FlatEditor>();
			}
		}

		// Token: 0x04000038 RID: 56
		public static bool inEditor;

		// Token: 0x04000039 RID: 57
		public static FlatEditor editor;
	}
}
