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
			if (this.enabled)
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
					if (this.canClick)
					{
						this.OnClick();
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
                            GUI.skin.label.alignment = (TextAnchor)5;
                            DrawUtils.DrawText(rect, "[" + this.keybind.ToString() + "] ", DrawUtils.Accent());
                        }
                    }
                    else
                    {
                        DrawUtils.DrawText(rect, this.name, Color.white);
                        if (this.keybind > 0)
                        {
                            GUI.skin.label.alignment = (TextAnchor)5;
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
                            GUI.skin.label.alignment = (TextAnchor)5;
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
                            GUI.skin.label.alignment = (TextAnchor)5;
                            DrawUtils.DrawText(rect, "[" + this.keybind.ToString() + "] ", ac);
                        }
                    }
                }
			} else
			{
                if (this.enabled)
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
                    if (this.keybind > 0)
                    {
                        GUI.skin.label.alignment = (TextAnchor)5;
                        DrawUtils.DrawText(rect, "[" + this.keybind.ToString() + "] ", Color.white);
                    }
                }
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
		}

		// Token: 0x04000052 RID: 82
		public bool canClick = true;
	}
}
