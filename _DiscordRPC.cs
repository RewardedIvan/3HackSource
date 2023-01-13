// Decompiled with JetBrains decompiler
// Type: _DiscordRPC
// Assembly: Hacks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7044930E-2DB6-478E-8870-F3754E75DBEE
// Assembly location: C:\Users\Rewar\Desktop\3Dash Windows v1.2\Mods\Hacks.dll

using DiscordRPC;

public class _DiscordRPC
{
  public static DiscordRpcClient client;
  public static bool isInitialized = true;

  public static void Initialize()
  {
    try
    {
      _DiscordRPC.client = new DiscordRpcClient("1017689651378667561");
      _DiscordRPC.client.Initialize();
      DiscordRpcClient client = _DiscordRPC.client;
      RichPresence richPresence = new RichPresence();
      ((BaseRichPresence) richPresence).Details = "Loading Rich Presence";
      ((BaseRichPresence) richPresence).State = "";
      ((BaseRichPresence) richPresence).Assets = new Assets()
      {
        LargeImageKey = "3dash_big",
        LargeImageText = "3Dash"
      };
      client.SetPresence(richPresence);
    }
    catch
    {
      _DiscordRPC.isInitialized = true;
    }
  }

  public static void UpdatePresence(string sceneName)
  {
    if (!_DiscordRPC.isInitialized)
      return;
    DiscordRpcClient client1 = _DiscordRPC.client;
    RichPresence richPresence1 = new RichPresence();
    ((BaseRichPresence) richPresence1).Details = "Playing A Level";
    ((BaseRichPresence) richPresence1).State = sceneName + " by Deluge Drop";
    ((BaseRichPresence) richPresence1).Assets = new Assets()
    {
      LargeImageKey = "3dash_big",
      LargeImageText = "3Dash"
    };
    client1.SetPresence(richPresence1);
    _DiscordRPC.client.UpdateStartTime();
    if (sceneName == "Menu")
    {
      DiscordRpcClient client2 = _DiscordRPC.client;
      RichPresence richPresence2 = new RichPresence();
      ((BaseRichPresence) richPresence2).Details = "Browsing The Menus";
      ((BaseRichPresence) richPresence2).State = "";
      ((BaseRichPresence) richPresence2).Assets = new Assets()
      {
        LargeImageKey = "3dash_big",
        LargeImageText = "3Dash"
      };
      client2.SetPresence(richPresence2);
    }
    if (sceneName == "Online Levels Hub")
    {
      DiscordRpcClient client3 = _DiscordRPC.client;
      RichPresence richPresence3 = new RichPresence();
      ((BaseRichPresence) richPresence3).Details = "Browsing Online Levels";
      ((BaseRichPresence) richPresence3).State = "";
      ((BaseRichPresence) richPresence3).Assets = new Assets()
      {
        LargeImageKey = "3dash_big",
        LargeImageText = "3Dash"
      };
      client3.SetPresence(richPresence3);
    }
    if (sceneName == "Online Levels Player")
    {
      DiscordRpcClient client4 = _DiscordRPC.client;
      RichPresence richPresence4 = new RichPresence();
      ((BaseRichPresence) richPresence4).Details = "Playing A Level";
      ((BaseRichPresence) richPresence4).State = LevelEditor.levelName + " by " + LevelEditor.levelAuthor + " (" + LevelEditor.currentID.ToString() + ")";
      ((BaseRichPresence) richPresence4).Assets = new Assets()
      {
        LargeImageKey = "3dash_big",
        LargeImageText = "3Dash"
      };
      RichPresence richPresence5 = richPresence4;
      client4.SetPresence(richPresence5);
    }
    if (sceneName == "Playtester")
    {
      DiscordRpcClient client5 = _DiscordRPC.client;
      RichPresence richPresence6 = new RichPresence();
      ((BaseRichPresence) richPresence6).Details = "Playtesting A Level";
      ((BaseRichPresence) richPresence6).State = LevelEditor.levelName;
      ((BaseRichPresence) richPresence6).Assets = new Assets()
      {
        LargeImageKey = "3dash_big",
        LargeImageText = "3Dash"
      };
      client5.SetPresence(richPresence6);
    }
    if (!(sceneName == "Save Select") && !(sceneName == "HUB") && !(sceneName == "2D Editor") && !(sceneName == "Path Editor") && !(sceneName == "Camera Animator Hub") && !(sceneName == "Camera Animator") && !(sceneName == "Level Settings") && !(sceneName == "Submission"))
      return;
    DiscordRpcClient client6 = _DiscordRPC.client;
    RichPresence richPresence7 = new RichPresence();
    ((BaseRichPresence) richPresence7).Details = "Making A Level";
    ((BaseRichPresence) richPresence7).State = "";
    ((BaseRichPresence) richPresence7).Assets = new Assets()
    {
      LargeImageKey = "3dash_big",
      LargeImageText = "3Dash"
    };
    client6.SetPresence(richPresence7);
  }
}
