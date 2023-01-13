using System;
using TMPro;
using UnityEngine;

namespace Modules
{
	// Token: 0x02000043 RID: 67
	public class ShowAttemptCount : Module
	{
		// Token: 0x060000DC RID: 220 RVA: 0x0000BDA8 File Offset: 0x00009FA8
		public ShowAttemptCount()
		{
			this.name = "Show Attempt Text";
			this.description = "Add an attempt count where you spawn";
			ShowAttemptCount.module = this;
		}

		// Token: 0x060000DD RID: 221 RVA: 0x0000BDD0 File Offset: 0x00009FD0
		public static void CreateText()
		{
			bool flag = StatusMGR.isInScene && ShowAttemptCount.module.enabled;
			if (flag)
			{
				GameObject gameObject = new GameObject("sus Attempt count");
				gameObject.AddComponent<MeshRenderer>();
				TextMeshPro textMeshPro = gameObject.AddComponent<TextMeshPro>();
				textMeshPro.overflowMode = 0;
				textMeshPro.alignment = (TextAlignmentOptions)514;
				textMeshPro.fontSize = 12f;
				textMeshPro.font = ModMain.fonts[0];
				textMeshPro.enableCulling = true;
				textMeshPro.text = "Attempt " + AttemptCounter.attempts.ToString();
				gameObject.transform.position = new Vector3(UnityEngine.Object.FindObjectOfType<PlayerScript>().transform.position.x, 5f, UnityEngine.Object.FindObjectOfType<PlayerScript>().transform.position.z);
				gameObject.transform.rotation = UnityEngine.Object.FindObjectOfType<Camera>().transform.rotation;
			}
		}

		// Token: 0x04000074 RID: 116
		public static Module module;
	}
}
