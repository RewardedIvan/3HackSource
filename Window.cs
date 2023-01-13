// Decompiled with JetBrains decompiler
// Type: Window
// Assembly: Hacks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7044930E-2DB6-478E-8870-F3754E75DBEE
// Assembly location: C:\Users\Rewar\Desktop\3Dash Windows v1.2\Mods\Hacks.dll

using System.Collections.Generic;
using UnityEngine;

public class Window
{
  public Rect rect = new Rect(50f, 20f, 230f * ModMain.scale, 50f * ModMain.scale);
  public Rect rectAct = new Rect(50f, 20f, 230f * ModMain.scale, 50f * ModMain.scale);
  public Vector2 offset;
  public bool dragging = false;
  public bool render = false;
  public string name = "Test Window :)";
  public List<Module> modules = new List<Module>();

  public virtual void Draw()
  {
    GUI.skin.label.fontSize = Mathf.RoundToInt(23f * ModMain.scale);
    if (!ModMain.showClickGUI)
      return;
    this.rectAct = new Rect(((Rect) ref this.rect).x, ((Rect) ref this.rect).y, 230f * ModMain.scale, 50f * ModMain.scale);
    DrawUtils.DrawRect(this.rect, DrawUtils.Accent());
    GUI.skin.label.alignment = (TextAnchor) 4;
    DrawUtils.DrawText(this.rect, this.name, Color.white);
    DrawUtils.DrawRect(this.AddRect(this.rect, new Rect(0.0f, 50f * ModMain.scale, 0.0f, 50f * ModMain.scale * (float) this.modules.Count)), new Color(0.141176477f, 0.141176477f, 0.141176477f));
    Vector2 vector2;
    // ISSUE: explicit constructor call
    ((Vector2) ref vector2).\u002Ector(Input.mousePosition.x, (float) Screen.height - Input.mousePosition.y);
    int num = 0;
    foreach (Module module in this.modules)
    {
      ++num;
      module.Draw(this.AddRect(this.rect, new Rect(0.0f, 50f * (float) num * ModMain.scale, 0.0f, 0.0f)), this);
    }
    this.rectAct = this.AddRect(this.rectAct, new Rect(0.0f, 0.0f, 0.0f, 50f * ModMain.scale * (float) num));
  }

  public virtual void OnUpdate()
  {
  }

  public virtual void OnLateUpdate()
  {
  }

  public void Update()
  {
    foreach (Module module in this.modules)
    {
      if (Input.GetKeyDown(module.keybind))
      {
        module.enabled = !module.enabled;
        Window window = this;
        ModMain.cwm.wnds.Remove(this);
        ModMain.cwm.wnds.Insert(ModMain.cwm.wnds.Count, window);
      }
      module.Update();
      foreach (Module setting in module.settings)
        setting.Update();
    }
    Vector2 vector2;
    // ISSUE: explicit constructor call
    ((Vector2) ref vector2).\u002Ector(Input.mousePosition.x, (float) Screen.height - Input.mousePosition.y);
    if (ModMain.showClickGUI)
    {
      if (!Input.GetMouseButton(0))
        this.dragging = false;
      float timeScale = Time.timeScale;
      Time.timeScale = 0.1f;
      if ((double) vector2.x > (double) ((Rect) ref this.rect).position.x && (double) vector2.y > (double) ((Rect) ref this.rect).position.y && (double) vector2.x < (double) ((Rect) ref this.rect).position.x + (double) ((Rect) ref this.rect).width && (double) vector2.y < (double) ((Rect) ref this.rect).position.y + (double) ((Rect) ref this.rect).height && Input.GetMouseButtonDown(0))
      {
        this.offset = Vector2.op_Subtraction(((Rect) ref this.rect).position, vector2);
        this.dragging = true;
        Window window = this;
        ModMain.cwm.wnds.Remove(this);
        ModMain.cwm.wnds.Insert(ModMain.cwm.wnds.Count, window);
      }
      if (this.dragging)
        ((Rect) ref this.rect).position = Vector2.op_Addition(vector2, this.offset);
      if ((double) ((Rect) ref this.rect).x < 0.0)
        ((Rect) ref this.rect).x = 0.0f;
      if ((double) ((Rect) ref this.rect).y < 0.0)
        ((Rect) ref this.rect).y = 0.0f;
      if ((double) ((Rect) ref this.rect).x > (double) Screen.width - (double) ((Rect) ref this.rect).width)
        ((Rect) ref this.rect).x = (float) Screen.width - ((Rect) ref this.rect).width;
      if ((double) ((Rect) ref this.rect).y + (double) ((Rect) ref this.rectAct).height > (double) Screen.height)
        ((Rect) ref this.rect).y = (float) Screen.height - ((Rect) ref this.rectAct).height;
      Time.timeScale = timeScale;
    }
    this.OnUpdate();
  }

  public Rect AddRect(Rect rect1, Rect rect2) => new Rect(((Rect) ref rect1).x + ((Rect) ref rect2).x, ((Rect) ref rect1).y + ((Rect) ref rect2).y, ((Rect) ref rect1).width + ((Rect) ref rect2).width, ((Rect) ref rect1).height + ((Rect) ref rect2).height);

  public virtual void OnSceneChanged(int buildIndex, string sceneName)
  {
  }
}
