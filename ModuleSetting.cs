using System;
using UnityEngine;

// Token: 0x0200000E RID: 14
public class ModuleSetting : Module
{
	// Token: 0x0600001C RID: 28 RVA: 0x00002A6C File Offset: 0x00000C6C
	public new virtual void Draw(Rect rect, Window wnd)
	{
        Vector2 vector = new Vector2(Input.mousePosition.x, (float)Screen.height - Input.mousePosition.y);
        GUI.skin.label.alignment = (TextAnchor)4;
		GUI.skin.label.fontSize = Mathf.RoundToInt(23f * ModMain.scale);
		bool flag = vector.x > rect.x && vector.y > rect.y && vector.x < rect.x + rect.width && vector.y < rect.y + rect.height;
		if (flag)
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
		bool flag2 = vector.x > rect.x && vector.y > rect.y && vector.x < rect.x + rect.width && vector.y < rect.y + rect.height;
		if (flag2)
		{
			Event current = Event.current;
			bool flag3 = current.button == 0 && current.type == 0;
			if (flag3)
			{
				ModMain.cwm.wnds.Remove(wnd);
				ModMain.cwm.wnds.Insert(ModMain.cwm.wnds.Count, wnd);
				this.enabled = !this.enabled;
				this.boolValue = this.enabled;
			}
		}
		bool flag4 = this.boolValue;
		if (flag4)
		{
			DrawUtils.DrawText(rect, this.name, DrawUtils.Accent());
		}
		else
		{
			DrawUtils.DrawText(rect, this.name, Color.white);
		}
		try
		{
			bool flag5 = vector.x > rect.x && vector.y > rect.y && vector.x < rect.x + rect.width && vector.y < rect.y + rect.height;
			if (flag5)
			{
				bool flag6 = this.description != "";
				if (flag6)
				{
					GUI.skin.label.alignment = (TextAnchor)3;
					DrawUtils.DrawRect(new Rect(10f, (float)(Screen.height - 10) - 40f * ModMain.scale * 2f, (float)(60 * this.description.Length), 80f * ModMain.scale), new Color(0.14117648f, 0.14117648f, 0.14117648f, 0.25f));
					GUI.skin.label.fontSize = Mathf.RoundToInt(38f * ModMain.scale);
					DrawUtils.DrawText(new Rect(15f, (float)(Screen.height - 10) - 40f * ModMain.scale * 2f, (float)(60 * this.description.Length), 80f * ModMain.scale), this.description, Color.white);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x0600001D RID: 29 RVA: 0x00002E04 File Offset: 0x00001004
	public new virtual void OnClick()
	{
		bool flag = this.type == 1;
		if (flag)
		{
			this.boolValue = !this.boolValue;
		}
	}

	// Token: 0x0400000A RID: 10
	public bool boolValue;

	// Token: 0x0400000B RID: 11
	public int type = 1;
}
