// Decompiled with JetBrains decompiler
// Type: ModMain
// Assembly: Hacks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7044930E-2DB6-478E-8870-F3754E75DBEE
// Assembly location: C:\Users\Rewar\Desktop\3Dash Windows v1.2\Mods\Hacks.dll

using MelonLoader;
using Modules;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ModMain : MelonMod
{
  public static bool initializedFonts;
  public static List<TMP_FontAsset> fonts = new List<TMP_FontAsset>();
  public static Camera camera;
  public static float scale = 0.5f;
  public Rect windowRect = new Rect(20f, 20f, 230f * ModMain.scale, 50f * ModMain.scale);
  public static ClientWindowManager cwm = new ClientWindowManager();
  public static Scene_Switcher scs = new Scene_Switcher();
  public static bool showClickGUI;
  public static KeyCode clickGUIKeyCode = (KeyCode) 303;

  public virtual void OnApplicationStart()
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
      Debug.Log((object) ex.Message);
    }
  }

  public virtual void OnApplicationQuit() => Save.SaveToFile();

  public virtual void OnUpdate()
  {
    if (Input.GetKeyDown((KeyCode) 303))
      PlayerPrefs.SetString("Tutorial", "Stop digging into the code you dirty bubby killer ;)");
    StatusMGR.Update();
    if (Input.GetKeyDown(ModMain.clickGUIKeyCode))
      ModMain.showClickGUI = !ModMain.showClickGUI;
    ModMain.cwm.Update();
  }

  public virtual void OnLateUpdate() => ModMain.cwm.LateUpdate();

  public virtual void OnSceneWasLoaded(int buildIndex, string sceneName)
  {
    if (!ModMain.initializedFonts)
    {
      ModMain.initializedFonts = true;
      foreach (TextMeshProUGUI textMeshProUgui in Object.FindObjectsOfType<TextMeshProUGUI>())
      {
        if (!ModMain.fonts.Contains(((TMP_Text) textMeshProUgui).font))
          ModMain.fonts.Add(((TMP_Text) textMeshProUgui).font);
      }
      StatusMGR.Init();
    }
    StatusMGR.OnSceneChanged(buildIndex, sceneName);
    NoclipHook.OnSceneChanged();
    ModMain.camera = Object.FindObjectOfType<Camera>();
    _DiscordRPC.UpdatePresence(sceneName);
    PauseMenuManager.paused = false;
    ModMain.cwm.OnSceneChanged(buildIndex, sceneName);
    if (sceneName == "Menu")
    {
      TextMeshProUGUI component1 = GameObject.Find("Version Text").GetComponent<TextMeshProUGUI>();
      ((TMP_Text) component1).text = ((TMP_Text) component1).text + " (Modded by Explodingbill)";
      RectTransform component2 = GameObject.Find("Version Text").GetComponent<RectTransform>();
      component2.sizeDelta = Vector2.op_Addition(component2.sizeDelta, new Vector2(500f, 0.0f));
      RectTransform component3 = GameObject.Find("Version Text").GetComponent<RectTransform>();
      component3.anchoredPosition = Vector2.op_Addition(component3.anchoredPosition, new Vector2(250f, 0.0f));
    }
    ShowAttemptCount.CreateText();
  }

  public virtual void OnGUI()
  {
    DrawUtils.Update();
    if (Keybinds.editing)
      DrawUtils.DrawRect(new Rect(0.0f, 0.0f, (float) Screen.width, (float) Screen.height), new Color(0.0f, 0.0f, 0.0f, 0.75f));
    GUI.skin.textArea.fontSize = Mathf.RoundToInt(32f * ModMain.scale);
    ModMain.cwm.Draw();
    if (Keybinds.editing)
    {
      string str = "None Selected\n";
      if (Keybinds.module != null)
        str = Keybinds.module.name + " Selected\n";
      GUI.skin.label.fontSize = Mathf.RoundToInt(45f * ModMain.scale);
      GUI.skin.label.alignment = (TextAnchor) 8;
      DrawUtils.DrawText(new Rect((float) (Screen.width - 20 - 500), (float) (Screen.height - 20 - 300), 500f, 300f), str + "Press Escape To Stop Editing\nPress Backspace To Reset Keybind\nRight-Click On A Module To Select It", DrawUtils.Accent());
      GUI.skin.label.fontSize = Mathf.RoundToInt(32f * ModMain.scale);
    }
    if (PlayerPrefs.HasKey("Tutorial"))
      return;
    Rect position;
    // ISSUE: explicit constructor call
    ((Rect) ref position).\u002Ector(10f, (float) (Screen.height / 2), 310f, 60f);
    GUI.skin.label.fontSize = Mathf.RoundToInt(32f * ModMain.scale);
    GUI.skin.label.alignment = (TextAnchor) 3;
    DrawUtils.DrawRect(position, new Color(0.0f, 0.0f, 0.0f, 0.35f));
    DrawUtils.DrawText(position, " Press Right-Shift to open GUI\n (This can be rebinded in the keybinds menu)", DrawUtils.Accent());
  }
}
