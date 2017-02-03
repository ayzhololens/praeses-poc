using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity
{
    public class magneticObject : MonoBehaviour {

        public void turnOnMagnet()
        {
            MagnetManager.Instance.magnetOn = true;
        }
    }
}

