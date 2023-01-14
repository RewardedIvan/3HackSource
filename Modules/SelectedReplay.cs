using System;
using System.IO;
using ModuleType;
using UnityEngine;

namespace Modules
{
	// Token: 0x02000042 RID: 66
	public class SelectedReplay : TextDropdown
	{
		// Token: 0x060000DA RID: 218 RVA: 0x0000BC94 File Offset: 0x00009E94
		public SelectedReplay()
		{
			this.text = PlayerPrefs.GetString("selectedReplay", "");
			this.name = "selectedReplay";
			string text = Application.dataPath;
			if (Application.platform == (RuntimePlatform)1)
			{
				text += "/../../";
			}
			else
			{
				if (Application.platform == (RuntimePlatform)1)
				{
					text += "/../";
				}
			}
			text += "Replays/";
			bool flag3 = !Directory.Exists(text);
			if (flag3)
			{
				Directory.CreateDirectory(text);
			}
			foreach (string text2 in Directory.GetFiles(text))
			{
				// Debug.Log(Path.GetExtension(text2));
				bool flag4 = Path.GetExtension(text2) == ".replay";
				if (flag4)
				{
					this.content.Add(Path.GetFileName(text2).Replace(".replay", ""));
				}
			}
		}

		// Token: 0x060000DB RID: 219 RVA: 0x0000BD94 File Offset: 0x00009F94
		public override void Update()
		{
			PlayerPrefs.SetString("selectedReplay", this.text);
		}
	}
}
