using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity
{
    public class radialManagement : MonoBehaviour
    {

        public GameObject RadialMenu;
       
        public GameObject RadialAlt;
        public GameObject RadialAlt2;
        public GameObject RadialAlt3;
        public int radialCounter;
        public int radialMode;
        public Transform RadialHolder;
        GestureManager gestManager;
        GazeManager gazeManager;
        public bool isActive;
        public annotationManager annotManager;
        public GameObject focusedButton;
        bool radialOpenNotClicked;

        // Use this for initialization
        void Start()
        {
            gestManager = GestureManager.Instance;
            gazeManager = GazeManager.Instance;
            RadialMenu = RadialAlt;
        }

        // Update is called once per frame
        void Update()
        {

            if(radialMode == 0)
            {

                RadialMenu.transform.LookAt(Camera.main.transform);
                if (gestManager.sourcePressed && !isActive && !annotManager.annotating && gazeManager.FocusedObject.tag != "Node")
                {
                    turnOnRadialMenu();
                }

                if (!gestManager.sourcePressed && isActive && !annotManager.annotating)
                {
                    turnOffRadialMenu();
                }

                if (gazeManager.FocusedObject != null && gazeManager.FocusedObject.tag == "Button")
                {
                    focusedButton = gazeManager.FocusedObject;
                }
                else if (gazeManager.FocusedObject == null)
                {
                    focusedButton = null;
                }
            }

            if(radialMode == 1)
            {
                RadialMenu.transform.LookAt(Camera.main.transform);
                if (gestManager.sourcePressed && !isActive && !annotManager.annotating && gazeManager.FocusedObject.tag != "Node")
                {

                    turnOnRadialMenu();

                }



            }

            if (radialMode == 2)
            {

                RadialMenu.transform.LookAt(Camera.main.transform);
                if (gestManager.sourcePressed && !isActive && !annotManager.annotating && gazeManager.FocusedObject.tag != "Node")
                {
                    turnOnRadialMenu();
                }
                if (!gestManager.sourcePressed && isActive && !annotManager.annotating && gazeManager.FocusedObject.tag != "Button")
                {
                    radialOpenNotClicked = true;
                }

                if (!gestManager.sourcePressed && isActive && !annotManager.annotating && gazeManager.FocusedObject.tag == "Button" && !radialOpenNotClicked)
                {
                    turnOffRadialMenu();
                }

                if (gazeManager.FocusedObject != null && gazeManager.FocusedObject.tag == "Button")
                {
                    focusedButton = gazeManager.FocusedObject;
                }
                else if (gazeManager.FocusedObject == null)
                {
                    focusedButton = null;
                }


            }


        }

        public void turnOnRadialMenu()
        {
            RadialMenu.SetActive(true);
            RadialMenu.transform.position = RadialHolder.position;
            RadialMenu.transform.LookAt(Camera.main.transform);
            isActive = true;

            if (radialCounter == 0)
            {   

            }

        }

        public void turnOffRadialMenu()
        {
            if(focusedButton == null)
            {
                BroadcastMessage("OnGazeLeave");
                RadialMenu.SetActive(false);
                RadialMenu.transform.position = RadialHolder.position;
                RadialMenu.transform.LookAt(Camera.main.transform);
                isActive = false;
            }

            if (focusedButton != null)
            {
                if(radialMode == 0)
                {
                    BroadcastMessage("OnGazeLeave");
                    focusedButton.SendMessage("OnSelect", SendMessageOptions.DontRequireReceiver);
                    RadialMenu.SetActive(false);
                    RadialMenu.transform.position = RadialHolder.position;
                    RadialMenu.transform.LookAt(Camera.main.transform);
                    isActive = false;
                }   

                if(radialMode == 1)
                {
                    BroadcastMessage("OnGazeLeave");
                    RadialMenu.SetActive(false);
                    RadialMenu.transform.position = RadialHolder.position;
                    RadialMenu.transform.LookAt(Camera.main.transform);
                    isActive = false;
                }

                if(radialMode == 2)
                {
                    BroadcastMessage("OnGazeLeave");
                    focusedButton.SendMessage("OnSelect", SendMessageOptions.DontRequireReceiver);
                    RadialMenu.SetActive(false);
                    RadialMenu.transform.position = RadialHolder.position;
                    RadialMenu.transform.LookAt(Camera.main.transform);
                    isActive = false;
                }

            }

        }

        public void turnOffRadialMenuAlt()
        {
            if (radialOpenNotClicked)
            {
                BroadcastMessage("OnGazeLeave");
                //focusedButton.SendMessage("OnSelect", SendMessageOptions.DontRequireReceiver);
                RadialMenu.SetActive(false);
                RadialMenu.transform.position = RadialHolder.position;
                RadialMenu.transform.LookAt(Camera.main.transform);
                isActive = false;
                radialOpenNotClicked = false;
            }
        }

        public void switchRadial()
        {
            turnOffRadialMenu();
            radialCounter += 1;

            if (radialCounter >= 3)
            {
                radialCounter = 0;
            }

            if (radialCounter == 0)
            {
                RadialMenu = RadialAlt;
            }
            else if (radialCounter == 1)
            {
                RadialMenu = RadialAlt2;
            }
            else if (radialCounter == 2)
            {
                RadialMenu = RadialAlt3;
            }
        }

        public void Mode()
        {
            turnOffRadialMenu();
            radialMode += 1;
            if(radialMode >= 3)
            {
                radialMode = 0;
            }

             if (radialMode == 1)
            {
                //RadialMenu.GetComponent<SimpleTagalong>().enabled = true;
            }
            else if (radialMode == 0)
            {
                //RadialMenu.GetComponent<SimpleTagalong>().enabled = false;
            }
        }
    }
}