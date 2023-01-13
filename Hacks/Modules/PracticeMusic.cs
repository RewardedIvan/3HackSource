using System;
using System.Linq.Expressions;
using System.Reflection;
using HarmonyLib;
using UnityEngine;

namespace Modules
{
	// Token: 0x0200004D RID: 77
	[Serializable]
	internal class PracticeMusic : global::Module
	{
		// Token: 0x060000F2 RID: 242 RVA: 0x0000C3E8 File Offset: 0x0000A5E8
		public PracticeMusic()
		{
			this.name = "Practice Music";
			this.description = "Plays the normal music in practice mode";
			HarmonyLib.Harmony harmony = new HarmonyLib.Harmony("com.Explodingbill.Music");
			PracticeMusic.instance = this;
			MethodInfo methodInfo = AccessTools.Method(typeof(PauseMenuManager), "StartPractice", null, null);
            var prefix = new HarmonyMethod(typeof(PracticeMusic).GetMethod("StartPractice"));
            harmony.Patch(original: methodInfo, prefix: prefix);
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x0000C478 File Offset: 0x0000A678
		public static bool StartPractice()
		{
			bool enabled = PracticeMusic.instance.enabled;
			bool flag;
			if (enabled)
			{
				PauseMenuManager pauseMenuManager = UnityEngine.Object.FindObjectOfType<PauseMenuManager>();
				PauseMenuManager.inPracticeMode = true;
				PauseMenuManager.DestroyAllCheckpoints();
				pauseMenuManager.Resume(true);
				flag = false;
			}
			else
			{
				flag = true;
			}
			return flag;
		}

		// Token: 0x04000078 RID: 120
		public static global::Module instance;
	}
}
