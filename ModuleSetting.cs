// Decompiled with JetBrains decompiler
// Type: ModuleSetting
// Assembly: Hacks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7044930E-2DB6-478E-8870-F3754E75DBEE
// Assembly location: C:\Users\Rewar\Desktop\3Dash Windows v1.2\Mods\Hacks.dll

using System;
using UnityEngine;

public class ModuleSetting : Module
{
  public bool boolValue;
  public int type = 1;

  public new virtual void Draw(Rect rect, Window wnd)
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
        this.boolValue = this.enabled;
      }
    }
    if (this.boolValue)
      DrawUtils.DrawText(rect, this.name, DrawUtils.Accent());
    else
      DrawUtils.DrawText(rect, this.name, Color.white);
    try
    {
      if ((double) vector2.x <= (double) ((Rect) ref rect).x || (double) vector2.y <= (double) ((Rect) ref rect).y || (double) vector2.x >= (double) ((Rect) ref rect).x + (double) ((Rect) ref rect).width || (double) vector2.y >= (double) ((Rect) ref rect).y + (double) ((Rect) ref rect).height || !(this.description != ""))
        return;
      GUI.skin.label.alignment = (TextAnchor) 3;
      DrawUtils.DrawRect(new Rect(10f, (float) (Screen.height - 10) - (float) (40.0 * (double) ModMain.scale * 2.0), (float) (60 * this.description.Length), 80f * ModMain.scale), new Color(0.141176477f, 0.141176477f, 0.141176477f, 0.25f));
      GUI.skin.label.fontSize = Mathf.RoundToInt(38f * ModMain.scale);
      DrawUtils.DrawText(new Rect(15f, (float) (Screen.height - 10) - (float) (40.0 * (double) ModMain.scale * 2.0), (float) (60 * this.description.Length), 80f * ModMain.scale), this.description, Color.white);
    }
    catch (Exception ex)
    {
    }
  }

  public new virtual void OnClick()
  {
    if (this.type != 1)
      return;
    this.boolValue = !this.boolValue;
  }
}
