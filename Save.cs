using System;
using System.IO;
using UnityEngine;

// Token: 0x02000011 RID: 17
public class Save
{
	// Token: 0x0600002C RID: 44 RVA: 0x000034F0 File Offset: 0x000016F0
	public static void SaveToFile()
	{
		Save.path = Application.dataPath;
		string text = "[modules]\n";
		bool flag = Application.platform == (RuntimePlatform)1;
		if (flag)
		{
			Save.path += "/../../";
		}
		else
		{
			bool flag2 = Application.platform == (RuntimePlatform)2;
			if (flag2)
			{
				Save.path += "/../";
			}
		}
		Save.path += "save.ini";
		foreach (Window window in ModMain.cwm.wnds)
		{
			foreach (Module module in window.modules)
			{
				text = string.Concat(new string[]
				{
					text,
					module.name,
					":",
					module.enabled.ToString(),
					":",
					module.keybind.ToString(),
					"\n"
				});
			}
		}
		text += "[pos]\n";
		foreach (Window window2 in ModMain.cwm.wnds)
		{
			text = string.Concat(new string[]
			{
				text,
				window2.name,
				":",
				window2.rect.x.ToString(),
				":",
				window2.rect.y.ToString(),
				"\n"
			});
		}
		bool flag3 = !File.Exists(Save.path);
		if (flag3)
		{
			File.Create(Save.path);
		}
		text += "[settings]\n";
		foreach (Window window3 in ModMain.cwm.wnds)
		{
			foreach (Module module2 in window3.modules)
			{
				foreach (ModuleSetting moduleSetting in module2.settings)
				{
					text = string.Concat(new string[]
					{
						text,
						moduleSetting.name,
						":",
						moduleSetting.enabled.ToString(),
						":",
						module2.name,
						"\n"
					});
				}
			}
		}
		bool flag4 = !File.Exists(Save.path);
		if (flag4)
		{
			File.Create(Save.path);
		}
		File.WriteAllText(Save.path, text);
	}

	// Token: 0x0600002D RID: 45 RVA: 0x0000387C File Offset: 0x00001A7C
	public static void LoadFromFile()
	{
		Save.header = "modules";
		Save.path = Application.dataPath;
		bool flag = Application.platform == (RuntimePlatform)1;
		if (flag)
		{
			Save.path += "/../../";
		}
		else
		{
			bool flag2 = Application.platform == (RuntimePlatform)2;
			if (flag2)
			{
				Save.path += "/../";
			}
		}
		Save.path += "save.ini";
		bool flag3 = File.Exists(Save.path);
		if (flag3)
		{
			string text = File.ReadAllText(Save.path);
			foreach (string text2 in text.Split("\n".ToCharArray()))
			{
				bool flag4 = text2.StartsWith("[") && text2.EndsWith("]");
				if (flag4)
				{
					Save.header = text2.Substring(1, text2.Length - 2);
				}
				else
				{
					Save.HandleLine(text2);
				}
			}
		}
	}

	// Token: 0x0600002E RID: 46 RVA: 0x00003998 File Offset: 0x00001B98
	public static void HandleLine(string line)
	{
		string[] array = line.Split(":".ToCharArray());
		bool flag = Save.header == "pos";
		if (flag)
		{
			foreach (Window window in ModMain.cwm.wnds)
			{
				bool flag2 = window.name.StartsWith(array[0]);
				if (flag2)
				{
					window.rect.x = float.Parse(array[1]);
					window.rect.y = float.Parse(array[2]);
				}
			}
		}
		else
		{
			bool flag3 = Save.header == "modules";
			if (flag3)
			{
				foreach (Window window2 in ModMain.cwm.wnds)
				{
					foreach (Module module in window2.modules)
					{
						try
						{
							bool flag4 = module.name == array[0];
							if (flag4)
							{
								module.enabled = bool.Parse(array[1]);
								bool flag5 = array[2] != "None";
								if (flag5)
								{
									KeyCode keyCode = (KeyCode)Enum.Parse(typeof(KeyCode), array[2]);
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
			}
			else
			{
				bool flag6 = Save.header == "settings";
				if (flag6)
				{
					foreach (Window window3 in ModMain.cwm.wnds)
					{
						foreach (Module module2 in window3.modules)
						{
							bool flag7 = module2.name == array[2];
							if (flag7)
							{
								foreach (ModuleSetting moduleSetting in module2.settings)
								{
									bool flag8 = moduleSetting.name == array[0];
									if (flag8)
									{
										moduleSetting.enabled = bool.Parse(array[1]);
									}
								}
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x04000011 RID: 17
	public static string path;

	// Token: 0x04000012 RID: 18
	public static string header;
}
