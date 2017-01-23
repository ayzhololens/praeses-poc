using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity
{
    public class radialManagement : MonoBehaviour
    {

        public GameObject RadialMenu;
        public Transform RadialHolder;
        GestureManager gestManager;
        GazeManager gazeManager;
        public bool isActive;
        public annotationManager annotManager;
        public GameObject focusedButton;

        // Use this for initialization
        void Start()
        {
            gestManager = GestureManager.Instance;
            gazeManager = GazeManager.Instance;
        }

        // Update is called once per frame
        void Update()
        {
            if(gestManager.sourcePressed && !isActive&& !annotManager.annotating && gazeManager.FocusedObject.tag != "Node")
            {
                turnOnRadialMenu();
            }

            if(!gestManager.sourcePressed && isActive && !annotManager.annotating)
            {
                turnOffRadialMenu();
            }

            if(gazeManager.FocusedObject != null && gazeManager.FocusedObject.tag == "Button")
            {
                focusedButton = gazeManager.FocusedObject;
            }
            else if(gazeManager.FocusedObject == null)
            {
                focusedButton = null;
            }

        }

        public void turnOnRadialMenu()
        {
            RadialMenu.SetActive(true);
            RadialMenu.transform.position = RadialHolder.position;
            RadialMenu.transform.LookAt(Camera.main.transform);
            isActive = true;

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
                BroadcastMessage("OnGazeLeave");
                focusedButton.SendMessage("OnSelect", SendMessageOptions.DontRequireReceiver);
                RadialMenu.SetActive(false);
                RadialMenu.transform.position = RadialHolder.position;
                RadialMenu.transform.LookAt(Camera.main.transform);
                isActive = false;
            }

        }
    }
}