// Decompiled with JetBrains decompiler
// Type: SpeedhackMusic
// Assembly: Hacks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7044930E-2DB6-478E-8870-F3754E75DBEE
// Assembly location: C:\Users\Rewar\Desktop\3Dash Windows v1.2\Mods\Hacks.dll

using UnityEngine;

public class SpeedhackMusic : Module
{
  public SpeedhackMusic() => this.name = "Speed Music";

  public override void Update()
  {
    if (this.enabled && SpeedhackButton.isEnabled)
    {
      foreach (AudioSource audioSource in Object.FindObjectsOfType<AudioSource>())
        audioSource.pitch = float.Parse(PlayerPrefs.GetString("SpeedhackValue", "1"));
    }
    else
    {
      foreach (AudioSource audioSource in Object.FindObjectsOfType<AudioSource>())
        audioSource.pitch = 1f;
    }
  }
}
