using System;
using ModuleType;
using UnityEngine;

// Token: 0x02000009 RID: 9
public class SpeedhackInput : TextInput
{
	// Token: 0x06000011 RID: 17 RVA: 0x0000254F File Offset: 0x0000074F
	public SpeedhackInput()
	{
		this.text = PlayerPrefs.GetString("SpeedhackValue", "1");
		this.numberOnly = true;
	}

	// Token: 0x06000012 RID: 18 RVA: 0x00002575 File Offset: 0x00000775
	public override void Update()
	{
		PlayerPrefs.SetString("SpeedhackValue", this.text);
	}
}
