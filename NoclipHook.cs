// Decompiled with JetBrains decompiler
// Type: NoclipHook
// Assembly: Hacks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7044930E-2DB6-478E-8870-F3754E75DBEE
// Assembly location: C:\Users\Rewar\Desktop\3Dash Windows v1.2\Mods\Hacks.dll

using HarmonyLib;
using Modules;
using System;
using System.Linq.Expressions;
using System.Reflection;
using UnityEngine;

public class NoclipHook
{
  public static int deathCount;

  public static void DoPatching()
  {
    Harmony harmony = new Harmony("com.Explodingbill.NoclipPatch");
    MethodInfo methodInfo1 = AccessTools.Method(typeof (PlayerScript), "Die", (Type[]) null, (Type[]) null);
    // ISSUE: method reference
    MethodInfo methodInfo2 = SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>((Expression) Expression.Call((Expression) null, (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (NoclipHook.MyPrefix)), Array.Empty<Expression>())));
    // ISSUE: method reference
    MethodInfo methodInfo3 = SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>((Expression) Expression.Call((Expression) null, (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (NoclipHook.MyPostfix)), Array.Empty<Expression>())));
    harmony.Patch((MethodBase) methodInfo1, new HarmonyMethod(methodInfo2), new HarmonyMethod(methodInfo3), (HarmonyMethod) null, (HarmonyMethod) null, (HarmonyMethod) null);
    MethodInfo methodInfo4 = AccessTools.Method(typeof (PlayerScript), "OnCollisionEnter", new Type[1]
    {
      typeof (Collision)
    }, (Type[]) null);
    // ISSUE: method reference
    SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>((Expression) Expression.Call((Expression) null, (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (NoclipHook.MyPrefix)), Array.Empty<Expression>())));
    MethodInfo methodInfo5 = SymbolExtensions.GetMethodInfo((Expression<Action>) (() => NoclipHook.OnCollisionEnter(default (Collision))));
    harmony.Patch((MethodBase) methodInfo4, new HarmonyMethod(methodInfo2), new HarmonyMethod(methodInfo5), (HarmonyMethod) null, (HarmonyMethod) null, (HarmonyMethod) null);
    MethodInfo methodInfo6 = AccessTools.Method(typeof (PlayerScript), "Win", (Type[]) null, (Type[]) null);
    // ISSUE: method reference
    MethodInfo methodInfo7 = SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>((Expression) Expression.Call((Expression) null, (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (NoclipHook.OnWin)), Array.Empty<Expression>())));
    harmony.Patch((MethodBase) methodInfo6, new HarmonyMethod(methodInfo7), (HarmonyMethod) null, (HarmonyMethod) null, (HarmonyMethod) null, (HarmonyMethod) null);
  }

  private static bool OnWin()
  {
    PlayerScript objectOfType = Object.FindObjectOfType<PlayerScript>();
    if (!objectOfType.noDeath || Noclip.isNoclipEnabled)
    {
      objectOfType.dead = true;
      ((Component) ((Component) objectOfType).transform.parent).gameObject.SetActive(false);
      Object.Instantiate<GameObject>(objectOfType.WinFX, ((Component) objectOfType).transform.position, ((Component) objectOfType).transform.rotation);
      Object.Instantiate<GameObject>(objectOfType.cam, objectOfType.cam.transform.position, objectOfType.cam.transform.rotation);
    }
    return false;
  }

  public static void MyPrefix()
  {
  }

  public static void OnSceneChanged() => NoclipHook.deathCount = 0;

  public static void MyPostfix() => ++NoclipHook.deathCount;

  public static void OnCollisionEnter(Collision other)
  {
    if (!BetterNoclip.isEnabled || !(other.gameObject.tag == "Hazard"))
      return;
    Object.Destroy((Object) other.collider);
  }
}
