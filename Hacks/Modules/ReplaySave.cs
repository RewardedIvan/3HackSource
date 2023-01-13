using System;
using System.IO;
using ModuleType;
using UnityEngine;
using Windows;

namespace Modules
{
	// Token: 0x0200003F RID: 63
	public class ReplaySave : Button
	{
		// Token: 0x060000D4 RID: 212 RVA: 0x0000BA76 File Offset: 0x00009C76
		public ReplaySave()
		{
			this.name = "Save";
			this.canClick = true;
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x0000BA94 File Offset: 0x00009C94
		public override void OnClick()
		{
			this.canClick = true;
			string text = "";
			foreach (bool flag in Windows.Replay.inputCheck)
			{
				text = text + flag.ToString() + ";";
			}
			string text2 = Application.dataPath;
			if (Application.platform == (RuntimePlatform)1)
			{
				text2 += "/../../";
			}
			else
			{
				if (Application.platform == (RuntimePlatform)2)
				{
					text2 += "/../";
				}
			}
			text2 += "Replays/";
			text2 += Windows.Replay.selectedReplay.text;
			text2 += ".replay";
			File.WriteAllText(text2, text);
		}
	}
}
