using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using HarmonyLib;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

// Token: 0x02000002 RID: 2
public class AttemptCounter
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	public static void Initialize()
	{
		SceneManager.activeSceneChanged += new UnityAction<Scene, Scene>(AttemptCounter.SceneManager_activeSceneChanged);
		HarmonyLib.Harmony harmony = new HarmonyLib.Harmony("com.Explodingbill.Attempt");
		MethodInfo methodInfo = AccessTools.Method(typeof(PlayerScript), "Awake", null, null);
		var postfix = new HarmonyMethod(typeof(AttemptCounter).GetMethod("MyPostfix"));

        harmony.Patch(original: methodInfo, postfix: postfix);
	}

	// Token: 0x06000002 RID: 2 RVA: 0x000020CE File Offset: 0x000002CE
	public static void MyPostfix()
	{
		AttemptCounter.attempts++;
	}

	// Token: 0x06000003 RID: 3 RVA: 0x000020E0 File Offset: 0x000002E0
	private static void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
	{
		if (UnityEngine.Object.FindObjectOfType<PlayerScript>() == null)
		{
			AttemptCounter.attempts = 0;
		}
	}

	// Token: 0x04000001 RID: 1
	public static int attempts;
}
