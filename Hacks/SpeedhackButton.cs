using System;
using UnityEngine;

// Token: 0x0200000A RID: 10
public class SpeedhackButton : Module
{
	// Token: 0x06000013 RID: 19 RVA: 0x00002589 File Offset: 0x00000789
	public SpeedhackButton()
	{
		this.name = "Enabled";
	}

	// Token: 0x06000014 RID: 20 RVA: 0x000025A0 File Offset: 0x000007A0
	public override void Update()
	{
		SpeedhackButton.isEnabled = this.enabled;
		bool enabled = this.enabled;
		if (enabled)
		{
			bool paused = PauseMenuManager.paused;
			if (paused)
			{
				Time.timeScale = 0f;
			}
			else
			{
				Time.timeScale = float.Parse(PlayerPrefs.GetString("SpeedhackValue", "1"));
			}
		}
		else
		{
			bool paused2 = PauseMenuManager.paused;
			if (paused2)
			{
				Time.timeScale = 0f;
			}
			else
			{
				Time.timeScale = 1f;
			}
		}
	}

	// Token: 0x04000007 RID: 7
	public static bool isEnabled;
}
