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
				description = "Amount of Frames Per Second"
			});
			this.modules.Add(new Module
			{
				name = "Accuracy",
				description = "How accurately you've played with noclip"
            });
			this.modules.Add(new Module
			{
				name = "Deaths",
				description = "Amount of times you've died in the current level"
			});
			this.modules.Add(new Module
			{
				name = "Attempts",
				description = "Amount of attempts you've spent in the current level"
			});
			this.modules.Add(new Module
			{
				name = "Clicks",
				description = "Amount of times you've clicked in the current level"
			});
            this.modules.Add(new Module
            {
                name = "CPS",
                description = "Amount of Clicks Per Second"
            });
            this.modules.Add(new Module
			{
				name = "Frames",
				description = "Amount of frames you've recorded"
			});
			this.modules.Add(new Module
			{
				name = "Replay Input",
				description = "Displays the current input in the current playing replay"
			});
			this.modules.Add(new Module
			{
				name = "Message",
				description = "Text"
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
				if (Status.window.modules[0].enabled)
				{
					Status.DrawSidedText("FPS: " + Mathf.Round(1f / Time.unscaledDeltaTime).ToString() + "\n", Status.window.modules[0]);
				}
				if (Status.window.modules[1].enabled)
				{
					Status.DrawSidedText("Accuracy: " + decimal.Round(decimal.Parse(((float)(StatusMGR.frames - NoclipHook.deathCount) / (float)StatusMGR.frames * 100f).ToString()), 2).ToString() + "%\n", Status.window.modules[1]);
				}
				if (Status.window.modules[2].enabled)
				{
					Status.DrawSidedText("Deaths: " + NoclipHook.deathCount.ToString() + "\n", Status.window.modules[2]);
				}
				if (Status.window.modules[3].enabled)
				{
					Status.DrawSidedText("Attempt " + AttemptCounter.attempts.ToString() + "\n", Status.window.modules[3]);
				}
				if (Status.window.modules[4].enabled)
				{
					Status.DrawSidedText("Clicks: " + Status.mouseclicks.ToString() + "\n", Status.window.modules[4]);
				}
                if (Status.window.modules[5].enabled)
                {
                    Status.DrawSidedText("CPS: " + Status.CPS.ToString() + "\n", Status.window.modules[5]);
                }
                if (Replay.replayMode.rightOn)
				{
					if (Status.window.modules[6].enabled)
					{
						Status.DrawSidedText(string.Concat(new string[]
						{
							"Frame: ",
							Replay.frame.ToString(),
							" / ",
							Replay.inputCheck.Count.ToString(),
							"\n"
						}), Status.window.modules[6]);
					}
					if (Status.window.modules[7].enabled)
					{
						try
						{
                            Status.DrawSidedText("Replay Input: " + (Replay.inputCheck[Replay.frame] ? "Click" : "Not click") + "\n", Status.window.modules[7]);
                        }
                        catch (Exception)
						{
                            Status.DrawSidedText("Replay Input: Not click" + "\n", Status.window.modules[7]);
						}
					}
				}
				if (Status.window.modules[8].enabled)
				{
					Status.DrawSidedText(PlayerPrefs.GetString("MessageText") + "\n", Status.window.modules[8]);
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
					Status.CPS++;
				}
			}
            if (Status.CPSTimer >= Mathf.Round(1f / Time.unscaledDeltaTime))
            {
                Status.CPS = 0;
				Status.CPSTimer = 0;
            }
            Status.CPSTimer++;
        }

        // Token: 0x06000068 RID: 104 RVA: 0x0000659A File Offset: 0x0000479A
        public override void OnSceneChanged(int buildIndex, string sceneName)
		{
			Status.mouseclicks = 0;
            Status.CPS = 0;
            Status.CPSTimer = 0;
        }

        // Token: 0x04000036 RID: 54
        private static int mouseclicks;
        private static int CPS;
        private static int CPSTimer;

        // Token: 0x04000037 RID: 55
        public static Window window;
	}
}
