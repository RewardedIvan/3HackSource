// Decompiled with JetBrains decompiler
// Type: SpeedhackButton
// Assembly: Hacks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7044930E-2DB6-478E-8870-F3754E75DBEE
// Assembly location: C:\Users\Rewar\Desktop\3Dash Windows v1.2\Mods\Hacks.dll

using UnityEngine;

public class SpeedhackButton : Module
{
  public static bool isEnabled;

  public SpeedhackButton() => this.name = "Enabled";

  public override void Update()
  {
    SpeedhackButton.isEnabled = this.enabled;
    if (this.enabled)
    {
      if (PauseMenuManager.paused)
        Time.timeScale = 0.0f;
      else
        Time.timeScale = float.Parse(PlayerPrefs.GetString("SpeedhackValue", "1"));
    }
    else
      Time.timeScale = !PauseMenuManager.paused ? 1f : 0.0f;
  }
}
