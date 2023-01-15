using HarmonyLib;
using ModuleType;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Windows
{
    internal class Server : Window
    {
        public class GetI : TextInput
        {
            public GetI()
            {
                this.text = PlayerPrefs.GetString("GetAddress");
                this.description = "The endpoint to get levels from";
                if (this.text == "") { this.text = "https://delugedrop.com/3Dash/get_json.php"; };
            }

            public override void Update()
            {
                PlayerPrefs.SetString("GetAddress", this.text);

                try
                {
                    foreach (OnlineLevelsHub o in UnityEngine.Object.FindObjectsOfType<OnlineLevelsHub>())
                    {
                        var geturl = typeof(OnlineLevelsHub).GetField("get_url", BindingFlags.NonPublic | BindingFlags.Instance);
                        geturl.SetValue(o, this.text);
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        public class RecentI : TextInput
        {
            public RecentI()
            {
                this.text = PlayerPrefs.GetString("RecentAddress");
                this.description = "The endpoint to get recent levels from";
                if (this.text == "") { this.text = "https://delugedrop.com/3Dash/get_recent.php"; };
            }

            public override void Update()
            {
                PlayerPrefs.SetString("RecentAddress", this.text);

                try
                {
                    foreach (OnlineLevelsHub o in UnityEngine.Object.FindObjectsOfType<OnlineLevelsHub>())
                    {
                        var recurl = typeof(OnlineLevelsHub).GetField("get_recent_url", BindingFlags.NonPublic | BindingFlags.Instance);
                        recurl.SetValue(o, this.text);
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        public class ResetRecents : Button
        {
            public ResetRecents()
            {
                this.name = "Reset Recents";
                this.description = "Fetch the recent levels again";
            }

            public override void OnClick()
            {
                foreach (OnlineLevelsHub o in UnityEngine.Object.FindObjectsOfType<OnlineLevelsHub>())
                {
                    for (int i = 0; i < o.recentContent.childCount; i++)
                    {
                        UnityEngine.Object.Destroy(o.recentContent.GetChild(i));
                    }
                    typeof(OnlineLevelsHub).GetMethod("LoadRecentLevels").Invoke(o, null);
                }
            }
        }

        public class PublishI : TextInput
        {
            public PublishI()
            {
                this.text = PlayerPrefs.GetString("PublishAddress");
                this.description = "The endpoint to publish a level";
                if (this.text == "") { this.text = "https://delugedrop.com/3Dash/push_level_data.php"; };
            }

            public override void Update()
            {
                PlayerPrefs.SetString("PublishAddress", this.text);

                try
                {
                    foreach (Submission o in UnityEngine.Object.FindObjectsOfType<Submission>())
                    {
                        var seturl = typeof(Submission).GetField("set_url", BindingFlags.NonPublic | BindingFlags.Instance);
                        seturl.SetValue(o, this.text);
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        public class MG95 : Module
        {
            public MG95()
            {
                this.name = "MG95";
                this.description = "Uses MG95's server, It's really special so it gets it's own module (:";
            }

            public override void Update()
            {
                try
                {
                    foreach (Submission o in UnityEngine.Object.FindObjectsOfType<Submission>())
                    {
                        // TODO
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        public Server()
        {
            this.name = "Server";
            
            this.modules.Add(new MG95());
            if (!this.modules[0].enabled)
            {
                this.modules.Add(new GetI());
                this.modules.Add(new RecentI());
                this.modules.Add(new PublishI());
                this.modules.Add(new ResetRecents());
            }
        }
    }
}
