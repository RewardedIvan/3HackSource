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
        public Windows()
        {
            this.rect.position = new Vector2(370f, 20f);
            this.name = "Windows";
            this.render = true;

            this.modules.Add(new WindowModule("Debug", "Display debug information"));
            this.modules.Add(new WindowModule("World", "Configure how the world works"));
            this.modules.Add(new WindowModule("Player", "Configure how the player functions"));
            this.modules.Add(new WindowModule("GUI", "Configure the GUI your looking at right now"));
            this.modules.Add(new WindowModule("Client", "Client configuration"));
            this.modules.Add(new WindowModule("Speedhack", "Hack the speed of your game"));
            this.modules.Add(new WindowModule("Options", "Options for a module you've right clicked"));
            this.modules.Add(new WindowModule("Status", ""));
            this.modules.Add(new WindowModule("Creator", "Configure the editor"));
            this.modules.Add(new WindowModule("Display", "Configure how you see the game"));
            this.modules.Add(new WindowModule("Replay", "Replay a level you've beaten"));
            this.modules.Add(new WindowModule("Server", "Configure the server your connecting to"));
            this.modules.Add(new WindowModule("Jump", "Jump to other scenes"));
        }
    }
}
