using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000010 RID: 16
public class Replay
{
	// Token: 0x06000026 RID: 38 RVA: 0x000030E4 File Offset: 0x000012E4
	public void Update()
	{
		bool keyDown = Input.GetKeyDown((KeyCode)116);
		if (keyDown)
		{
			this.c = !this.c;
		}
		bool keyDown2 = Input.GetKeyDown((KeyCode)121);
		if (keyDown2)
		{
			PathFollower.distanceTravelled = 0f;
			this.a = !this.a;
		}
	}

	// Token: 0x06000027 RID: 39 RVA: 0x00003134 File Offset: 0x00001334
	public void LateUpdate()
	{
		bool flag = this.c && !PauseMenuManager.paused;
		if (flag)
		{
			bool flag2 = this.a;
			if (flag2)
			{
				this.SaveState();
			}
			else
			{
				this.b++;
				this.LoadState(Replay.saves[this.b]);
			}
		}
	}

	// Token: 0x06000028 RID: 40 RVA: 0x0000319C File Offset: 0x0000139C
	public void SaveState()
	{
		GameObject gameObject = GameObject.Find("Player");
		string text = "";
		string[] array = new string[7];
		array[0] = text;
		int num = 1;
		Vector3 vector = gameObject.transform.position;
		array[num] = vector.x.ToString();
		array[2] = ":";
		int num2 = 3;
		vector = gameObject.transform.position;
		array[num2] = vector.y.ToString();
		array[4] = ":";
		int num3 = 5;
		vector = gameObject.transform.position;
		array[num3] = vector.x.ToString();
		array[6] = ":";
		text = string.Concat(array);
		for (int i = 0; i < gameObject.transform.childCount; i++)
		{
			string[] array2 = new string[7];
			array2[0] = text;
			int num4 = 1;
			vector = gameObject.transform.GetChild(i).position;
			array2[num4] = vector.x.ToString();
			array2[2] = ":";
			int num5 = 3;
			vector = gameObject.transform.GetChild(i).position;
			array2[num5] = vector.y.ToString();
			array2[4] = ":";
			int num6 = 5;
			vector = gameObject.transform.GetChild(i).position;
			array2[num6] = vector.x.ToString();
			array2[6] = ":";
			text = string.Concat(array2);
			for (int j = 0; j < gameObject.transform.GetChild(i).childCount; j++)
			{
				string[] array3 = new string[7];
				array3[0] = text;
				int num7 = 1;
				vector = gameObject.transform.GetChild(i).GetChild(j).position;
				array3[num7] = vector.x.ToString();
				array3[2] = ":";
				int num8 = 3;
				vector = gameObject.transform.GetChild(i).GetChild(j).position;
				array3[num8] = vector.y.ToString();
				array3[4] = ":";
				int num9 = 5;
				vector = gameObject.transform.GetChild(i).GetChild(j).position;
				array3[num9] = vector.x.ToString();
				array3[6] = ":";
				text = string.Concat(array3);
			}
		}
		Replay.saves.Add(text);
		Debug.Log("BBBBBB");
	}

	// Token: 0x06000029 RID: 41 RVA: 0x000033C8 File Offset: 0x000015C8
	public void LoadState(string str)
	{
		GameObject gameObject = GameObject.Find("Player");
		string[] array = str.Split(":".ToCharArray());
		int num = 0;
		for (int i = 0; i < gameObject.transform.childCount; i++)
		{
			num += 3;
			gameObject.transform.GetChild(i).position = new Vector3(float.Parse(array[num]), float.Parse(array[num + 1]), float.Parse(array[num + 2]));
			for (int j = 0; j < gameObject.transform.GetChild(i).childCount; j++)
			{
				num += 3;
				gameObject.transform.GetChild(i).GetChild(j).position = new Vector3(float.Parse(array[num]), float.Parse(array[num + 1]), float.Parse(array[num + 2]));
			}
		}
		Debug.Log("AAAAAA");
	}

	// Token: 0x0400000D RID: 13
	public static List<string> saves = new List<string>();

	// Token: 0x0400000E RID: 14
	public int b;

	// Token: 0x0400000F RID: 15
	public bool a = true;

	// Token: 0x04000010 RID: 16
	public bool c = false;
}
