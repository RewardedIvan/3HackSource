// Decompiled with JetBrains decompiler
// Type: ClientWindowManager
// Assembly: Hacks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7044930E-2DB6-478E-8870-F3754E75DBEE
// Assembly location: C:\Users\Rewar\Desktop\3Dash Windows v1.2\Mods\Hacks.dll

using System.Collections.Generic;
using Windows;

public class ClientWindowManager
{
  public List<Window> wnds = new List<Window>();

  public ClientWindowManager()
  {
    this.wnds.Add((Window) new World());
    this.wnds.Add((Window) new Debug());
    this.wnds.Add((Window) new GUI());
    this.wnds.Add((Window) new Player());
    this.wnds.Add((Window) new Client());
    this.wnds.Add((Window) new Options());
    this.wnds.Add((Window) new Creator());
    this.wnds.Add((Window) new Status());
    this.wnds.Add((Window) new Speedhack());
    this.wnds.Add((Window) new Display());
    this.wnds.Add((Window) new Windows.Replay());
  }

  public void Update()
  {
    foreach (Window wnd in this.wnds)
      wnd.Update();
  }

  public void Draw()
  {
    foreach (Window wnd in this.wnds)
    {
      foreach (Module module in wnd.modules)
        module.OnDraw();
      if (wnd.render)
        wnd.Draw();
    }
  }

  public void LateUpdate()
  {
    foreach (Window wnd in this.wnds)
      wnd.OnLateUpdate();
  }

  public void OnSceneChanged(int buildIndex, string sceneName)
  {
    foreach (Window wnd in this.wnds)
      wnd.OnSceneChanged(buildIndex, sceneName);
  }
}
