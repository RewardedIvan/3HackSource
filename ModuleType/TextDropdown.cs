using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace ModuleType
{
	// Token: 0x0200002F RID: 47
	public class TextDropdown : Module
	{
		// Token: 0x060000B0 RID: 176 RVA: 0x00008FDC File Offset: 0x000071DC
		public override void Draw(Rect rect, Window wnd)
		{
            Vector2 vector = new Vector2(Input.mousePosition.x, (float)Screen.height - Input.mousePosition.y);
            GUI.skin.label.alignment = (TextAnchor)3;
			GUI.skin.textField.alignment = (TextAnchor)3;
			GUI.skin.label.fontSize = Mathf.RoundToInt(23f * ModMain.scale);
			GUI.skin.textField.fontSize = Mathf.RoundToInt(21f * ModMain.scale);
			DrawUtils.DrawRect(rect, new Color(0.14117648f, 0.14117648f, 0.14117648f));
			Rect rect2 = base.AddRect(base.AddRect(rect, new Rect(4f, 4f, -8f, -8f)), new Rect(0f, 0f, 50f * ModMain.scale * -1f - 4f, 0f));
			DrawUtils.DrawRect(base.AddRect(base.AddRect(rect, new Rect(4f, 4f, -8f, -8f)), new Rect(0f, 0f, 50f * ModMain.scale * -1f - 4f, 0f)), new Color(0.11764706f, 0.11764706f, 0.11764706f));
			this.text = DrawUtils.DrawTextField(rect2, this.text, Color.white);
			bool flag = this.numberOnly;
			if (flag)
			{
				this.text = Regex.Replace(this.text, "[^0-9 .]", "");
			}
			bool flag2 = this.showingDropdown;
			if (flag2)
			{
                Color color = new Color(0.14117648f, 0.14117648f, 0.14117648f);
                DrawUtils.DrawRect(base.AddRect(rect, new Rect(rect.width, 0f, 0f, rect.height * (float)(this.content.Count - 1))), color);
				int num = 0;
				foreach (string text in this.content)
				{
					Rect rect3 = base.AddRect(rect, new Rect(rect.width, rect.height * (float)num, 0f, 0f));
					DrawUtils.DrawText(rect3, "  " + text, Color.white);
					num++;
					bool flag3 = Event.current.type == 0;
					if (flag3)
					{
						bool flag4 = vector.x > rect3.x && vector.y > rect3.y && vector.x < rect3.x + rect3.width && vector.y < rect3.y + rect3.height;
						if (flag4)
						{
							this.text = text;
							this.showingDropdown = false;
						}
					}
				}
			}
            Rect rect4 = new Rect(0f, rect.y, rect.width - rect2.width, rect.height);
            GUI.skin.label.fontSize = Mathf.RoundToInt(25f * ModMain.scale);
			GUI.skin.label.alignment = (TextAnchor)5;
			DrawUtils.DrawText(rect, this.showingDropdown ? "<    " : ">    ", Color.white);
			GUI.skin.label.alignment = (TextAnchor)4;
			bool flag5 = Event.current.type == 0;
			if (flag5)
			{
				bool flag6 = vector.x > rect.width - 50f * ModMain.scale && vector.y > rect.y && vector.x < rect.x + rect.width && vector.y < rect.y + rect.height;
				if (flag6)
				{
					this.showingDropdown = !this.showingDropdown;
				}
			}
			try
			{
				bool flag7 = vector.x > rect.x && vector.y > rect.y && vector.x < rect.x + rect.width && vector.y < rect.y + rect.height;
				if (flag7)
				{
					bool flag8 = this.description != "";
					if (flag8)
					{
						GUI.skin.label.alignment = (TextAnchor)3;
						DrawUtils.DrawRect(new Rect(10f, (float)(Screen.height - 10) - 40f * ModMain.scale * 2f, (float)(60 * this.description.Length), 80f * ModMain.scale), new Color(0.14117648f, 0.14117648f, 0.14117648f, 0.25f));
						GUI.skin.label.fontSize = Mathf.RoundToInt(45f * ModMain.scale);
						DrawUtils.DrawText(new Rect(15f, (float)(Screen.height - 10) - 40f * ModMain.scale * 2f, (float)(60 * this.description.Length), 80f * ModMain.scale), this.description, Color.white);
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x04000057 RID: 87
		public string text;

		// Token: 0x04000058 RID: 88
		public string placeHolder;

		// Token: 0x04000059 RID: 89
		public bool numberOnly;

		// Token: 0x0400005A RID: 90
		public Color colour;

		// Token: 0x0400005B RID: 91
		public bool showingDropdown = false;

		// Token: 0x0400005C RID: 92
		public List<string> content = new List<string>();
	}
}
