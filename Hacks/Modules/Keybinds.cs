using System;
using ModuleType;
using UnityEngine;

namespace Modules
{
	// Token: 0x02000037 RID: 55
	public class Keybinds : Button
	{
		// Token: 0x060000C0 RID: 192 RVA: 0x0000A804 File Offset: 0x00008A04
		public Keybinds()
		{
			this.name = "Keybinds";
			this.description = "Modify the keybinds of modules";
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x0000A824 File Offset: 0x00008A24
		public override void OnClick()
		{
			this.canClick = false;
			Keybinds.editing = true;
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x0000A834 File Offset: 0x00008A34
		public override void Update()
		{
			bool flag = Input.GetKeyDown((KeyCode)27) && Keybinds.module == null;
			if (flag)
			{
				this.canClick = true;
				Keybinds.editing = false;
			}
			else
			{
				bool flag2 = Input.GetKeyDown((KeyCode)27) && Keybinds.module != null;
				if (flag2)
				{
					bool mustHaveKeyBind = Keybinds.module.mustHaveKeyBind;
					if (!mustHaveKeyBind)
					{
						this.canClick = true;
						Keybinds.editing = false;
					}
				}
				else
				{
					bool flag3 = !ModMain.showClickGUI;
					if (flag3)
					{
						this.canClick = true;
						Keybinds.editing = false;
					}
					else
					{
						try
						{
							bool flag4 = Keybinds.module.name == "ClickGUI";
							if (flag4)
							{
								ModMain.showClickGUI = true;
							}
							bool flag5 = Input.GetKeyDown((KeyCode)27) || !ModMain.showClickGUI;
							if (flag5)
							{
								bool flag6 = Keybinds.module == null;
								if (flag6)
								{
									this.canClick = true;
									Keybinds.editing = false;
									return;
								}
								bool flag7 = !Keybinds.module.mustHaveKeyBind;
								if (flag7)
								{
									this.canClick = true;
									Keybinds.editing = false;
									return;
								}
								ModMain.showClickGUI = true;
							}
							bool flag8 = Keybinds.module != null;
							if (flag8)
							{
								bool keyDown = Input.GetKeyDown((KeyCode)8);
								if (keyDown)
								{
									bool flag9 = !Keybinds.module.mustHaveKeyBind;
									if (flag9)
									{
										Keybinds.module.keybind = 0;
										Keybinds.module = null;
									}
								}
								else
								{
									foreach (KeyCode keyCode in (KeyCode[])Enum.GetValues(typeof(KeyCode)))
									{
										bool flag10 = keyCode != (KeyCode)324;
										if (flag10)
										{
											bool keyDown2 = Input.GetKeyDown(keyCode);
											if (keyDown2)
											{
												Keybinds.module.keybind = keyCode;
												Keybinds.module = null;
											}
										}
									}
								}
							}
						}
						catch
						{
						}
					}
				}
			}
		}

		// Token: 0x0400006B RID: 107
		public static bool editing;

		// Token: 0x0400006C RID: 108
		public static Module module;
	}
}
