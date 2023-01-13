using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Modules
{
	// Token: 0x02000048 RID: 72
	[Serializable]
	internal class Freecam : Module
	{
		// Token: 0x060000E7 RID: 231 RVA: 0x0000C0DE File Offset: 0x0000A2DE
		public Freecam()
		{
			this.name = "Freecam";
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x0000C0F3 File Offset: 0x0000A2F3
		public static void DoPatch()
		{
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x0000C0F8 File Offset: 0x0000A2F8
		public override void Update()
		{
			bool flag = GameObject.Find("CameraManagement") != null && SceneManager.GetActiveScene().name != "Camera Animator";
			if (flag)
			{
				GameObject.Find("CameraManagement").transform.GetChild(0).GetChild(0).GetComponent<BoomArm>()
					.enabled = this.enabled;
				GameObject.Find("CameraManagement").transform.GetChild(0).GetChild(0).GetComponent<BoomArm>()
					.spd = 0.05f;
				GameObject.Find("CameraManagement").transform.GetChild(0).GetChild(0).GetComponent<Animator>()
					.enabled = !this.enabled;
				Cursor.lockState = Screen.fullScreen ? (CursorLockMode)2 : 0;
				foreach (Window window in ModMain.cwm.wnds)
				{
					bool flag2 = window.name == "Player";
					if (flag2)
					{
						UnityEngine.Object.FindObjectOfType<PlayerScript>().noDeath = window.modules[0].enabled;
					}
				}
			}
		}
	}
}
