using System;
using System.Diagnostics;
using UnityEngine;

// Token: 0x02000006 RID: 6
public static class RenderPipelineManager
{
	// Token: 0x14000001 RID: 1
	// (add) Token: 0x0600000C RID: 12 RVA: 0x000024A0 File Offset: 0x000006A0
	// (remove) Token: 0x0600000D RID: 13 RVA: 0x000024D4 File Offset: 0x000006D4

	// there is probably a reason this line exists, but i didnt notice a single difference, soooo
	//[DebuggerBrowsable(DebuggerBrowsableState.Never)]

	// GizmosInstance.cs:156 ; GizmosInstance.cs:170
	public static event Action<ScriptableRenderContext, Camera> endCameraRendering;
}
