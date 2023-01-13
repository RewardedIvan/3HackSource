// Decompiled with JetBrains decompiler
// Type: SpeedhackInput
// Assembly: Hacks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7044930E-2DB6-478E-8870-F3754E75DBEE
// Assembly location: C:\Users\Rewar\Desktop\3Dash Windows v1.2\Mods\Hacks.dll

using ModuleType;
using UnityEngine;

public class SpeedhackInput : TextInput
{
  public SpeedhackInput()
  {
    this.text = PlayerPrefs.GetString("SpeedhackValue", "1");
    this.numberOnly = true;
  }

  public override void Update() => PlayerPrefs.SetString("SpeedhackValue", this.text);
}
