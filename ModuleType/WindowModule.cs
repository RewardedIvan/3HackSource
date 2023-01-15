using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules
{
    public class WindowModule : Module
    {
        public WindowModule(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        public override void Update()
        {
            foreach (Window w in ModMain.cwm.wnds)
            {
                if (w.name == this.name)
                {
                    w.render = this.enabled;
                }
            }
        }
    }
}
