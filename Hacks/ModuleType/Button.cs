using System;
using Modules;
using UnityEngine;

namespace ModuleType
{
	// Token: 0x0200002D RID: 45
	public class Button : Module
	{
		// Token: 0x060000AA RID: 170 RVA: 0x000082F1 File Offset: 0x000064F1
		public new virtual void OnClick()
		{
		}

		// Token: 0x060000AB RID: 171 RVA: 0x000082F4 File Offset: 0x000064F4
		public override void Update()
		{
			bool enabled = this.enabled;
			if (enabled)
			{
				bool flag = this.canClick;
				if (flag)
				{
					this.OnClick();
				}
			}
			this.enabled = false;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00008328 File Offset: 0x00006528
		public override void Draw(Rect rect, Window wnd)
		{
			bool enabled = this.enabled;
			if (enabled)
			{
				bool flag = this.canClick;
				if (flag)
				{
					this.OnClick();
				}
			}
			this.enabled = false;
            Vector2 vector = new Vector2(Input.mousePosition.x, (float)Screen.height - Input.mousePosition.y);
            GUI.skin.label.alignment = (TextAnchor)4;
			GUI.skin.label.fontSize = Mathf.RoundToInt(23f * ModMain.scale);
			bool flag2 = vector.x > rect.x && vector.y > rect.y && vector.x < rect.x + rect.width && vector.y < rect.y + rect.height;
			if (flag2)
			{
				bool mouseButton = Input.GetMouseButton(0);
				if (mouseButton)
				{
					DrawUtils.DrawRect(rect, new Color(0.09803922f, 0.09803922f, 0.09803922f));
				}
				else
				{
					DrawUtils.DrawRect(rect, new Color(0.11764706f, 0.11764706f, 0.11764706f));
				}
			}
			else
			{
				DrawUtils.DrawRect(rect, new Color(0.14117648f, 0.14117648f, 0.14117648f));
			}
			bool flag3 = vector.x > rect.x && vector.y > rect.y && vector.x < rect.x + rect.width && vector.y < rect.y + rect.height;
			if (flag3)
			{
				Event current = Event.current;
				bool flag4 = current.button == 0 && current.type == 0;
				if (flag4)
				{
					bool flag5 = this.canClick;
					if (flag5)
					{
						this.OnClick();
					}
					ModMain.cwm.wnds.Remove(wnd);
					ModMain.cwm.wnds.Insert(ModMain.cwm.wnds.Count, wnd);
				}
				bool flag6 = current.button == 1 && Keybinds.editing;
				if (flag6)
				{
					ModMain.cwm.wnds.Remove(wnd);
					ModMain.cwm.wnds.Insert(ModMain.cwm.wnds.Count, wnd);
					Keybinds.module = this;
				}
			}
			bool enabled2 = this.enabled;
			if (enabled2)
			{
				DrawUtils.DrawText(rect, this.name, DrawUtils.Accent());
				bool flag7 = this.keybind > 0;
				if (flag7)
				{
					GUI.skin.label.alignment = (TextAnchor)5;
					DrawUtils.DrawText(rect, "[" + this.keybind.ToString() + "] ", DrawUtils.Accent());
				}
			}
			else
			{
				DrawUtils.DrawText(rect, this.name, Color.white);
				bool flag8 = this.keybind > 0;
				if (flag8)
				{
					GUI.skin.label.alignment = (TextAnchor)5;
					DrawUtils.DrawText(rect, "[" + this.keybind.ToString() + "] ", Color.white);
				}
			}
			GUI.skin.label.alignment = (TextAnchor)4;
			try
			{
				bool flag9 = vector.x > rect.x && vector.y > rect.y && vector.x < rect.x + rect.width && vector.y < rect.y + rect.height;
				if (flag9)
				{
					bool flag10 = this.description != "";
					if (flag10)
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

		// Token: 0x04000052 RID: 82
		public bool canClick = true;
	}
}
