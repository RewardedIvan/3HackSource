using System;
using Modules;
using UnityEngine;

namespace ModuleType
{
	// Token: 0x02000031 RID: 49
	public class DualSidedToggle : Module
	{
		// Token: 0x060000B4 RID: 180 RVA: 0x00009880 File Offset: 0x00007A80
		public override void Draw(Rect rect, Window wnd)
		{
            Vector2 vector = new Vector2(Input.mousePosition.x, (float)Screen.height - Input.mousePosition.y);
            GUI.skin.label.alignment = (TextAnchor)4;
			GUI.skin.label.fontSize = Mathf.RoundToInt(23f * ModMain.scale);
			if (vector.x > rect.x && vector.y > rect.y && vector.x < rect.x + rect.width / 2f && vector.y < rect.y + rect.height)
			{
				if (Input.GetMouseButton(0))
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
			if (vector.x > rect.x + rect.width / 2f && vector.y > rect.y && vector.x < rect.x + rect.width && vector.y < rect.y + rect.height)
			{
				if (Input.GetMouseButton(0))
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
			if (vector.x > rect.x && vector.y > rect.y && vector.x < rect.x + rect.width && vector.y < rect.y + rect.height)
			{
				Event current = Event.current;
				if (current.button == 0 && current.type == 0)
				{
					if (vector.x > rect.x && vector.y > rect.y && vector.x < rect.x + rect.width / 2f && vector.y < rect.y + rect.height)
					{
						this.rightOn = false;
					}
					if (vector.x > rect.x + rect.width / 2f && vector.y > rect.y && vector.x < rect.x + rect.width && vector.y < rect.y + rect.height)
					{
						this.rightOn = true;
					}
					ModMain.cwm.wnds.Remove(wnd);
					ModMain.cwm.wnds.Insert(ModMain.cwm.wnds.Count, wnd);
				}
				if (current.button == 1 && Keybinds.editing)
				{
					ModMain.cwm.wnds.Remove(wnd);
					ModMain.cwm.wnds.Insert(ModMain.cwm.wnds.Count, wnd);
					Keybinds.module = this;
				}
			}
			if (this.anySelected)
			{
				if (!this.rightOn)
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
				if (vector.x > rect.x && vector.y > rect.y && vector.x < rect.x + rect.width && vector.y < rect.y + rect.height)
				{
					DrawUtils.DrawDescription(this.description, this.GetHashCode());
				}
			}
			catch (Exception)
			{
			}
			this.enabled = this.rightOn;
		}

		// Token: 0x04000061 RID: 97
		public string name1;

		// Token: 0x04000062 RID: 98
		public string name2;

		// Token: 0x04000063 RID: 99
		public bool rightOn;

		// Token: 0x04000064 RID: 100
		public bool anySelected = true;
	}
}
