// Decompiled with JetBrains decompiler
// Type: StatusMGR
// Assembly: Hacks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7044930E-2DB6-478E-8870-F3754E75DBEE
// Assembly location: C:\Users\Rewar\Desktop\3Dash Windows v1.2\Mods\Hacks.dll

using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Windows;

public class StatusMGR
{
  public static TextMeshProUGUI tltext;
  public static TextMeshProUGUI trtext;
  public static bool isInScene;
  public static float totalDelta;
  public static int frames;

  public static void Init()
  {
    GameObject gameObject1 = new GameObject();
    ((Object) gameObject1).name = "sus Canvas (Explodingbill)";
    gameObject1.AddComponent<Canvas>();
    Canvas component1 = gameObject1.GetComponent<Canvas>();
    component1.sortingOrder = 0;
    component1.renderMode = (RenderMode) 0;
    gameObject1.AddComponent<CanvasScaler>().uiScaleMode = (CanvasScaler.ScaleMode) 1;
    GameObject gameObject2 = new GameObject();
    gameObject2.transform.parent = gameObject1.transform;
    ((Object) gameObject2).name = "TopLeft";
    TextMeshProUGUI textMeshProUgui1 = gameObject2.AddComponent<TextMeshProUGUI>();
    ((TMP_Text) textMeshProUgui1).font = ModMain.fonts[0];
    ((TMP_Text) textMeshProUgui1).text = "";
    ((TMP_Text) textMeshProUgui1).fontSize = 12f;
    ((TMP_Text) textMeshProUgui1).alignment = (TextAlignmentOptions) 257;
    RectTransform component2 = ((Component) textMeshProUgui1).GetComponent<RectTransform>();
    component2.anchorMin = Vector2.up;
    component2.anchorMax = Vector2.up;
    component2.anchoredPosition = new Vector2(20005f, -105f);
    component2.sizeDelta = new Vector2(40000f, 200f);
    ((Graphic) textMeshProUgui1).raycastTarget = false;
    Object.DontDestroyOnLoad((Object) ((Component) component1).gameObject);
    GameObject gameObject3 = new GameObject();
    gameObject3.transform.parent = gameObject1.transform;
    ((Object) gameObject3).name = "TopRight";
    TextMeshProUGUI textMeshProUgui2 = gameObject3.AddComponent<TextMeshProUGUI>();
    ((TMP_Text) textMeshProUgui2).font = ModMain.fonts[0];
    ((TMP_Text) textMeshProUgui2).text = "";
    ((TMP_Text) textMeshProUgui2).fontSize = 12f;
    ((TMP_Text) textMeshProUgui2).alignment = (TextAlignmentOptions) 260;
    RectTransform component3 = ((Component) textMeshProUgui2).GetComponent<RectTransform>();
    component3.anchorMin = Vector2.one;
    component3.anchorMax = Vector2.one;
    component3.anchoredPosition = new Vector2(-20005f, -105f);
    component3.sizeDelta = new Vector2(40000f, 200f);
    ((Graphic) textMeshProUgui2).raycastTarget = false;
    StatusMGR.tltext = textMeshProUgui1;
    StatusMGR.trtext = textMeshProUgui2;
  }

  public static void Update()
  {
    if (StatusMGR.isInScene && !PauseMenuManager.paused)
    {
      StatusMGR.totalDelta += Time.deltaTime;
      ++StatusMGR.frames;
    }
    Status.UpdateText(StatusMGR.tltext);
  }

  public static void OnSceneChanged(int sceneIndex, string sceneName)
  {
    StatusMGR.totalDelta = 0.0f;
    StatusMGR.frames = 0;
    if (Object.op_Inequality((Object) Object.FindObjectOfType<PlayerScript>(), (Object) null))
      StatusMGR.isInScene = true;
    else
      StatusMGR.isInScene = false;
  }
}
