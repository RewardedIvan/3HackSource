using System;
using ModuleType;
using UnityEngine;

// Token: 0x02000008 RID: 8
public class InfLevelsCount : TextOption
{
	// Token: 0x0600000F RID: 15 RVA: 0x0000250A File Offset: 0x0000070A
	public InfLevelsCount()
	{
		this.name = "InfLevelsCount";
		this.text = PlayerPrefs.GetString("InfLevelsCount", "50");
		this.numberOnly = true;
	}

	// Token: 0x06000010 RID: 16 RVA: 0x0000253B File Offset: 0x0000073B
	public override void Update()
	{
		PlayerPrefs.SetString("InfLevelsCount", this.text);
	}
}
