using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity
{
    public class unhookIcons : MonoBehaviour {

        public followCursorScript followCur;


        private void OnTriggerEnter(Collider other)
        {
            followCur.iconIndex = 0;
        }

        private void OnTriggerExit(Collider other)
        {
            print("guiExit");
        }

    }
}
