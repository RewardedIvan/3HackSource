using System;
using UnityEngine;

// Token: 0x0200000B RID: 11
public class SpeedhackMusic : Module
{
	// Token: 0x06000015 RID: 21 RVA: 0x00002622 File Offset: 0x00000822
	public SpeedhackMusic()
	{
		this.name = "Speed Music";
	}

	// Token: 0x06000016 RID: 22 RVA: 0x00002638 File Offset: 0x00000838
	public override void Update()
	{
		bool flag = this.enabled && SpeedhackButton.isEnabled;
		if (flag)
		{
			foreach (AudioSource audioSource in UnityEngine.Object.FindObjectsOfType<AudioSource>())
			{
				audioSource.pitch = float.Parse(PlayerPrefs.GetString("SpeedhackValue", "1"));
			}
		}
		else
		{
			foreach (AudioSource audioSource2 in UnityEngine.Object.FindObjectsOfType<AudioSource>())
			{
				audioSource2.pitch = 1f;
			}
		}
	}
}
