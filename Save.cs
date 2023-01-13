// Decompiled with JetBrains decompiler
// Type: Save
// Assembly: Hacks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7044930E-2DB6-478E-8870-F3754E75DBEE
// Assembly location: C:\Users\Rewar\Desktop\3Dash Windows v1.2\Mods\Hacks.dll

using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Save
{
  public static string path;
  public static string header;

  public static void SaveToFile()
  {
    Save.path = Application.dataPath;
    string str1 = "[modules]\n";
    if (Application.platform == 1)
      Save.path += "/../../";
    else if (Application.platform == 2)
      Save.path += "/../";
    Save.path += "save.ini";
    foreach (Window wnd in ModMain.cwm.wnds)
    {
      foreach (Module module in wnd.modules)
        str1 = str1 + module.name + ":" + module.enabled.ToString() + ":" + module.keybind.ToString() + "\n";
    }
    string str2 = str1 + "[pos]\n";
    foreach (Window wnd in ModMain.cwm.wnds)
    {
      string[] strArray = new string[7]
      {
        str2,
        wnd.name,
        ":",
        null,
        null,
        null,
        null
      };
      float num = ((Rect) ref wnd.rect).x;
      strArray[3] = num.ToString();
      strArray[4] = ":";
      num = ((Rect) ref wnd.rect).y;
      strArray[5] = num.ToString();
      strArray[6] = "\n";
      str2 = string.Concat(strArray);
    }
    if (!File.Exists(Save.path))
      File.Create(Save.path);
    string contents = str2 + "[settings]\n";
    foreach (Window wnd in ModMain.cwm.wnds)
    {
      foreach (Module module in wnd.modules)
      {
        foreach (ModuleSetting setting in module.settings)
          contents = contents + setting.name + ":" + setting.enabled.ToString() + ":" + module.name + "\n";
      }
    }
    if (!File.Exists(Save.path))
      File.Create(Save.path);
    File.WriteAllText(Save.path, contents);
  }

  public static void LoadFromFile()
  {
    Save.header = "modules";
    Save.path = Application.dataPath;
    if (Application.platform == 1)
      Save.path += "/../../";
    else if (Application.platform == 2)
      Save.path += "/../";
    Save.path += "save.ini";
    if (!File.Exists(Save.path))
      return;
    foreach (string line in File.ReadAllText(Save.path).Split("\n".ToCharArray()))
    {
      if (line.StartsWith("[") && line.EndsWith("]"))
        Save.header = line.Substring(1, line.Length - 2);
      else
        Save.HandleLine(line);
    }
  }

  public static void HandleLine(string line)
  {
    string[] strArray = line.Split(":".ToCharArray());
    switch (Save.header)
    {
      case "pos":
        using (List<Window>.Enumerator enumerator = ModMain.cwm.wnds.GetEnumerator())
        {
          while (enumerator.MoveNext())
          {
            Window current = enumerator.Current;
            if (current.name.StartsWith(strArray[0]))
            {
              ((Rect) ref current.rect).x = float.Parse(strArray[1]);
              ((Rect) ref current.rect).y = float.Parse(strArray[2]);
            }
          }
          break;
        }
      case "modules":
        using (List<Window>.Enumerator enumerator = ModMain.cwm.wnds.GetEnumerator())
        {
          while (enumerator.MoveNext())
          {
            foreach (Module module in enumerator.Current.modules)
            {
              try
              {
                if (module.name == strArray[0])
                {
                  module.enabled = bool.Parse(strArray[1]);
                  if (strArray[2] != "None")
                  {
                    KeyCode keyCode = (KeyCode) Enum.Parse(typeof (KeyCode), strArray[2]);
                    module.keybind = keyCode;
                    module.OnLoadedSave();
                  }
                }
              }
              catch
              {
              }
            }
          }
          break;
        }
      case "settings":
        foreach (Window wnd in ModMain.cwm.wnds)
        {
          foreach (Module module in wnd.modules)
          {
            if (module.name == strArray[2])
            {
              foreach (ModuleSetting setting in module.settings)
              {
                if (setting.name == strArray[0])
                  setting.enabled = bool.Parse(strArray[1]);
              }
            }
          }
        }
        break;
    }
  }
}
