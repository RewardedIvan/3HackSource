using System;
using System.Collections.Generic;
using Windows;
using UnityEngine;
using System.IO;

// Token: 0x02000004 RID: 4
public class ClientWindowManager
{
	// Token: 0x06000007 RID: 7 RVA: 0x0000220C File Offset: 0x0000040C
	public ClientWindowManager()
	{
		this.wnds.Add(new Windows.Debug());
		this.wnds.Add(new World());
		this.wnds.Add(new Windows.GUI());
        this.wnds.Add(new Windows.Windows());
        this.wnds.Add(new Player());
		this.wnds.Add(new Client());
		this.wnds.Add(new Options());
		this.wnds.Add(new Creator());
		this.wnds.Add(new Status());
		this.wnds.Add(new Speedhack());
		this.wnds.Add(new Windows.Display());
		this.wnds.Add(new Windows.Replay());
		this.wnds.Add(new Server());
        this.wnds.Add(new Jump());

        string text = Application.dataPath;
        if (Application.platform == RuntimePlatform.OSXPlayer)
        {
            text += "/../../Assets/3H+logo.png";
        }
        else if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            text += "/../Assets/3H+logo.png";
        }
        else
        {
            text += "Assets/3H+logo.png";
        }
        if (File.Exists(text))
        {
            this.h3pluslogo = new Texture2D(512, 512, TextureFormat.ARGB32, false);
            h3pluslogo.LoadImage(File.ReadAllBytes(text));
        }
    }

	// Token: 0x06000008 RID: 8 RVA: 0x000022E8 File Offset: 0x000004E8
	public void Update()
	{
		try
		{
			foreach (Window window in this.wnds)
			{
				window.Update();
			}
		}
        catch (Exception)
        {
            // At least it doesnt flood your console now.
        }
    }

	// Token: 0x06000009 RID: 9 RVA: 0x00002340 File Offset: 0x00000540
	public void Draw()
	{
		try
		{
            if (ModMain.showClickGUI)
                UnityEngine.GUI.DrawTexture(new Rect(Screen.width - (h3pluslogo.width / 2), 0, h3pluslogo.width / 2, h3pluslogo.height / 2), h3pluslogo, ScaleMode.ScaleAndCrop);
        }
        catch (Exception)
        { // At least it doesnt flood your console now.
        }
        try
		{

            foreach (Window window in this.wnds)
            {
                foreach (Module module in window.modules)
                {
                    module.OnDraw();
                }
                bool render = window.render;
                if (render)
                {
                    window.Draw();
                }
            }
        }
		catch (Exception)
		{
			// At least it doesnt flood your console now.
		}
	}

	// Token: 0x0600000A RID: 10 RVA: 0x000023EC File Offset: 0x000005EC
	public void LateUpdate()
	{
		foreach (Window window in this.wnds)
		{
			window.OnLateUpdate();
		}
	}

	// Token: 0x0600000B RID: 11 RVA: 0x00002444 File Offset: 0x00000644
	public void OnSceneChanged(int buildIndex, string sceneName)
	{
		try
		{
            foreach (Window window in this.wnds)
            {
                window.OnSceneChanged(buildIndex, sceneName);
            }
        }
		catch (Exception)
		{
            // At least it doesnt flood your console now.
        }
    }

	// Token: 0x04000005 RID: 5
	public List<Window> wnds = new List<Window>();
    Texture2D h3pluslogo = null;
    public int wndDragged = -1;
    public int wndDescription = -1;
}
