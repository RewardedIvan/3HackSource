using System;
using Windows;

namespace Modules
{
	// Token: 0x0200003C RID: 60
	public class InfiniteObjectLimit : Module
	{
		// Token: 0x060000CD RID: 205 RVA: 0x0000B4FC File Offset: 0x000096FC
		public InfiniteObjectLimit()
		{
			this.name = "No Object Limit";
			this.description = "Removes the object limit (sets it to " + int.MaxValue.ToString() + ")";
		}

		// Token: 0x060000CE RID: 206 RVA: 0x0000B540 File Offset: 0x00009740
		public override void Update()
		{
			bool flag = this.enabled && Creator.inEditor;
			if (flag)
			{
				bool flag2 = Creator.editor != null;
				if (flag2)
				{
					Creator.editor.objectLimit = int.MaxValue;
				}
			}
		}
	}
}
