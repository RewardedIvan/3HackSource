using System;
using ModuleType;
using UnityEngine;

namespace Modules
{
	// Token: 0x02000040 RID: 64
	public class ResolutionApply : Button
	{
		// Token: 0x060000D6 RID: 214 RVA: 0x0000BB78 File Offset: 0x00009D78
		public ResolutionApply()
		{
			this.name = "Apply";
			this.canClick = true;
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x0000BB94 File Offset: 0x00009D94
		public override void OnClick()
		{
			bool isFullscreen = Fullscreen.isFullscreen;
			if (isFullscreen)
			{
				Screen.SetResolution(Display.displays[0].systemWidth, Display.displays[0].systemHeight, true);
			}
			else
			{
				Resolution resolution = default(Resolution);
				resolution.width = int.Parse(PlayerPrefs.GetString("Res").ToUpper().Split("X".ToCharArray())[0]);
				resolution.height = int.Parse(PlayerPrefs.GetString("Res").ToUpper().Split("X".ToCharArray())[1]);
				Screen.SetResolution(resolution.width, resolution.height, this.enabled);
			}
			this.canClick = true;
		}
	}
}
