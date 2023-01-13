using System;
using System.Collections.Generic;
using Windows;

// Token: 0x02000004 RID: 4
public class ClientWindowManager
{
	// Token: 0x06000007 RID: 7 RVA: 0x0000220C File Offset: 0x0000040C
	public ClientWindowManager()
	{
		this.wnds.Add(new World());
		this.wnds.Add(new Debug());
		this.wnds.Add(new GUI());
		this.wnds.Add(new Player());
		this.wnds.Add(new Client());
		this.wnds.Add(new Options());
		this.wnds.Add(new Creator());
		this.wnds.Add(new Status());
		this.wnds.Add(new Speedhack());
		this.wnds.Add(new Display());
		this.wnds.Add(new Windows.Replay());
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
		foreach (Window window in this.wnds)
		{
			window.OnSceneChanged(buildIndex, sceneName);
		}
	}

	// Token: 0x04000005 RID: 5
	public List<Window> wnds = new List<Window>();
}
