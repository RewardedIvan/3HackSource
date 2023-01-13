using System;
using UnityEngine;

namespace Modules
{
	// Token: 0x02000047 RID: 71
	[Serializable]
	internal class ClickGUI : Module
	{
		// Token: 0x060000E4 RID: 228 RVA: 0x0000C070 File Offset: 0x0000A270
		public ClickGUI()
		{
			this.name = "ClickGUI";
			this.description = "The GUI That your looking at right now";
			this.mustHaveKeyBind = true;
			this.keybind = (KeyCode)303;
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x0000C0A2 File Offset: 0x0000A2A2
		public override void Update()
		{
			ModMain.clickGUIKeyCode = this.keybind;
			this.enabled = ModMain.showClickGUI;
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x0000C0BC File Offset: 0x0000A2BC
		public override void OnClick()
		{
			bool flag = !Keybinds.editing;
			if (flag)
			{
				ModMain.showClickGUI = false;
			}
		}
	}
}
