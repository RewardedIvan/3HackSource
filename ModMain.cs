using System;
using System.Collections.Generic;
using MelonLoader;
using Modules;
using TMPro;
using UnityEngine;

// Token: 0x02000013 RID: 19
public class ModMain : MelonMod
{
	// Token: 0x06000034 RID: 52 RVA: 0x00003F34 File Offset: 0x00002134
	public override void OnApplicationStart()
	{
		AttemptCounter.Initialize();
		NoclipHook.DoPatching();
		_DiscordRPC.Initialize();
		try
		{
			Save.LoadFromFile();
		}
		catch (Exception ex)
		{
			Debug.Log(ex.Message);
		}
	}

	// Token: 0x06000035 RID: 53 RVA: 0x00003F80 File Offset: 0x00002180
	public override void OnApplicationQuit()
	{
		Save.SaveToFile();
	}

	// Token: 0x06000036 RID: 54 RVA: 0x00003F8C File Offset: 0x0000218C
	public override void OnUpdate()
	{
		bool keyDown = Input.GetKeyDown((KeyCode)303);
		if (keyDown)
		{
			PlayerPrefs.SetString("Tutorial", "FOSS f2w");
            // Join us now and share the software;
            // You'll be free, hackers, you'll be free
            // Join us now and share the software;
            // You'll be free, hackers, you'll be free

            // Hoarders can get piles of money
            // That is true, hackers, that is true
            // But they cannot help their neighbors;
            // That's not good, hackers, that's not good

            // When we have enough free software
            // At our call, hackers, at our call
            // We'll kick out those dirty licenses
            // Ever more, hackers, ever more

            // Join us now and share the software;
            // You'll be free, hackers, you'll be free
            // Join us now and share the software;
            // You'll be free, hackers, you'll be free
        }
		StatusMGR.Update();
		bool keyDown2 = Input.GetKeyDown(ModMain.clickGUIKeyCode);
		if (keyDown2)
		{
			ModMain.showClickGUI = !ModMain.showClickGUI;
		}
		ModMain.cwm.Update();
	}

	// Token: 0x06000037 RID: 55 RVA: 0x00003FE8 File Offset: 0x000021E8
	public override void OnLateUpdate()
	{
		ModMain.cwm.LateUpdate();
	}

	// Token: 0x06000038 RID: 56 RVA: 0x00003FF8 File Offset: 0x000021F8
	public override void OnSceneWasLoaded(int buildIndex, string sceneName)
	{
		bool flag = !ModMain.initializedFonts;
		if (flag)
		{
			ModMain.initializedFonts = true;
			foreach (TextMeshProUGUI textMeshProUGUI in UnityEngine.Object.FindObjectsOfType<TextMeshProUGUI>())
			{
				bool flag2 = !ModMain.fonts.Contains(textMeshProUGUI.font);
				if (flag2)
				{
					ModMain.fonts.Add(textMeshProUGUI.font);
				}
			}
			StatusMGR.Init();
		}
		StatusMGR.OnSceneChanged(buildIndex, sceneName);
		NoclipHook.OnSceneChanged();
		ModMain.camera = UnityEngine.Object.FindObjectOfType<Camera>();
		_DiscordRPC.UpdatePresence(sceneName);
		PauseMenuManager.paused = false;
		ModMain.cwm.OnSceneChanged(buildIndex, sceneName);
		bool flag3 = sceneName == "Menu";
		if (flag3)
		{
			TextMeshProUGUI component = GameObject.Find("Version Text").GetComponent<TextMeshProUGUI>();
			component.text += " (Modded by Explodingbill + RewardedIvan)";
			GameObject.Find("Version Text").GetComponent<RectTransform>().sizeDelta += new Vector2(500f, 0f);
			GameObject.Find("Version Text").GetComponent<RectTransform>().anchoredPosition += new Vector2(250f, 0f);
		}
		ShowAttemptCount.CreateText();
	}

	// Token: 0x06000039 RID: 57 RVA: 0x00004138 File Offset: 0x00002338
	public override void OnGUI()
	{
		DrawUtils.Update();
		bool editing = Keybinds.editing;
		if (editing)
		{
			DrawUtils.DrawRect(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), new Color(0f, 0f, 0f, 0.75f));
		}
		GUI.skin.textArea.fontSize = Mathf.RoundToInt(32f * ModMain.scale);
		ModMain.cwm.Draw();
		bool editing2 = Keybinds.editing;
		if (editing2)
		{
			string text = "None Selected\n";
			bool flag = Keybinds.module != null;
			if (flag)
			{
				text = Keybinds.module.name + " Selected\n";
			}
			GUI.skin.label.fontSize = Mathf.RoundToInt(45f * ModMain.scale);
			GUI.skin.label.alignment = (TextAnchor)8;
			DrawUtils.DrawText(new Rect((float)(Screen.width - 20 - 500), (float)(Screen.height - 20 - 300), 500f, 300f), text + "Press Escape To Stop Editing\nPress Backspace To Reset Keybind\nRight-Click On A Module To Select It", DrawUtils.Accent());
			GUI.skin.label.fontSize = Mathf.RoundToInt(32f * ModMain.scale);
		}
		bool flag2 = !PlayerPrefs.HasKey("Tutorial");
		if (flag2)
		{
            Rect rect = new Rect(10f, (float)(Screen.height / 2), 310f, 60f);
			GUI.skin.label.fontSize = Mathf.RoundToInt(32f * ModMain.scale);
			GUI.skin.label.alignment = (TextAnchor)3;
			DrawUtils.DrawRect(rect, new Color(0f, 0f, 0f, 0.35f));
			DrawUtils.DrawText(rect, " Press Right-Shift to open GUI\n (This can be rebinded in the keybinds menu)", DrawUtils.Accent());
		}
	}

	// Token: 0x04000018 RID: 24
	public static bool initializedFonts;

	// Token: 0x04000019 RID: 25
	public static List<TMP_FontAsset> fonts = new List<TMP_FontAsset>();

	// Token: 0x0400001A RID: 26
	public static Camera camera;

	// Token: 0x0400001B RID: 27
	public static float scale = 0.5f;

	// Token: 0x0400001C RID: 28
	public Rect windowRect = new Rect(20f, 20f, 230f * ModMain.scale, 50f * ModMain.scale);

	// Token: 0x0400001D RID: 29
	public static ClientWindowManager cwm = new ClientWindowManager();

	// Token: 0x0400001E RID: 30
	public static Scene_Switcher scs = new Scene_Switcher();

	// Token: 0x0400001F RID: 31
	public static bool showClickGUI;

	// Token: 0x04000020 RID: 32
	public static KeyCode clickGUIKeyCode = (KeyCode)303;
}
