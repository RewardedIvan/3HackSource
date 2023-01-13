// Decompiled with JetBrains decompiler
// Type: RenderPipelineManager
// Assembly: Hacks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7044930E-2DB6-478E-8870-F3754E75DBEE
// Assembly location: C:\Users\Rewar\Desktop\3Dash Windows v1.2\Mods\Hacks.dll

using System;
using UnityEngine;

public static class RenderPipelineManager
{
  public static event Action<ScriptableRenderContext, Camera> endCameraRendering;
}
