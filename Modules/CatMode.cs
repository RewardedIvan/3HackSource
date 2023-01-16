using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace Modules
{
	// Token: 0x02000039 RID: 57
	public class CatMode : ModuleType.Button
	{
		// Token: 0x060000C6 RID: 198 RVA: 0x0000AB2C File Offset: 0x00008D2C
		public CatMode()
		{
			this.name = "Cat Mode";
			this.description = "Replaces every (2d) texture with Cats. Unreversable unless you restart your game.";
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x0000ABF8 File Offset: 0x00008DF8
		public override void OnClick()
		{
            string text = Application.dataPath;
            if (Application.platform == RuntimePlatform.OSXPlayer)
            {
                text += "/../../Assets/Cat.png";
            }
            else if(Application.platform == RuntimePlatform.WindowsPlayer)
            {
                text += "/../Assets/Cat.png";
            } else
			{
				text += "Assets/Cat.png";
			}
            this.texture = new Texture2D(10, 10);
            this.texture.LoadRawTextureData(File.ReadAllBytes(text));
            this.texture.Apply(true, false);
            Texture2D texture2D = this.texture;
			foreach (Image image in UnityEngine.Object.FindObjectsOfType<Image>())
			{
				if (image.sprite.texture != this.texture)
				{
					image.sprite = Sprite.Create(this.texture, new Rect(0f, 0f, (float)this.texture.width, (float)this.texture.height), Vector2.one * 0.5f);
				}
			}
		}

        // Token: 0x04000070 RID: 112
        private Texture2D texture;
	}
}
