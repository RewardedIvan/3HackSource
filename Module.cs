using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Modules;
using UnityEngine;
using Windows;

// Token: 0x02000015 RID: 21
public class Module
{
	// Token: 0x06000045 RID: 69 RVA: 0x000046FD File Offset: 0x000028FD
	public virtual void Update()
	{
	}

	// Token: 0x06000046 RID: 70 RVA: 0x00004700 File Offset: 0x00002900
	public virtual void OnClick()
	{
	}

	// Token: 0x06000047 RID: 71 RVA: 0x00004703 File Offset: 0x00002903
	public virtual void OnDraw()
	{
	}

	// Token: 0x06000048 RID: 72 RVA: 0x00004706 File Offset: 0x00002906
	public virtual void OnLoadedSave()
	{
	}

	// Token: 0x06000049 RID: 73 RVA: 0x0000470C File Offset: 0x0000290C
	public virtual void Draw(Rect rect, Window wnd)
	{
        Vector2 vector = new Vector2(Input.mousePosition.x, (float)Screen.height - Input.mousePosition.y);
        UnityEngine.GUI.skin.label.alignment = TextAnchor.MiddleCenter;
        UnityEngine.GUI.skin.label.fontSize = Mathf.RoundToInt(23f * ModMain.scale);
		if (vector.x > rect.x && vector.y > rect.y && vector.x < rect.x + rect.width && vector.y < rect.y + rect.height)
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
		if (vector.x > rect.x && vector.y > rect.y && vector.x < rect.x + rect.width && vector.y < rect.y + rect.height)
		{
			Event current = Event.current;
			if (current.button == 0 && current.type == 0)
			{
				ModMain.cwm.wnds.Remove(wnd);
				ModMain.cwm.wnds.Insert(ModMain.cwm.wnds.Count, wnd);
				this.enabled = !this.enabled;
				this.OnClick();
			}
			if (current.button == 1 && Keybinds.editing)
			{
				ModMain.cwm.wnds.Remove(wnd);
				ModMain.cwm.wnds.Insert(ModMain.cwm.wnds.Count, wnd);
				Keybinds.module = this;
			}
			if (current.button == 1 && !Keybinds.editing)
			{
				ModMain.cwm.wnds.Remove(wnd);
				ModMain.cwm.wnds.Insert(ModMain.cwm.wnds.Count, wnd);
				Options.module = this;
			}
		}
		string pp = PlayerPrefs.GetString("SearchValue");
        if (pp.Length != 0)
		{
			if (this.name.ToLower().Contains(pp.ToLower()))
			{
                if (this.enabled)
                {
                    DrawUtils.DrawText(rect, this.name, DrawUtils.Accent());
                    if (this.keybind > 0)
                    {
                        UnityEngine.GUI.skin.label.alignment = TextAnchor.MiddleRight;
                        DrawUtils.DrawText(rect, "[" + this.keybind.ToString() + "] ", DrawUtils.Accent());
                    }
                }
                else
                {
                    DrawUtils.DrawText(rect, this.name, Color.white);
                    if (this.keybind > 0)
                    {
                        UnityEngine.GUI.skin.label.alignment = TextAnchor.MiddleRight;
                        DrawUtils.DrawText(rect, "[" + this.keybind.ToString() + "] ", Color.white);
                    }
                }
            } else
			{
				Color ac = DrawUtils.Accent();

                if (this.enabled)
                {
					ac.a = 0.3f;
                    DrawUtils.DrawText(rect, this.name, ac);
                    if (this.keybind > 0)
                    {
						ac.a += 0.1f;
                        UnityEngine.GUI.skin.label.alignment = TextAnchor.MiddleRight;
                        DrawUtils.DrawText(rect, "[" + this.keybind.ToString() + "] ", ac);
                    }
                }
                else
                {
                    ac.a = 0.1f;
                    DrawUtils.DrawText(rect, this.name, ac);
                    if (this.keybind > 0)
                    {
						ac.a += 0.1f;
                        UnityEngine.GUI.skin.label.alignment = TextAnchor.MiddleRight;
                        DrawUtils.DrawText(rect, "[" + this.keybind.ToString() + "] ", ac);
                    }
                }
            }
		} else
		{
            if (this.enabled)
            {
                DrawUtils.DrawText(rect, this.name, DrawUtils.Accent());
                if (this.keybind > 0)
                {
                    UnityEngine.GUI.skin.label.alignment = TextAnchor.MiddleRight;
                    DrawUtils.DrawText(rect, "[" + this.keybind.ToString() + "] ", DrawUtils.Accent());
                }
            }
            else
            {
                DrawUtils.DrawText(rect, this.name, Color.white);
                if (this.keybind > 0)
                {
                    UnityEngine.GUI.skin.label.alignment = TextAnchor.MiddleRight;
                    DrawUtils.DrawText(rect, "[" + this.keybind.ToString() + "] ", Color.white);
                }
            }
        }
		
        UnityEngine.GUI.skin.label.alignment = TextAnchor.MiddleRight;
		try
		{
			if (vector.x > rect.x && vector.y > rect.y && vector.x < rect.x + rect.width && vector.y < rect.y + rect.height)
			{
				if (this.description != "")
				{
                    UnityEngine.GUI.skin.label.alignment = TextAnchor.MiddleLeft;
					DrawUtils.DrawRect(new Rect(10f, Screen.height - 10 - 40f * ModMain.scale * 2f, 60 * this.description.Length, 80f * ModMain.scale), new Color(0.14117648f, 0.14117648f, 0.14117648f, 0.7f));
                    UnityEngine.GUI.skin.label.fontSize = Mathf.RoundToInt(45f * ModMain.scale);
					DrawUtils.DrawText(new Rect(15f, Screen.height - 10 - 40f * ModMain.scale * 2f, 60 * this.description.Length, 80f * ModMain.scale), this.description, Color.white);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x0600004A RID: 74 RVA: 0x00004C0C File Offset: 0x00002E0C
	public Rect AddRect(Rect rect1, Rect rect2)
	{
		return new Rect(rect1.x + rect2.x, rect1.y + rect2.y, rect1.width + rect2.width, rect1.height + rect2.height);
	}

	// Token: 0x04000022 RID: 34
	public string name;

	// Token: 0x04000023 RID: 35
	public bool enabled;

	// Token: 0x04000024 RID: 36
	public bool mustHaveKeyBind;

	// Token: 0x04000025 RID: 37
	public string description;

	// Token: 0x04000026 RID: 38
	public KeyCode keybind = 0;

	// Token: 0x04000027 RID: 39
	public List<ModuleSetting> settings = new List<ModuleSetting>();
}
