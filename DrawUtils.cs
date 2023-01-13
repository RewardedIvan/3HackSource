// Decompiled with JetBrains decompiler
// Type: DrawUtils
// Assembly: Hacks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7044930E-2DB6-478E-8870-F3754E75DBEE
// Assembly location: C:\Users\Rewar\Desktop\3Dash Windows v1.2\Mods\Hacks.dll

using UnityEngine;

public class DrawUtils
{
  public static float rgbTime;

  public static void DrawOutlinedRect(Rect position, Color color, float width)
  {
    DrawUtils.DrawRect(new Rect(((Rect) ref position).x, ((Rect) ref position).y, ((Rect) ref position).width + width, width), color);
    DrawUtils.DrawRect(new Rect(((Rect) ref position).x, ((Rect) ref position).y, width, ((Rect) ref position).height + width), color);
    DrawUtils.DrawRect(new Rect(((Rect) ref position).x, ((Rect) ref position).y + ((Rect) ref position).height, ((Rect) ref position).width + width, width), color);
    DrawUtils.DrawRect(new Rect(((Rect) ref position).x + ((Rect) ref position).width, ((Rect) ref position).y, width, ((Rect) ref position).height + width), color);
  }

  public static void DrawRect(Rect position, Color color)
  {
    GUI.skin.box.normal.background = Texture2D.whiteTexture;
    GUI.backgroundColor = color;
    GUI.Box(position, GUIContent.none);
  }

  public static Color RGBCol()
  {
    if ((double) DrawUtils.rgbTime > 180.0)
      DrawUtils.rgbTime = 0.0f;
    return Color.HSVToRGB(DrawUtils.rgbTime / 180f, 1f, 1f);
  }

  public static void Update() => DrawUtils.rgbTime += 5f * Time.unscaledDeltaTime;

  public static Color Accent() => DrawUtils.RGBCol();

  public static void DrawText(Rect position, string text, Color color)
  {
    GUI.skin.label.normal.background = (Texture2D) null;
    GUI.skin.label.onHover.background = (Texture2D) null;
    GUI.skin.label.hover.background = (Texture2D) null;
    GUI.contentColor = color;
    GUI.Label(position, text);
  }

  public static string DrawTextField(Rect position, string text, Color color)
  {
    Texture2D texture2D = new Texture2D(1, 1);
    texture2D.SetPixel(0, 0, color);
    texture2D.Apply();
    GUI.skin.textField.normal.background = texture2D;
    GUI.skin.textField.hover.background = texture2D;
    GUI.skin.textField.active.background = texture2D;
    GUI.skin.textField.focused.background = texture2D;
    GUI.skin.textField.onHover.background = texture2D;
    GUI.contentColor = color;
    GUI.skin.textField.alignment = (TextAnchor) 3;
    return GUI.TextField(position, text);
  }

  public static void DrawWindow(int windowID)
  {
    Texture2D texture2D = new Texture2D(1, 1);
    texture2D.SetPixel(0, 0, Color.black);
    texture2D.Apply();
    GUI.skin.window.normal.background = texture2D;
    GUI.BringWindowToBack(0);
    GUI.skin.textArea.fontSize = 23;
    if (Input.GetKeyDown((KeyCode) 116))
      Debug.Log((object) "T was pressed at 3 am in the afternoon amog us irl?");
    GUI.skin.box.normal.background = (Texture2D) null;
    GUI.Box(new Rect(0.0f, 0.0f, 120f, 20f), "");
    if (!GUI.Button(new Rect(0.0f, 50f, 230f, 20f), "Inf Vision"))
      ;
    GUI.DragWindow(new Rect(0.0f, 0.0f, 10000f, 20f));
  }
}
