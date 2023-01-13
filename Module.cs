// Decompiled with JetBrains decompiler
// Type: Module
// Assembly: Hacks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7044930E-2DB6-478E-8870-F3754E75DBEE
// Assembly location: C:\Users\Rewar\Desktop\3Dash Windows v1.2\Mods\Hacks.dll

using Modules;
using System;
using System.Collections.Generic;
using UnityEngine;
using Windows;

public class Module
{
  public string name;
  public bool enabled;
  public bool mustHaveKeyBind;
  public string description;
  public KeyCode keybind = (KeyCode) 0;
  public List<ModuleSetting> settings = new List<ModuleSetting>();

  public virtual void Update()
  {
  }

  public virtual void OnClick()
  {
  }

  public virtual void OnDraw()
  {
  }

  public virtual void OnLoadedSave()
  {
  }

  public virtual void Draw(Rect rect, Window wnd)
  {
    Vector2 vector2;
    // ISSUE: explicit constructor call
    ((Vector2) ref vector2).\u002Ector(Input.mousePosition.x, (float) Screen.height - Input.mousePosition.y);
    GUI.skin.label.alignment = (TextAnchor) 4;
    GUI.skin.label.fontSize = Mathf.RoundToInt(23f * ModMain.scale);
    if ((double) vector2.x > (double) ((Rect) ref rect).x && (double) vector2.y > (double) ((Rect) ref rect).y && (double) vector2.x < (double) ((Rect) ref rect).x + (double) ((Rect) ref rect).width && (double) vector2.y < (double) ((Rect) ref rect).y + (double) ((Rect) ref rect).height)
    {
      if (Input.GetMouseButton(0))
        DrawUtils.DrawRect(rect, new Color(0.09803922f, 0.09803922f, 0.09803922f));
      else
        DrawUtils.DrawRect(rect, new Color(0.117647059f, 0.117647059f, 0.117647059f));
    }
    else
      DrawUtils.DrawRect(rect, new Color(0.141176477f, 0.141176477f, 0.141176477f));
    if ((double) vector2.x > (double) ((Rect) ref rect).x && (double) vector2.y > (double) ((Rect) ref rect).y && (double) vector2.x < (double) ((Rect) ref rect).x + (double) ((Rect) ref rect).width && (double) vector2.y < (double) ((Rect) ref rect).y + (double) ((Rect) ref rect).height)
    {
      Event current = Event.current;
      if (current.button == 0 && current.type == 0)
      {
        Window window = wnd;
        ModMain.cwm.wnds.Remove(wnd);
        ModMain.cwm.wnds.Insert(ModMain.cwm.wnds.Count, window);
        this.enabled = !this.enabled;
        this.OnClick();
      }
      if (current.button == 1 && current.type == null && Keybinds.editing)
      {
        Window window = wnd;
        ModMain.cwm.wnds.Remove(wnd);
        ModMain.cwm.wnds.Insert(ModMain.cwm.wnds.Count, window);
        Keybinds.module = this;
      }
      if (current.button == 1 && current.type == null && !Keybinds.editing)
      {
        Window window = wnd;
        ModMain.cwm.wnds.Remove(wnd);
        ModMain.cwm.wnds.Insert(ModMain.cwm.wnds.Count, window);
        Options.module = this;
      }
    }
    if (this.enabled)
    {
      DrawUtils.DrawText(rect, this.name, DrawUtils.Accent());
      if (this.keybind > 0)
      {
        GUI.skin.label.alignment = (TextAnchor) 5;
        DrawUtils.DrawText(rect, "[" + this.keybind.ToString() + "] ", DrawUtils.Accent());
      }
    }
    else
    {
      DrawUtils.DrawText(rect, this.name, Color.white);
      if (this.keybind > 0)
      {
        GUI.skin.label.alignment = (TextAnchor) 5;
        DrawUtils.DrawText(rect, "[" + this.keybind.ToString() + "] ", Color.white);
      }
    }
    GUI.skin.label.alignment = (TextAnchor) 4;
    try
    {
      if ((double) vector2.x <= (double) ((Rect) ref rect).x || (double) vector2.y <= (double) ((Rect) ref rect).y || (double) vector2.x >= (double) ((Rect) ref rect).x + (double) ((Rect) ref rect).width || (double) vector2.y >= (double) ((Rect) ref rect).y + (double) ((Rect) ref rect).height || !(this.description != ""))
        return;
      GUI.skin.label.alignment = (TextAnchor) 3;
      DrawUtils.DrawRect(new Rect(10f, (float) (Screen.height - 10) - (float) (40.0 * (double) ModMain.scale * 2.0), (float) (60 * this.description.Length), 80f * ModMain.scale), new Color(0.141176477f, 0.141176477f, 0.141176477f, 0.25f));
      GUI.skin.label.fontSize = Mathf.RoundToInt(45f * ModMain.scale);
      DrawUtils.DrawText(new Rect(15f, (float) (Screen.height - 10) - (float) (40.0 * (double) ModMain.scale * 2.0), (float) (60 * this.description.Length), 80f * ModMain.scale), this.description, Color.white);
    }
    catch (Exception ex)
    {
    }
  }

  public Rect AddRect(Rect rect1, Rect rect2) => new Rect(((Rect) ref rect1).x + ((Rect) ref rect2).x, ((Rect) ref rect1).y + ((Rect) ref rect2).y, ((Rect) ref rect1).width + ((Rect) ref rect2).width, ((Rect) ref rect1).height + ((Rect) ref rect2).height);
}
