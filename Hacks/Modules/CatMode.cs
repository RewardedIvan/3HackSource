using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace Modules
{
	// Token: 0x02000039 RID: 57
	public class CatMode : Module
	{
		// Token: 0x060000C6 RID: 198 RVA: 0x0000AB2C File Offset: 0x00008D2C
		public CatMode()
		{
			this.name = "Cat Mode";
			this.description = "Replaces every (2d) texture with Cats. Unreversable unless you restart your game.";
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x0000ABF8 File Offset: 0x00008DF8
		public override void Update()
		{
			if (this.enabled) {
                string text = Application.dataPath;
                bool flag = Application.platform == (RuntimePlatform)1;
                if (flag)
                {
                    text += "/../../";
                }
                else
                {
                    bool flag2 = Application.platform == (RuntimePlatform)2;
                    if (flag2)
                    {
                        text += "/../";
                    }
                }
                text += "Cat.png";
                this.texture = new Texture2D(10, 10);
                this.texture.LoadRawTextureData(File.ReadAllBytes(text));
                this.texture.Apply(true, false);
                Texture2D texture2D = this.texture;
            }
			foreach (Image image in UnityEngine.Object.FindObjectsOfType<Image>())
			{
				bool flag = image.sprite.texture != this.texture;
				if (flag)
				{
					image.sprite = Sprite.Create(this.texture, new Rect(0f, 0f, (float)this.texture.width, (float)this.texture.height), Vector2.one * 0.5f);
				}
			}
		}

        // Token: 0x04000070 RID: 112
        private Texture2D texture;
	}
}
