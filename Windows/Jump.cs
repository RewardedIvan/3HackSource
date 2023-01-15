using MelonLoader;
using ModuleType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Windows
{
    public class SceneButton : Button
    {
        int SceneIndex = 0;
        bool start = true;

        public SceneButton(int SceneIndex)
        {
            this.SceneIndex = SceneIndex;
        }

        public override void Update()
        {
            if (start) {
                this.name = System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(SceneIndex));
                this.description = "Switches to the scene named \"" + this.name + "\"";
            }
        }

        public override void OnClick()
        {
            SceneManager.LoadScene(SceneIndex);
        }
    }

    public class Jump : Window
    {
        public Jump()
        {
            this.name = "Jump";

            for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                this.modules.Add(new SceneButton(i));
            }
        }
    }
}
