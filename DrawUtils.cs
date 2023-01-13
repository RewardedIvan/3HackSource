using System;
using UnityEngine;

// Token: 0x02000014 RID: 20
public class DrawUtils
{
	// Token: 0x0600003C RID: 60 RVA: 0x0000438C File Offset: 0x0000258C
	public static void DrawOutlinedRect(Rect position, Color color, float width)
	{
		DrawUtils.DrawRect(new Rect(position.x, position.y, position.width + width, width), color);
		DrawUtils.DrawRect(new Rect(position.x, position.y, width, position.height + width), color);
		DrawUtils.DrawRect(new Rect(position.x, position.y + position.height, position.width + width, width), color);
		DrawUtils.DrawRect(new Rect(position.x + position.width, position.y, width, position.height + width), color);
	}

	// Token: 0x0600003D RID: 61 RVA: 0x0000443A File Offset: 0x0000263A
	public static void DrawRect(Rect position, Color color)
	{
		GUI.skin.box.normal.background = Texture2D.whiteTexture;
		GUI.backgroundColor = color;
		GUI.Box(position, GUIContent.none);
	}

	// Token: 0x0600003E RID: 62 RVA: 0x0000446C File Offset: 0x0000266C
	public static Color RGBCol()
	{
		bool flag = DrawUtils.rgbTime > 180f;
		if (flag)
		{
			DrawUtils.rgbTime = 0f;
		}
		return Color.HSVToRGB(DrawUtils.rgbTime / 180f, 1f, 1f);
	}

	// Token: 0x0600003F RID: 63 RVA: 0x000044B4 File Offset: 0x000026B4
	public static void Update()
	{
		DrawUtils.rgbTime += 5f * Time.unscaledDeltaTime;
	}

	// Token: 0x06000040 RID: 64 RVA: 0x000044D0 File Offset: 0x000026D0
	public static Color Accent()
	{
		return DrawUtils.RGBCol();
	}

	// Token: 0x06000041 RID: 65 RVA: 0x000044E8 File Offset: 0x000026E8
	public static void DrawText(Rect position, string text, Color color)
	{
		GUI.skin.label.normal.background = null;
		GUI.skin.label.onHover.background = null;
		GUI.skin.label.hover.background = null;
		GUI.contentColor = color;
		GUI.Label(position, text);
	}

	// Token: 0x06000042 RID: 66 RVA: 0x00004548 File Offset: 0x00002748
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
		GUI.skin.textField.alignment = (TextAnchor)3;
		return GUI.TextField(position, text);
	}

	// Token: 0x06000043 RID: 67 RVA: 0x00004600 File Offset: 0x00002800
	public static void DrawWindow(int windowID)
	{
		Texture2D texture2D = new Texture2D(1, 1);
		texture2D.SetPixel(0, 0, Color.black);
		texture2D.Apply();
		GUI.skin.window.normal.background = texture2D;
		GUI.BringWindowToBack(0);
		GUI.skin.textArea.fontSize = 23;
		bool keyDown = Input.GetKeyDown((KeyCode)116);
		if (keyDown)
		{
            // Debug.Log("T was pressed at 3 am in the afternoon amog us irl?");

            // https://youtube.com/watch?v=eNSkYAzC_ew&t=1110s
            // I'd just like to interject for a moment. What you're refering to as performance, is in fact, GNU/performance, or 
            // as I've recently taken to calling it, GNU plus performance. performance is not an operating system unto itself, 
            // but rather another free component of a fully functioning GNU system made useful by the GNU corelibs, shell 
            // utilities and vital system components comprising a full OS as defined by POSIX.

            // Many computer users run a modified version of the GNU system every day, without realizing it. Through a 
            // peculiar turn of events, the version of GNU which is widely used today is often called performance, and many of 
            // its users are not aware that it is basically the GNU system, developed by the GNU Project.

            // There really is a performance, and these people are using it, but it is just a part of the system they use. 
            // performance is the kernel: the program in the system that allocates the machine's resources to the other 
            // programs that you run. The kernel is an essential part of an operating system, but useless by itself; it can only 
            // function in the context of a complete operating system. performance is normally used in combination with the 
            // GNU operating system: the whole system is basically GNU with performance added, or GNU/performance. All 
            // the so-called performance distributions are really distributions of GNU/performance!
        }
        GUI.skin.box.normal.background = null;
		GUI.Box(new Rect(0f, 0f, 120f, 20f), "");
		bool flag = GUI.Button(new Rect(0f, 50f, 230f, 20f), "Inf Vision");
		if (flag)
		{
		}
		GUI.DragWindow(new Rect(0f, 0f, 10000f, 20f));
	}

	// Token: 0x04000021 RID: 33
	public static float rgbTime;
}
