// Decompiled with JetBrains decompiler
// Type: MessageInput
// Assembly: Hacks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7044930E-2DB6-478E-8870-F3754E75DBEE
// Assembly location: C:\Users\Rewar\Desktop\3Dash Windows v1.2\Mods\Hacks.dll

using ModuleType;
using UnityEngine;

public class MessageInput : TextInput
{
  public MessageInput() => this.text = PlayerPrefs.GetString("MessageText", "Type a message here");

  public override void Update() => PlayerPrefs.SetString("MessageText", this.text);
}
