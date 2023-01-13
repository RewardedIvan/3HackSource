using System;
using System.Linq.Expressions;
using System.Reflection;
using HarmonyLib;
using Modules;
using UnityEngine;

// Token: 0x0200000F RID: 15
public class NoclipHook
{
	// Token: 0x0600001F RID: 31 RVA: 0x00002E40 File Offset: 0x00001040
	public static void DoPatching()
	{
		// This is a mess
		HarmonyLib.Harmony harmony = new HarmonyLib.Harmony("com.Explodingbill.NoclipPatch");
		
		MethodInfo methodInfo = AccessTools.Method(typeof(PlayerScript), "Die", null, null);
        var postfix = new HarmonyMethod(typeof(NoclipHook).GetMethod("MyPostfix"));
        harmony.Patch(original: methodInfo, postfix: postfix);

        MethodInfo methodInfo2 = AccessTools.Method(typeof(PlayerScript), "OnCollisionEnter", new Type[] { typeof(Collision) }, null);
        var postfix2 = new HarmonyMethod(typeof(NoclipHook).GetMethod("OnCollisionEnter"));
        harmony.Patch(original: methodInfo2, postfix: postfix2);

		// This is defo the problem
        MethodInfo methodInfo3 = AccessTools.Method(typeof(PlayerScript), "Win", null, null);
        var prefix2 = new HarmonyMethod(typeof(NoclipHook).GetMethod("OnWin"));
        harmony.Patch(original: methodInfo3, prefix: prefix2);
    }

	// Token: 0x06000020 RID: 32 RVA: 0x00002FE0 File Offset: 0x000011E0
	public static bool OnWin()
	{
		PlayerScript playerScript = UnityEngine.Object.FindObjectOfType<PlayerScript>();
		bool flag = !playerScript.noDeath || Noclip.isNoclipEnabled;
		if (flag)
		{
			playerScript.dead = true;
			playerScript.transform.parent.gameObject.SetActive(false);
			UnityEngine.Object.Instantiate<GameObject>(playerScript.WinFX, playerScript.transform.position, playerScript.transform.rotation);
			UnityEngine.Object.Instantiate<GameObject>(playerScript.cam, playerScript.cam.transform.position, playerScript.cam.transform.rotation);
		}
		return false;
	}

	// Token: 0x06000022 RID: 34 RVA: 0x0000307E File Offset: 0x0000127E
	public static void OnSceneChanged()
	{
		NoclipHook.deathCount = 0;
	}

	// Token: 0x06000023 RID: 35 RVA: 0x00003087 File Offset: 0x00001287
	public static void MyPostfix()
	{
		NoclipHook.deathCount++;
	}

	// Token: 0x06000024 RID: 36 RVA: 0x00003098 File Offset: 0x00001298
	public static void OnCollisionEnter(Collision other)
	{
		bool isEnabled = BetterNoclip.isEnabled;
		if (isEnabled)
		{
			bool flag = other.gameObject.tag == "Hazard";
			if (flag)
			{
				UnityEngine.Object.Destroy(other.collider);
			}
		}
	}

	// Token: 0x0400000C RID: 12
	public static int deathCount;
}
