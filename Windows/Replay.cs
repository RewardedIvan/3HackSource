using System;
using System.Collections.Generic;
using System.IO;
using Modules;
using UnityEngine;

namespace Windows
{
	// Token: 0x0200001A RID: 26
	public class Replay : Window
	{
		// Token: 0x06000059 RID: 89 RVA: 0x000053A8 File Offset: 0x000035A8
		public Replay()
		{
			this.rect.position = new Vector2(1230f, 20f);
			this.name = "Replay";
			Replay.selectedReplay = new SelectedReplay();
			Replay.replayMode = new ReplayMode();
			Replay.replaySave = new ReplaySave();
			this.modules.Add(Replay.selectedReplay);
			this.modules.Add(Replay.replayMode);
			this.modules.Add(Replay.replaySave);
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00005434 File Offset: 0x00003634
		public override void OnLateUpdate()
		{
			bool flag = !Replay.replayMode.rightOn;
			if (flag)
			{
				bool flag2 = UnityEngine.Object.FindObjectOfType<PlayerScript>() != null;
				if (flag2)
				{
					bool flag3 = !PauseMenuManager.paused;
					if (flag3)
					{
						Replay.frame++;
						Replay.inputCheck.Add(UnityEngine.Object.FindObjectOfType<PlayerScript>().jumpInput);
					}
				}
			}
			else
			{
				bool flag4 = UnityEngine.Object.FindObjectOfType<PlayerScript>() != null;
				if (flag4)
				{
					bool flag5 = !PauseMenuManager.paused;
					if (flag5)
					{
						Replay.frame++;
						bool flag6 = Replay.frame < Replay.inputCheck.Count - 1;
						if (flag6)
						{
							UnityEngine.Object.FindObjectOfType<PlayerScript>().jumpInput = Replay.inputCheck[Replay.frame];
						}
					}
				}
			}
		}

		// Token: 0x0600005B RID: 91 RVA: 0x000054FC File Offset: 0x000036FC
		public override void OnSceneChanged(int buildIndex, string sceneName)
		{
			Replay.frame = 0;
			Replay.scene = sceneName;
			bool flag = !Replay.replayMode.rightOn;
			if (flag)
			{
				bool flag2 = UnityEngine.Object.FindObjectOfType<PlayerScript>() != null;
				if (flag2)
				{
					Replay.inputCheck = new List<bool>();
				}
			}
			else
			{
				string text = Application.dataPath;
				bool flag3 = Application.platform == (RuntimePlatform)1;
				if (flag3)
				{
					text += "/../../";
				}
				else
				{
					bool flag4 = Application.platform == (RuntimePlatform)2;
					if (flag4)
					{
						text += "/../";
					}
				}
				text += "Replays/";
				text += Replay.selectedReplay.text;
				text += ".replay";
				Replay.inputCheck = new List<bool>();
				foreach (string text2 in File.ReadAllText(text).Split(";".ToCharArray()))
				{
					Replay.inputCheck.Add(bool.Parse(text2));
				}
				UnityEngine.Debug.Log(Replay.inputCheck);
			}
			Replay.frame = 0;
			Replay.scene = sceneName;
		}

		// Token: 0x0400002F RID: 47
		public static SelectedReplay selectedReplay;

		// Token: 0x04000030 RID: 48
		public static ReplayMode replayMode;

		// Token: 0x04000031 RID: 49
		public static ReplaySave replaySave;

		// Token: 0x04000032 RID: 50
		public static int frame;

		// Token: 0x04000033 RID: 51
		public static string scene;

		// Token: 0x04000034 RID: 52
		public static List<bool> inputCheck;
	}
}
