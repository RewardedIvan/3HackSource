using System;
using ModuleType;
using TMPro;
using UnityEngine;

namespace Windows
{
	// Token: 0x02000021 RID: 33
	public class Status : Window
	{
		// Token: 0x06000064 RID: 100 RVA: 0x00005FA4 File Offset: 0x000041A4
		public Status()
		{
			Status.window = this;
			this.rect.position = new Vector2(440f, 20f);
			this.name = "Status";
			this.modules.Add(new Module
			{
				name = "FPS",
				description = "Right click to change the side on the screen"
			});
			this.modules.Add(new Module
			{
				name = "Accuracy",
				description = "Right click to change the side on the screen"
			});
			this.modules.Add(new Module
			{
				name = "Deaths",
				description = "Right click to change the side on the screen"
			});
			this.modules.Add(new Module
			{
				name = "Attempts",
				description = "Right click to change the side on the screen"
			});
			this.modules.Add(new Module
			{
				name = "Clicks",
				description = "Right click to change the side on the screen"
			});
			this.modules.Add(new Module
			{
				name = "Frames",
				description = "Right click to change the side on the screen"
			});
			this.modules.Add(new Module
			{
				name = "Input",
				description = "Right click to change the side on the screen"
			});
			this.modules.Add(new Module
			{
				name = "Message",
				description = "Right click to change the side on the screen"
			});
			foreach (Module module in this.modules)
			{
				DualSidedOption dualSidedOption = new DualSidedOption();
				dualSidedOption.name1 = "Left";
				dualSidedOption.name2 = "Right";
				dualSidedOption.name = module.name + "Side";
				module.settings.Add(dualSidedOption);
			}
			this.modules.Add(new MessageInput());
		}

		// Token: 0x06000065 RID: 101 RVA: 0x000061B0 File Offset: 0x000043B0
		public static void UpdateText(TextMeshProUGUI text)
		{
			StatusMGR.tltext.text = "";
			StatusMGR.trtext.text = "";
			bool isInScene = StatusMGR.isInScene;
			if (isInScene)
			{
				bool enabled = Status.window.modules[0].enabled;
				if (enabled)
				{
					Status.DrawSidedText("FPS: " + Mathf.Round(1f / Time.unscaledDeltaTime).ToString() + "\n", Status.window.modules[0]);
				}
				bool enabled2 = Status.window.modules[1].enabled;
				if (enabled2)
				{
					Status.DrawSidedText("Accuracy: " + decimal.Round(decimal.Parse(((float)(StatusMGR.frames - NoclipHook.deathCount) / (float)StatusMGR.frames * 100f).ToString()), 2).ToString() + "%\n", Status.window.modules[1]);
				}
				bool enabled3 = Status.window.modules[2].enabled;
				if (enabled3)
				{
					Status.DrawSidedText("Deaths: " + NoclipHook.deathCount.ToString() + "\n", Status.window.modules[2]);
				}
				bool enabled4 = Status.window.modules[3].enabled;
				if (enabled4)
				{
					Status.DrawSidedText("Attempt " + AttemptCounter.attempts.ToString() + "\n", Status.window.modules[3]);
				}
				bool enabled5 = Status.window.modules[4].enabled;
				if (enabled5)
				{
					Status.DrawSidedText("Clicks: " + Status.mouseclicks.ToString() + "\n", Status.window.modules[4]);
				}
				bool rightOn = Replay.replayMode.rightOn;
				if (rightOn)
				{
					bool enabled6 = Status.window.modules[5].enabled;
					if (enabled6)
					{
						Status.DrawSidedText(string.Concat(new string[]
						{
							"Frame: ",
							Replay.frame.ToString(),
							" / ",
							Replay.inputCheck.Count.ToString(),
							"\n"
						}), Status.window.modules[5]);
					}
					bool enabled7 = Status.window.modules[6].enabled;
					if (enabled7)
					{
						Status.DrawSidedText("Read Input: " + Replay.inputCheck[Replay.frame].ToString() + "\n", Status.window.modules[6]);
					}
				}
				bool enabled8 = Status.window.modules[Status.window.modules.Count - 2].enabled;
				if (enabled8)
				{
					Status.DrawSidedText(PlayerPrefs.GetString("MessageText") + "\n", Status.window.modules[Status.window.modules.Count - 2]);
				}
			}
		}

		// Token: 0x06000066 RID: 102 RVA: 0x000064EC File Offset: 0x000046EC
		public static void DrawSidedText(string text, Module option)
		{
			bool enabled = option.settings[option.settings.Count - 1].enabled;
			if (enabled)
			{
				TextMeshProUGUI trtext = StatusMGR.trtext;
				trtext.text += text;
			}
			else
			{
				TextMeshProUGUI tltext = StatusMGR.tltext;
				tltext.text += text;
			}
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00006550 File Offset: 0x00004750
		public override void OnUpdate()
		{
			bool flag = !PauseMenuManager.paused;
			if (flag)
			{
				bool flag2 = Input.GetMouseButtonDown(0) || Input.GetKeyDown((KeyCode)32) || Input.GetKeyDown((KeyCode)273);
				if (flag2)
				{
					Status.mouseclicks++;
				}
			}
		}

		// Token: 0x06000068 RID: 104 RVA: 0x0000659A File Offset: 0x0000479A
		public override void OnSceneChanged(int buildIndex, string sceneName)
		{
			Status.mouseclicks = 0;
		}

		// Token: 0x04000036 RID: 54
		private static int mouseclicks;

		// Token: 0x04000037 RID: 55
		public static Window window;
	}
}
