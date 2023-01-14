using ModuleType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Modules
{
    public class Quit : Button
    {
        public Quit() {
            this.name = "Quit";
            this.description = "Quits the game. Usefull for fullscreen users";
        }

        public override void OnClick()
        {
            Application.Quit();
        }
    }
}
