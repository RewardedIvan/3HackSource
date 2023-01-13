// Decompiled with JetBrains decompiler
// Type: InfLevelsCount
// Assembly: Hacks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7044930E-2DB6-478E-8870-F3754E75DBEE
// Assembly location: C:\Users\Rewar\Desktop\3Dash Windows v1.2\Mods\Hacks.dll

using ModuleType;
using UnityEngine;

public class InfLevelsCount : TextOption
{
  public InfLevelsCount()
  {
    this.name = nameof (InfLevelsCount);
    this.text = PlayerPrefs.GetString(nameof (InfLevelsCount), "50");
    this.numberOnly = true;
  }

  public override void Update() => PlayerPrefs.SetString(nameof (InfLevelsCount), this.text);
}
