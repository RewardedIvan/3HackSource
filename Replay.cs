// Decompiled with JetBrains decompiler
// Type: Replay
// Assembly: Hacks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7044930E-2DB6-478E-8870-F3754E75DBEE
// Assembly location: C:\Users\Rewar\Desktop\3Dash Windows v1.2\Mods\Hacks.dll

using System.Collections.Generic;
using UnityEngine;

public class Replay
{
  public static List<string> saves = new List<string>();
  public int b;
  public bool a = true;
  public bool c = false;

  public void Update()
  {
    if (Input.GetKeyDown((KeyCode) 116))
      this.c = !this.c;
    if (!Input.GetKeyDown((KeyCode) 121))
      return;
    PathFollower.distanceTravelled = 0.0f;
    this.a = !this.a;
  }

  public void LateUpdate()
  {
    if (!this.c || PauseMenuManager.paused)
      return;
    if (this.a)
    {
      this.SaveState();
    }
    else
    {
      ++this.b;
      this.LoadState(Replay.saves[this.b]);
    }
  }

  public void SaveState()
  {
    GameObject gameObject = GameObject.Find("Player");
    string str = "" + gameObject.transform.position.x.ToString() + ":" + gameObject.transform.position.y.ToString() + ":" + gameObject.transform.position.x.ToString() + ":";
    for (int index1 = 0; index1 < gameObject.transform.childCount; ++index1)
    {
      str = str + gameObject.transform.GetChild(index1).position.x.ToString() + ":" + gameObject.transform.GetChild(index1).position.y.ToString() + ":" + gameObject.transform.GetChild(index1).position.x.ToString() + ":";
      for (int index2 = 0; index2 < gameObject.transform.GetChild(index1).childCount; ++index2)
      {
        string[] strArray = new string[7]
        {
          str,
          gameObject.transform.GetChild(index1).GetChild(index2).position.x.ToString(),
          ":",
          null,
          null,
          null,
          null
        };
        Vector3 position = gameObject.transform.GetChild(index1).GetChild(index2).position;
        strArray[3] = position.y.ToString();
        strArray[4] = ":";
        position = gameObject.transform.GetChild(index1).GetChild(index2).position;
        strArray[5] = position.x.ToString();
        strArray[6] = ":";
        str = string.Concat(strArray);
      }
    }
    Replay.saves.Add(str);
    Debug.Log((object) "BBBBBB");
  }

  public void LoadState(string str)
  {
    GameObject gameObject = GameObject.Find("Player");
    string[] strArray = str.Split(":".ToCharArray());
    int index1 = 0;
    for (int index2 = 0; index2 < gameObject.transform.childCount; ++index2)
    {
      index1 += 3;
      gameObject.transform.GetChild(index2).position = new Vector3(float.Parse(strArray[index1]), float.Parse(strArray[index1 + 1]), float.Parse(strArray[index1 + 2]));
      for (int index3 = 0; index3 < gameObject.transform.GetChild(index2).childCount; ++index3)
      {
        index1 += 3;
        gameObject.transform.GetChild(index2).GetChild(index3).position = new Vector3(float.Parse(strArray[index1]), float.Parse(strArray[index1 + 1]), float.Parse(strArray[index1 + 2]));
      }
    }
    Debug.Log((object) "AAAAAA");
  }
}
