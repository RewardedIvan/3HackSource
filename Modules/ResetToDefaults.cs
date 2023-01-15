using System.IO;
using UnityEngine;
using ModuleType;

namespace Modules
{
    public class ResetToDefaults : Button
    {
        public ResetToDefaults()
        {
            this.name = "Reset to defaults";
            this.description = "Resets the configuration";
        }

        public override void OnClick()
        {
            string text = Application.dataPath;
            if (Application.platform == RuntimePlatform.OSXPlayer)
            {
                text += "/../../save.ini";
            }
            else if (Application.platform == RuntimePlatform.WindowsPlayer)
            {
                text += "/../save.ini";
            }
            else
            {
                text += "save.ini";
            }
            if (File.Exists(text))
            {
                File.Delete(text);
                PlayerPrefs.DeleteAll();
                Application.Quit();
            }
        }
    }
}
