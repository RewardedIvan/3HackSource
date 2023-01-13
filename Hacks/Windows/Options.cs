using System;
using UnityEngine;

namespace Windows
{
	// Token: 0x0200001F RID: 31
	public class Options : Window
	{
		// Token: 0x06000061 RID: 97 RVA: 0x00005AD8 File Offset: 0x00003CD8
		public Options()
		{
			this.rect.position = new Vector2(300f, 20f);
			this.name = "Options";
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00005B08 File Offset: 0x00003D08
		public override void Draw()
		{
			bool flag = Options.module == null;
			if (flag)
			{
				this.name = "Options";
			}
			else
			{
				this.name = "Options (" + Options.module.name + ")";
			}
			UnityEngine.GUI.skin.label.fontSize = Mathf.RoundToInt(23f * ModMain.scale);
			bool flag2 = !ModMain.showClickGUI;
			if (!flag2)
			{
				this.rectAct = new Rect(this.rect.x, this.rect.y, 230f * ModMain.scale, 50f * ModMain.scale);
				DrawUtils.DrawRect(this.rect, DrawUtils.Accent());
				UnityEngine.GUI.skin.label.alignment = (TextAnchor)4;
				DrawUtils.DrawText(this.rect, this.name, Color.white);
				bool flag3 = Options.module == null;
				if (flag3)
				{
					DrawUtils.DrawRect(base.AddRect(this.rect, new Rect(0f, 50f * ModMain.scale, 0f, 50f * ModMain.scale * 3f)), new Color(0.14117648f, 0.14117648f, 0.14117648f));
					DrawUtils.DrawText(base.AddRect(this.rect, new Rect(0f, 0f * ModMain.scale, 0f, 50f)), "No Module Selected", Color.white);
					DrawUtils.DrawText(base.AddRect(this.rect, new Rect(0f, 65f * ModMain.scale, 0f, 50f)), "Right click a Module to change their options", Color.white);
				}
				else
				{
					bool flag4 = Options.module.settings.Count == 0;
					if (flag4)
					{
						DrawUtils.DrawRect(base.AddRect(this.rect, new Rect(0f, 50f * ModMain.scale, 0f, 50f * ModMain.scale * 3f)), new Color(0.14117648f, 0.14117648f, 0.14117648f));
						DrawUtils.DrawText(base.AddRect(this.rect, new Rect(0f, 10f * ModMain.scale, 0f, 50f)), "This module has no options", Color.white);
						DrawUtils.DrawText(base.AddRect(this.rect, new Rect(0f, 65f * ModMain.scale, 0f, 50f)), "Try another module\n\u00af\\_(ツ)_/\u00af", Color.white);
					}
					else
					{
						DrawUtils.DrawRect(base.AddRect(this.rect, new Rect(0f, 50f * ModMain.scale, 0f, 50f * ModMain.scale * (float)this.modules.Count)), new Color(0.14117648f, 0.14117648f, 0.14117648f));
					}
				}
                Vector2 vector = new Vector2(Input.mousePosition.x, (float)Screen.height - Input.mousePosition.y);
                int num = 0;
				bool flag5 = Options.module != null;
				if (flag5)
				{
					foreach (ModuleSetting moduleSetting in Options.module.settings)
					{
						num++;
						moduleSetting.Draw(base.AddRect(this.rect, new Rect(0f, 50f * (float)num * ModMain.scale, 0f, 0f)), this);
					}
				}
				this.rectAct = base.AddRect(this.rectAct, new Rect(0f, 0f, 0f, 50f * ModMain.scale * (float)num));
			}
		}

		// Token: 0x04000035 RID: 53
		public static Module module;
	}
}
