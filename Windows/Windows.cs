using Modules;
using UnityEngine;
using Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows
{
    public class Windows : Window
    {
        public class GUIModule : Module
        {
            public GUIModule()
            {
                this.name = "GUI";
                this.description = "Configure this menu";
            }

            public override void Update()
            {
                foreach (Window w in ModMain.cwm.wnds)
                {
                    if (w.name == "GUI")
                    {
                        w.render = this.enabled;
                    }
                }
            }
        }

        public class ServerModule : Module
        {
            public ServerModule()
            {
                this.name = "Server";
                this.description = "Configure the server to connect to";
            }

            public override void Update()
            {
                foreach (Window w in ModMain.cwm.wnds)
                {
                    if (w.name == "Server")
                    {
                        w.render = this.enabled;
                    }
                }
            }
        }

        public Windows()
        {
            this.rect.position = new Vector2(370f, 20f);
            this.name = "Windows";
            this.render = true;

            this.modules.Add(new DebugModule());
            this.modules.Add(new WorldModule());
            this.modules.Add(new PlayerModule());
            this.modules.Add(new GUIModule());
            this.modules.Add(new ClientModule());
            this.modules.Add(new SpeedhackModule());
            this.modules.Add(new OptionsModule());
            this.modules.Add(new StatusModule());
            this.modules.Add(new CreatorModule());
            this.modules.Add(new DisplayModule());
            this.modules.Add(new ReplayModule());
            this.modules.Add(new ServerModule());
        }
    }
}
