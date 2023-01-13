using System;
using System.Linq.Expressions;
using System.Reflection;
using HarmonyLib;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Modules
{
	// Token: 0x0200003D RID: 61
	public class InfLevels : global::Module
	{
		// Token: 0x060000CF RID: 207 RVA: 0x0000B584 File Offset: 0x00009784
		public InfLevels()
		{
			this.name = "Custom Level Count";
			this.description = "Set a custom level count (buggy / broken)";
			InfLevels.harmony = new HarmonyLib.Harmony("com.Explodingbill.SaveSelectPage");
			this.settings.Add(new InfLevelsCount());
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0000B5C4 File Offset: 0x000097C4
		public override void OnClick()
		{
			bool enabled = this.enabled;
			if (enabled)
			{
				MethodInfo methodInfo = AccessTools.Method(typeof(SaveSelect), "Start", null, null);
                var prefix = new HarmonyMethod(typeof(InfLevels).GetMethod("AddButtons"));

                InfLevels.harmony.Patch(original: methodInfo, prefix: prefix);
			}
			else
			{
				InfLevels.harmony.UnpatchSelf();
			}
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x0000B644 File Offset: 0x00009844
		public override void OnLoadedSave()
		{
			this.OnClick();
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x0000B650 File Offset: 0x00009850
		public static void AddButtons()
		{
			SaveSelect ss = UnityEngine.Object.FindObjectOfType<SaveSelect>();
			GameObject gameObject = ss.fileTexts[0].transform.parent.gameObject;
			GameObject gameObject2 = new GameObject("Content");
			gameObject2.transform.parent = gameObject.transform.parent;
			gameObject2.AddComponent<RectTransform>();
			GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(GameObject.Find("Title"), GameObject.Find("Title").transform.parent);
			gameObject3.GetComponent<TextMeshProUGUI>().fontSize = 22f;
			gameObject3.transform.position = new Vector3(959.9999f, 860.9382f, 0f);
			gameObject3.GetComponent<TextMeshProUGUI>().text = "When creating a new File, it will have the contents of the first level.\nI do not know how to fix this so until I find a fix you need to remove every object.\n(this will not override the first level)";
			int num = 0;
			foreach (TextMeshProUGUI textMeshProUGUI in ss.fileTexts)
			{
				bool flag = num != 0;
				if (flag)
				{
					UnityEngine.Object.Destroy(textMeshProUGUI.transform.parent.gameObject);
				}
				num++;
			}
			gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
			ss.fileTexts = new TextMeshProUGUI[60];
			float y = gameObject.transform.position.y;
			float num2 = y - 603.084f;
			int num3 = 0;
			int num4 = 1;
			for (int j = 0; j < int.Parse(PlayerPrefs.GetString("InfLevelsCount", "50")); j++)
			{
				GameObject gameObject4 = UnityEngine.Object.Instantiate<GameObject>(gameObject, gameObject2.transform);
				gameObject4.GetComponent<Button>().onClick.RemoveAllListeners();
				int h = j;
				gameObject4.GetComponent<Button>().onClick.AddListener(delegate()
				{
					LevelEditor.currentSave = (h + 1).ToString();
					ss.FileButton((h + 1).ToString());
				});
				ss.fileTexts[j] = gameObject4.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
				bool flag2 = num3 == 1;
				if (flag2)
				{
					gameObject4.transform.position = new Vector3(1310f, y - num2 * (float)num4, 0f);
					num3 = 0;
					num4++;
				}
				else
				{
					gameObject4.transform.position = new Vector3(610f, y - num2 * (float)num4, 0f);
					num3++;
				}
				gameObject4.transform.position += new Vector3(0f, 115f, 0f);
			}
			num4--;
			gameObject.transform.parent.gameObject.AddComponent<Image>().color = new Color(1f, 1f, 1f, 0.5471698f);
			gameObject.transform.parent.gameObject.AddComponent<Mask>();
			gameObject.transform.parent.GetComponent<Mask>().showMaskGraphic = true;
			gameObject.transform.parent.gameObject.AddComponent<ScrollRect>();
			gameObject.transform.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(1420f, 800f);
			gameObject.transform.parent.GetComponent<RectTransform>().anchoredPosition += new Vector2(0f, -127f);
			gameObject.transform.parent.GetComponent<ScrollRect>().content = gameObject2.GetComponent<RectTransform>();
			gameObject.transform.parent.GetComponent<ScrollRect>().horizontal = false;
			gameObject2.transform.position = new Vector3(0f, -10f - num2, 0f);
			gameObject2.GetComponent<RectTransform>().sizeDelta = new Vector2(1420f, num2 * (float)num4);
			UnityEngine.Object.Destroy(gameObject.gameObject);
		}

		// Token: 0x04000072 RID: 114
		public static int zOrder;

		// Token: 0x04000073 RID: 115
		public static HarmonyLib.Harmony harmony;
	}
}
