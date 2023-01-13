using System;
using DiscordRPC;

// Token: 0x0200000C RID: 12
public class _DiscordRPC
{
	// Token: 0x06000017 RID: 23 RVA: 0x000026C8 File Offset: 0x000008C8
	public static void Initialize()
	{
		try
		{
			_DiscordRPC.client = new DiscordRpcClient("1017689651378667561");
			_DiscordRPC.client.Initialize();
			_DiscordRPC.client.SetPresence(new RichPresence
			{
				Details = "Loading Rich Presence",
				State = "",
				Assets = new Assets
				{
					LargeImageKey = "3dash_big",
					LargeImageText = "3Dash"
				}
			});
		}
		catch
		{
			_DiscordRPC.isInitialized = true;
		}
	}

	// Token: 0x06000018 RID: 24 RVA: 0x0000275C File Offset: 0x0000095C
	public static void UpdatePresence(string sceneName)
	{
		bool flag = !_DiscordRPC.isInitialized;
		if (!flag)
		{
			_DiscordRPC.client.SetPresence(new RichPresence
			{
				Details = "Playing A Level",
				State = sceneName + " by Deluge Drop",
				Assets = new Assets
				{
					LargeImageKey = "3dash_big",
					LargeImageText = "3Dash"
				}
			});
			_DiscordRPC.client.UpdateStartTime();
			bool flag2 = sceneName == "Menu";
			if (flag2)
			{
				_DiscordRPC.client.SetPresence(new RichPresence
				{
					Details = "Browsing The Menus",
					State = "",
					Assets = new Assets
					{
						LargeImageKey = "3dash_big",
						LargeImageText = "3Dash"
					}
				});
			}
			bool flag3 = sceneName == "Online Levels Hub";
			if (flag3)
			{
				_DiscordRPC.client.SetPresence(new RichPresence
				{
					Details = "Browsing Online Levels",
					State = "",
					Assets = new Assets
					{
						LargeImageKey = "3dash_big",
						LargeImageText = "3Dash"
					}
				});
			}
			bool flag4 = sceneName == "Online Levels Player";
			if (flag4)
			{
				_DiscordRPC.client.SetPresence(new RichPresence
				{
					Details = "Playing A Level",
					State = string.Concat(new string[]
					{
						LevelEditor.levelName,
						" by ",
						LevelEditor.levelAuthor,
						" (",
						LevelEditor.currentID.ToString(),
						")"
					}),
					Assets = new Assets
					{
						LargeImageKey = "3dash_big",
						LargeImageText = "3Dash"
					}
				});
			}
			bool flag5 = sceneName == "Playtester";
			if (flag5)
			{
				_DiscordRPC.client.SetPresence(new RichPresence
				{
					Details = "Playtesting A Level",
					State = LevelEditor.levelName,
					Assets = new Assets
					{
						LargeImageKey = "3dash_big",
						LargeImageText = "3Dash"
					}
				});
			}
			bool flag6 = sceneName == "Save Select" || sceneName == "HUB" || sceneName == "2D Editor" || sceneName == "Path Editor" || sceneName == "Camera Animator Hub" || sceneName == "Camera Animator" || sceneName == "Level Settings" || sceneName == "Submission";
			if (flag6)
			{
				_DiscordRPC.client.SetPresence(new RichPresence
				{
					Details = "Making A Level",
					State = "",
					Assets = new Assets
					{
						LargeImageKey = "3dash_big",
						LargeImageText = "3Dash"
					}
				});
			}
		}
	}

	// Token: 0x04000008 RID: 8
	public static DiscordRpcClient client;

	// Token: 0x04000009 RID: 9
	public static bool isInitialized = true;
}
