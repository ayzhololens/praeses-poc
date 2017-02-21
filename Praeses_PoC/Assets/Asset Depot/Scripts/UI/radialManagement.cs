using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using HoloToolkit.Examples.GazeRuler;

namespace HoloToolkit.Unity
{
    public class radialManagement : MonoBehaviour
    {

        public GameObject RadialMenu;

        //public GameObject RadialAlt;
        //public GameObject RadialAlt2;
        //public GameObject RadialAlt3;
        //public int radialCounter;
        //public int radialMode;

        public Transform RadialHolder;
        sourceManager sourceManager;
        GazeManager gazeManager;
        public bool isActive;
        public annotationManager annotManager;
        public GameObject focusedButton;
        bool radialOpenNotClicked;
        public GameObject line;
        public GameObject radialCountIndicator;
        public int radialCounter;
        public int countMax;



        //// Use this for initialization
        void Start()
        {
            sourceManager = sourceManager.Instance;
            gazeManager = GazeManager.Instance;
        }




        // Update is called once per frame
        void Update()
        {


            RadialMenu.transform.LookAt(Camera.main.transform);


            //get focused object
            if (gazeManager.HitObject != null && gazeManager.HitObject.tag == "Button")
            {
                focusedButton = gazeManager.HitObject;
            }

            //clear focused object
            else if (gazeManager.HitObject == null || gazeManager.HitObject.tag != "Button")
            {
                focusedButton = null;
            }

            //released pinch and radial is still active so hide the line or hide line if not looking at menu
            if ((gazeManager.HitObject.tag != "Button" && gazeManager.HitObject.tag != "Backplate") || radialOpenNotClicked)
            {
                line.GetComponent<LineTest>().line.SetActive(false);
                line.SetActive(false);
                Debug.Log("line off");
            }

            //looking at menu so dont hide the line
            else if (!line.activeSelf && (gazeManager.HitObject.tag == "Button" || gazeManager.HitObject.tag == "Backplate") && !radialOpenNotClicked)
            {
                line.SetActive(true);
                line.GetComponent<LineTest>().line.SetActive(true);
                Debug.Log("line on");

            }

            //radial
            if (sourceManager.sourcePressed && !isActive && !annotManager.annotating)
            {
                radialCounter += 1;


                if (radialCounter == Mathf.Round(countMax / 3))
                {
                    startRadialCounter();
                }

                if (radialCounter == countMax)
                {
                    turnOnRadialMenu();
                    radialCountIndicator.transform.GetChild(0).GetComponent<Animator>().SetTrigger("radialStop");
                }

            }
            if (!sourceManager.sourcePressed && !isActive)
            {
                radialCounter = 0;
                radialCountIndicator.transform.GetChild(0).GetComponent<Animator>().SetTrigger("radialStop");

            }


            if (!sourceManager.sourcePressed && isActive && !annotManager.annotating && gazeManager.HitObject.tag != "Button")
            {
                radialOpenNotClicked = true;

            }

            if (sourceManager.sourcePressed && isActive && radialOpenNotClicked && gazeManager.HitObject.tag != "Button")
            {
                turnOffRadialMenu();
                radialOpenNotClicked = false;
            }

            if (!sourceManager.sourcePressed && isActive && !annotManager.annotating && gazeManager.HitObject.tag == "Button" && !radialOpenNotClicked)
            {
                turnOffRadialMenu();
            }

        }

        public void turnOnRadialMenu()
        {
            radialCounter = 0;
            RadialMenu.SetActive(true);
            RadialMenu.transform.position = RadialHolder.position;
            RadialMenu.transform.LookAt(Camera.main.transform);
            isActive = true;
            line.SetActive(true);
            line.GetComponent<LineTest>().line.SetActive(true);
            radialCountIndicator.SetActive(false);


        }

        public void startRadialCounter()
        {
            radialCountIndicator.SetActive(true);
            radialCountIndicator.transform.position = RadialHolder.position;
            radialCountIndicator.transform.LookAt(Camera.main.transform);
            radialCountIndicator.transform.GetChild(0).GetComponent<Animator>().SetTrigger("radialStart");


        }

        public void turnOffRadialMenu()
        {
            float lineScale = line.GetComponent<LineTest>().scale;

            if (focusedButton == null)
            {
                BroadcastMessage("OnGazeLeave");
                RadialMenu.SetActive(false);
                RadialMenu.transform.position = RadialHolder.position;
                RadialMenu.transform.LookAt(Camera.main.transform);
                isActive = false;
                line.GetComponent<LineTest>().line.transform.localScale = new Vector3(lineScale, lineScale, lineScale);
                line.SetActive(false);
                line.GetComponent<LineTest>().line.SetActive(false);

            }

            if (focusedButton != null)
            {


                BroadcastMessage("OnGazeLeave");
                focusedButton.SendMessage("OnSelect", SendMessageOptions.DontRequireReceiver);
                RadialMenu.SetActive(false);
                RadialMenu.transform.position = RadialHolder.position;
                RadialMenu.transform.LookAt(Camera.main.transform);
                focusedButton = null;
                isActive = false;
                line.GetComponent<LineTest>().line.transform.localScale = new Vector3(lineScale, lineScale, lineScale);
                line.SetActive(false);
                line.GetComponent<LineTest>().line.SetActive(false);



            }


        }

    }
}