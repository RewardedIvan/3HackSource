using System;
using Modules;
using UnityEngine;
using Windows;

namespace ModuleType
{
	// Token: 0x02000032 RID: 50
	public class Slider : Module
	{
		// Token: 0x060000B6 RID: 182 RVA: 0x0000A044 File Offset: 0x00008244
		public new virtual void Draw(Rect rect, Window wnd)
		{
            Vector2 vector = new Vector2(Input.mousePosition.x, (float)Screen.height - Input.mousePosition.y);
            UnityEngine.GUI.skin.label.alignment = TextAnchor.MiddleCenter;
			UnityEngine.GUI.skin.label.fontSize = Mathf.RoundToInt(23f * ModMain.scale);
			DrawUtils.DrawRect(rect, new Color(0.14117648f, 0.14117648f, 0.14117648f));
			bool flag = vector.x > rect.x && vector.y > rect.y && vector.x < rect.x + rect.width && vector.y < rect.y + rect.height;
			if (flag)
			{
				Event current = Event.current;
				bool flag2 = current.button == 0 && current.type == 0;
				if (flag2)
				{
					ModMain.cwm.wnds.Remove(wnd);
					ModMain.cwm.wnds.Insert(ModMain.cwm.wnds.Count, wnd);
					this.down = true;
				}
				bool flag3 = current.button == 1 && !Keybinds.editing;
				if (flag3)
				{
					ModMain.cwm.wnds.Remove(wnd);
					ModMain.cwm.wnds.Insert(ModMain.cwm.wnds.Count, wnd);
					Options.module = this;
				}
			}
			Event current2 = Event.current;
			bool flag4 = current2.button == 0 && current2.type == (EventType)1;
			if (flag4)
			{
				ModMain.cwm.wnds.Remove(wnd);
				ModMain.cwm.wnds.Insert(ModMain.cwm.wnds.Count, wnd);
				this.down = false;
			}
			float num = 40f;
			float num2 = rect.x + rect.width - num;
			DrawUtils.DrawRect(new Rect(num2, rect.y, num, rect.height), Color.red);
			UnityEngine.GUI.skin.label.alignment = (TextAnchor)3;
			DrawUtils.DrawText(rect, this.name, DrawUtils.Accent());
			UnityEngine.GUI.skin.label.alignment = (TextAnchor)4;
			try
			{
				bool flag5 = vector.x > rect.x && vector.y > rect.y && vector.x < rect.x + rect.width && vector.y < rect.y + rect.height;
				if (flag5)
				{
					bool flag6 = this.description != "";
					if (flag6)
					{
						UnityEngine.GUI.skin.label.alignment = (TextAnchor)3;
						DrawUtils.DrawRect(new Rect(10f, (float)(Screen.height - 10) - 40f * ModMain.scale * 2f, (float)(60 * this.description.Length), 80f * ModMain.scale), new Color(0.14117648f, 0.14117648f, 0.14117648f, 0.25f));
						UnityEngine.GUI.skin.label.fontSize = Mathf.RoundToInt(45f * ModMain.scale);
						DrawUtils.DrawText(new Rect(15f, (float)(Screen.height - 10) - 40f * ModMain.scale * 2f, (float)(60 * this.description.Length), 80f * ModMain.scale), this.description, Color.white);
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x04000065 RID: 101
		public float value;

		// Token: 0x04000066 RID: 102
		public bool down;
	}
}
