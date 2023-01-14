using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000017 RID: 23
public class Window
{
    // Token: 0x0600004E RID: 78 RVA: 0x00004CDC File Offset: 0x00002EDC
    public virtual void Draw()
    {
        GUI.skin.label.fontSize = Mathf.RoundToInt(23f * ModMain.scale);
        bool flag = !ModMain.showClickGUI;
        if (!flag)
        {
            this.rectAct = new Rect(this.rect.x, this.rect.y, 230f * ModMain.scale, 50f * ModMain.scale);
            DrawUtils.DrawRect(this.rect, DrawUtils.Accent());
            GUI.skin.label.alignment = (TextAnchor)4;
            DrawUtils.DrawText(this.rect, this.name, Color.white);
            DrawUtils.DrawRect(this.AddRect(this.rect, new Rect(0f, 50f * ModMain.scale, 0f, ModMain.spacing * ModMain.scale * (float)this.modules.Count)), new Color(0.14117648f, 0.14117648f, 0.14117648f));
            Vector2 vector = new Vector2(Input.mousePosition.x, (float)Screen.height - Input.mousePosition.y);
            int num = 0;
            foreach (Module module in this.modules)
            {
                num++;
                module.Draw(this.AddRect(this.rect, new Rect(0f, ModMain.spacing * (float)num * ModMain.scale, 0f, 0f)), this);
            }
            this.rectAct = this.AddRect(this.rectAct, new Rect(0f, 0f, 0f, 50f * ModMain.scale * (float)num));
        }
    }

    // Token: 0x0600004F RID: 79 RVA: 0x00004EBC File Offset: 0x000030BC
    public virtual void OnUpdate()
	{
	}

	// Token: 0x06000050 RID: 80 RVA: 0x00004EBF File Offset: 0x000030BF
	public virtual void OnLateUpdate()
	{
	}

    // Token: 0x06000051 RID: 81 RVA: 0x00004EC4 File Offset: 0x000030C4
    public void Update()
    {
        foreach (Module module in this.modules)
        {
            bool keyDown = Input.GetKeyDown(module.keybind);
            if (keyDown)
            {
                module.enabled = !module.enabled;
                ModMain.cwm.wnds.Remove(this);
                ModMain.cwm.wnds.Insert(ModMain.cwm.wnds.Count, this);
            }
            module.Update();
            foreach (ModuleSetting moduleSetting in module.settings)
            {
                moduleSetting.Update();
            }
        }
        Vector2 vector = new Vector2(Input.mousePosition.x, (float)Screen.height - Input.mousePosition.y);
        if (ModMain.showClickGUI)
        {
            bool flag = !Input.GetMouseButton(0);
            if (flag)
            {
                this.dragging = false;
            }
            float timeScale = Time.timeScale;
            Time.timeScale = 0.1f;
            if (vector.x > this.rect.position.x && vector.y > this.rect.position.y && vector.x < this.rect.position.x + this.rect.width && vector.y < this.rect.position.y + this.rect.height)
            {
                bool mouseButtonDown = Input.GetMouseButtonDown(0);
                if (mouseButtonDown && this.render)
                {
                    this.offset = this.rect.position - vector;
                    this.dragging = true;
                    // just why??
                    //ModMain.cwm.wnds.Remove(this);
                    //ModMain.cwm.wnds.Insert(ModMain.cwm.wnds.Count, this);
                }
            }
            if (this.dragging)
            {
                this.rect.position = vector + this.offset;
            }
            if (this.rect.x < 0f)
            {
                this.rect.x = 0f;
            }
            if (this.rect.y < 0f)
            {
                this.rect.y = 0f;
            }
            if (this.rect.x > (float)Screen.width - this.rect.width)
            {
                this.rect.x = (float)Screen.width - this.rect.width;
            }
            if (this.rect.y + this.rectAct.height > (float)Screen.height)
            {
                this.rect.y = (float)Screen.height - this.rectAct.height;
            }
            Time.timeScale = timeScale;
        }
        this.OnUpdate();
    }

    // Token: 0x06000052 RID: 82 RVA: 0x00005218 File Offset: 0x00003418
    public Rect AddRect(Rect rect1, Rect rect2)
	{
		return new Rect(rect1.x + rect2.x, rect1.y + rect2.y, rect1.width + rect2.width, rect1.height + rect2.height);
	}

	// Token: 0x06000053 RID: 83 RVA: 0x0000526B File Offset: 0x0000346B
	public virtual void OnSceneChanged(int buildIndex, string sceneName)
	{
	}

	// Token: 0x04000028 RID: 40
	public Rect rect = new Rect(50f, 20f, 230f * ModMain.scale, 50f * ModMain.scale);

	// Token: 0x04000029 RID: 41
	public Rect rectAct = new Rect(50f, 20f, 230f * ModMain.scale, 50f * ModMain.scale);

	// Token: 0x0400002A RID: 42
	public Vector2 offset;

	// Token: 0x0400002B RID: 43
	public bool dragging = false;

	// Token: 0x0400002C RID: 44
	public bool render = false;

	// Token: 0x0400002D RID: 45
	public string name = "Test Window :)"; // hi hello hi

	// Token: 0x0400002E RID: 46
	public List<Module> modules = new List<Module>();
}
