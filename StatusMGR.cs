using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Windows;

// Token: 0x02000012 RID: 18
public class StatusMGR
{
	// Token: 0x06000030 RID: 48 RVA: 0x00003CB4 File Offset: 0x00001EB4
	public static void Init()
	{
		GameObject gameObject = new GameObject();
		gameObject.name = "sus Canvas (Explodingbill)";
		gameObject.AddComponent<Canvas>();
		Canvas component = gameObject.GetComponent<Canvas>();
		component.sortingOrder = 0;
		component.renderMode = 0;
		gameObject.AddComponent<CanvasScaler>().uiScaleMode = (CanvasScaler.ScaleMode)1;
		TextMeshProUGUI textMeshProUGUI = new GameObject
		{
			transform = 
			{
				parent = gameObject.transform
			},
			name = "TopLeft"
		}.AddComponent<TextMeshProUGUI>();
		textMeshProUGUI.font = ModMain.fonts[0];
		textMeshProUGUI.text = "";
		textMeshProUGUI.fontSize = 12f;
		textMeshProUGUI.alignment = (TextAlignmentOptions)257;
		RectTransform component2 = textMeshProUGUI.GetComponent<RectTransform>();
		component2.anchorMin = Vector2.up;
		component2.anchorMax = Vector2.up;
		component2.anchoredPosition = new Vector2(20005f, -105f);
		component2.sizeDelta = new Vector2(40000f, 200f);
		textMeshProUGUI.raycastTarget = false;
		UnityEngine.Object.DontDestroyOnLoad(component.gameObject);
		TextMeshProUGUI textMeshProUGUI2 = new GameObject
		{
			transform = 
			{
				parent = gameObject.transform
			},
			name = "TopRight"
		}.AddComponent<TextMeshProUGUI>();
		textMeshProUGUI2.font = ModMain.fonts[0];
		textMeshProUGUI2.text = "";
		textMeshProUGUI2.fontSize = 12f;
		textMeshProUGUI2.alignment = (TextAlignmentOptions)260;
		RectTransform component3 = textMeshProUGUI2.GetComponent<RectTransform>();
		component3.anchorMin = Vector2.one;
		component3.anchorMax = Vector2.one;
		component3.anchoredPosition = new Vector2(-20005f, -105f);
		component3.sizeDelta = new Vector2(40000f, 200f);
		textMeshProUGUI2.raycastTarget = false;
		StatusMGR.tltext = textMeshProUGUI;
		StatusMGR.trtext = textMeshProUGUI2;
	}

	// Token: 0x06000031 RID: 49 RVA: 0x00003E9C File Offset: 0x0000209C
	public static void Update()
	{
		bool flag = StatusMGR.isInScene && !PauseMenuManager.paused;
		if (flag)
		{
			StatusMGR.totalDelta += Time.deltaTime;
			StatusMGR.frames++;
		}
		Status.UpdateText(StatusMGR.tltext);
	}

	// Token: 0x06000032 RID: 50 RVA: 0x00003EEC File Offset: 0x000020EC
	public static void OnSceneChanged(int sceneIndex, string sceneName)
	{
		StatusMGR.totalDelta = 0f;
		StatusMGR.frames = 0;
		bool flag = UnityEngine.Object.FindObjectOfType<PlayerScript>() != null;
		if (flag)
		{
			StatusMGR.isInScene = true;
		}
		else
		{
			StatusMGR.isInScene = false;
		}
	}

	// Token: 0x04000013 RID: 19
	public static TextMeshProUGUI tltext;

	// Token: 0x04000014 RID: 20
	public static TextMeshProUGUI trtext;

	// Token: 0x04000015 RID: 21
	public static bool isInScene;

	// Token: 0x04000016 RID: 22
	public static float totalDelta;

	// Token: 0x04000017 RID: 23
	public static int frames;
}
