using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Windows
{
	// Token: 0x0200001D RID: 29
	public class Debug : Window
	{
		// Token: 0x0600005E RID: 94 RVA: 0x000056F8 File Offset: 0x000038F8
		public Debug()
		{
			this.rect.position = new Vector2(550f, 20f);
			this.rect.width = this.rect.width + 20f;
			this.name = "Debug";
		}

        // Token: 0x0600005F RID: 95 RVA: 0x0000574C File Offset: 0x0000394C
        public override void Draw()
		{
			UnityEngine.GUI.skin.label.alignment = (TextAnchor)4;
            UnityEngine.GUI.skin.label.fontSize = Mathf.RoundToInt(23f * ModMain.scale);
			this.rectAct = new Rect(this.rect.x, this.rect.y, 230f * ModMain.scale, 50f * ModMain.scale);
			float num = (float)((this.rect.y == 0f) ? 28 : 0);
			if (ModMain.showClickGUI)
			{
				DrawUtils.DrawRect(this.rect, DrawUtils.Accent());
                UnityEngine.GUI.skin.label.alignment = (TextAnchor)4;
				DrawUtils.DrawText(this.rect, this.name, Color.white);
				num = 0f;
			}
            Vector2 vector = new Vector2(Input.mousePosition.x, (float)Screen.height - Input.mousePosition.y);
            DrawUtils.DrawRect(base.AddRect(this.rect, new Rect(0f, 50f * ModMain.scale - num, 0f, 50f * ModMain.scale * 3f)), new Color(0.14117648f, 0.14117648f, 0.14117648f, 0.25f));
			UnityEngine.GUI.skin.label.alignment = (TextAnchor)3;
			DrawUtils.DrawText(base.AddRect(this.rect, new Rect(0f, 50f * ModMain.scale - num, 20f, 0f)), "Frame Time: " + Time.unscaledDeltaTime.ToString().Substring(0, 5) + "ms", Color.white);
			DrawUtils.DrawText(base.AddRect(this.rect, new Rect(0f, 80f * ModMain.scale - num, 0f, 0f)), "FPS: " + ((int)(1f / Time.unscaledDeltaTime)).ToString(), Color.white);
			DrawUtils.DrawText(base.AddRect(this.rect, new Rect(0f, 110f * ModMain.scale - num, 0f, 0f)), "Objects: " + UnityEngine.Object.FindObjectsOfType<Transform>().Length.ToString(), Color.white);
			DrawUtils.DrawText(base.AddRect(this.rect, new Rect(0f, 140f * ModMain.scale - num, 0f, 0f)), "Scenes: " + SceneManager.sceneCountInBuildSettings, Color.white);
            this.rectAct = base.AddRect(this.rectAct, new Rect(0f, 0f, 0f, 50f * ModMain.scale * 4f));
		}
	}
}
