using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Modules
{
    public class DontRotateCam : Module
    {
        public DontRotateCam()
        {
            this.name = "Dont rotate camera";
            this.description = "Dont rotate the camera";
        }

        public override void Update()
        {
            if (this.enabled)
            {
                UnityEngine.Object.FindObjectOfType<Camera>().transform.eulerAngles = Vector3.zero;
            }
        }
    }
}
