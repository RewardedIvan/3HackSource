using System;
using ModuleType;
using UnityEngine;

namespace Modules
{
	// Token: 0x0200003B RID: 59
	public class Fullscreen : DualSidedToggle
	{
		// Token: 0x060000CA RID: 202 RVA: 0x0000ACFA File Offset: 0x00008EFA
		public Fullscreen()
		{
			this.name = "isFullscreen";
			this.name1 = "Windowed";
			this.name2 = "Fullscreen";
			this.enabled = true;
		}

		// Token: 0x060000CB RID: 203 RVA: 0x0000AD2C File Offset: 0x00008F2C
		public override void Update()
		{
			this.enabled = this.rightOn;
			Fullscreen.isFullscreen = this.rightOn;
		}

		// Token: 0x060000CC RID: 204 RVA: 0x0000AD48 File Offset: 0x00008F48
		public override void Draw(Rect rect, Window wnd)
		{
            Vector2 vector = new Vector2(Input.mousePosition.x, (float)Screen.height - Input.mousePosition.y);
            GUI.skin.label.alignment = (TextAnchor)4;
			GUI.skin.label.fontSize = Mathf.RoundToInt(21f * ModMain.scale);
			bool flag = vector.x > rect.x && vector.y > rect.y && vector.x < rect.x + rect.width / 2f && vector.y < rect.y + rect.height;
			if (flag)
			{
				bool mouseButton = Input.GetMouseButton(0);
				if (mouseButton)
				{
					DrawUtils.DrawRect(new Rect(rect.x, rect.y, rect.width / 2f, rect.height), new Color(0.09803922f, 0.09803922f, 0.09803922f));
				}
				else
				{
					DrawUtils.DrawRect(new Rect(rect.x, rect.y, rect.width / 2f, rect.height), new Color(0.11764706f, 0.11764706f, 0.11764706f));
				}
			}
			else
			{
				DrawUtils.DrawRect(new Rect(rect.x, rect.y, rect.width / 2f, rect.height), new Color(0.14117648f, 0.14117648f, 0.14117648f));
			}
			bool flag2 = vector.x > rect.x + rect.width / 2f && vector.y > rect.y && vector.x < rect.x + rect.width && vector.y < rect.y + rect.height;
			if (flag2)
			{
				bool mouseButton2 = Input.GetMouseButton(0);
				if (mouseButton2)
				{
					DrawUtils.DrawRect(new Rect(rect.x + rect.width / 2f, rect.y, rect.width / 2f, rect.height), new Color(0.09803922f, 0.09803922f, 0.09803922f));
				}
				else
				{
					DrawUtils.DrawRect(new Rect(rect.x + rect.width / 2f, rect.y, rect.width / 2f, rect.height), new Color(0.11764706f, 0.11764706f, 0.11764706f));
				}
			}
			else
			{
				DrawUtils.DrawRect(new Rect(rect.x + rect.width / 2f, rect.y, rect.width / 2f, rect.height), new Color(0.14117648f, 0.14117648f, 0.14117648f));
			}
			bool flag3 = vector.x > rect.x && vector.y > rect.y && vector.x < rect.x + rect.width && vector.y < rect.y + rect.height;
			if (flag3)
			{
				Event current = Event.current;
				bool flag4 = current.button == 0 && current.type == 0;
				if (flag4)
				{
					bool flag5 = vector.x > rect.x && vector.y > rect.y && vector.x < rect.x + rect.width / 2f && vector.y < rect.y + rect.height;
					if (flag5)
					{
						this.rightOn = false;
					}
					bool flag6 = vector.x > rect.x + rect.width / 2f && vector.y > rect.y && vector.x < rect.x + rect.width && vector.y < rect.y + rect.height;
					if (flag6)
					{
						this.rightOn = true;
					}
					ModMain.cwm.wnds.Remove(wnd);
					ModMain.cwm.wnds.Insert(ModMain.cwm.wnds.Count, wnd);
				}
				bool flag7 = current.button == 1 && Keybinds.editing;
				if (flag7)
				{
					ModMain.cwm.wnds.Remove(wnd);
					ModMain.cwm.wnds.Insert(ModMain.cwm.wnds.Count, wnd);
					Keybinds.module = this;
				}
			}
			bool anySelected = this.anySelected;
			if (anySelected)
			{
				bool flag8 = !this.rightOn;
				if (flag8)
				{
					GUI.skin.label.alignment = (TextAnchor)3;
					DrawUtils.DrawText(rect, " " + this.name1, DrawUtils.Accent());
					GUI.skin.label.alignment = (TextAnchor)5;
					DrawUtils.DrawText(rect, this.name2 + " ", Color.white);
				}
				else
				{
					GUI.skin.label.alignment = (TextAnchor)3;
					DrawUtils.DrawText(rect, " " + this.name1, Color.white);
					GUI.skin.label.alignment = (TextAnchor)5;
					DrawUtils.DrawText(rect, this.name2 + " ", DrawUtils.Accent());
				}
			}
			else
			{
				GUI.skin.label.alignment = (TextAnchor)3;
				DrawUtils.DrawText(rect, " " + this.name1, Color.white);
				GUI.skin.label.alignment = (TextAnchor)5;
				DrawUtils.DrawText(rect, this.name2 + " ", Color.white);
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
			this.enabled = this.rightOn;
		}

		// Token: 0x04000071 RID: 113
		public static bool isFullscreen;
	}
}
