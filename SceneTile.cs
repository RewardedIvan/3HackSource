// Decompiled with JetBrains decompiler
// Type: SceneTile
// Assembly: Hacks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7044930E-2DB6-478E-8870-F3754E75DBEE
// Assembly location: C:\Users\Rewar\Desktop\3Dash Windows v1.2\Mods\Hacks.dll

using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SceneTile
{
  public string SceneName;
  public Vector2 spot;
  public List<Vector2> positions = new List<Vector2>();

  public SceneTile()
  {
    this.positions.Add(new Vector2(364f, 192f));
    this.positions.Add(new Vector2(768f, 192f));
    this.positions.Add(new Vector2(1172f, 192f));
  }

  public void Draw(Vector2 selectedSpot)
  {
    Rect position;
    // ISSUE: explicit constructor call
    ((Rect) ref position).\u002Ector(0.0f, 0.0f, 384f, (float) (Screen.height - 384));
    ((Rect) ref position).position = this.positions[(int) this.spot.x];
    if (Vector2.op_Equality(this.spot, selectedSpot))
      DrawUtils.DrawOutlinedRect(position, DrawUtils.Accent(), 7f);
    else
      DrawUtils.DrawOutlinedRect(position, Color.white, 4f);
  }
}
