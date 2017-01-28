using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity
{
    public class toggles : MonoBehaviour {

        TextMesh tmObject;
        public int typing;
        bool currentToggleState;
        public GameObject blueCursorObj;
        public GameObject magneticManager;

        // Use this for initialization
        void Start() {
            tmObject = gameObject.GetComponent<TextMesh>();
            currentToggleState = false;

        }

        // Update is called once per frame
        void Update() {

        }

        void toggleOn()
        {
            if (typing == 0)
            {
                tmObject.text = "lerp : on";
                magneticManager.GetComponent<GazeManagerMagnetic>().mixerOn = true;
            }
            else if (typing == 1)
            {
                tmObject.text = "originalCursor : on";
                blueCursorObj.SetActive(true);
            }else if (typing ==2){
                tmObject.text = "glowCursor : on";
                blueCursorObj.SetActive(true);
            }
            currentToggleState = true;
        }

        void toggleOff()
        {
            if (typing == 0)
            {
                tmObject.text = "lerp : off";
                magneticManager.GetComponent<GazeManagerMagnetic>().mixerOn = false;
            }
            else if (typing == 1)
            {
                tmObject.text = "originalCursor : off";
                blueCursorObj.SetActive(false);
            }
            else if (typing == 2)
            {
                tmObject.text = "glowCursor : off";
                blueCursorObj.SetActive(true);
            }
            currentToggleState = false;
        }

        public void toggle()
        {
            if (currentToggleState)
            {
                toggleOff();
            } else
            {
                toggleOn();
            }
        }
    }
}
