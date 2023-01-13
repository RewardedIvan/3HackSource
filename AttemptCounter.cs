// Decompiled with JetBrains decompiler
// Type: AttemptCounter
// Assembly: Hacks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7044930E-2DB6-478E-8870-F3754E75DBEE
// Assembly location: C:\Users\Rewar\Desktop\3Dash Windows v1.2\Mods\Hacks.dll

using HarmonyLib;
using System;
using System.Linq.Expressions;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class AttemptCounter
{
  public static int attempts;

  public static void Initialize()
  {
    // ISSUE: method pointer
    SceneManager.activeSceneChanged += new UnityAction<Scene, Scene>((object) null, __methodptr(SceneManager_activeSceneChanged));
    // ISSUE: method reference
    new Harmony("com.Explodingbill.Attempt").Patch((MethodBase) AccessTools.Method(typeof (PlayerScript), "Awake", (Type[]) null, (Type[]) null), (HarmonyMethod) null, new HarmonyMethod(SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>((Expression) Expression.Call((Expression) null, (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (AttemptCounter.MyPostfix)), Array.Empty<Expression>())))), (HarmonyMethod) null, (HarmonyMethod) null, (HarmonyMethod) null);
  }

  public static void MyPostfix() => ++AttemptCounter.attempts;

  private static void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
  {
    if (!Object.op_Equality((Object) Object.FindObjectOfType<PlayerScript>(), (Object) null))
      return;
    AttemptCounter.attempts = 0;
  }
}
