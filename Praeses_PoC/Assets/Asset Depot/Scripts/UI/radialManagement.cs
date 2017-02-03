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
        public GameObject line;
        public bool canOpen;

        public GameObject up;
        public GameObject down;
        float startPos;
        public GameObject cursor;
        public scrollManager scrollManag;

        public Switcher switcher;

        // Use this for initialization
        void Start()
        {
            gestManager = GestureManager.Instance;
            gazeManager = GazeManager.Instance;
            RadialMenu = RadialAlt;
            canOpen = true;
        }


        void commentedCode()
        {
            /* UPDATE
                        if (radialMode == 0)
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

                        if (radialMode == 1)
                        {
                            RadialMenu.transform.LookAt(Camera.main.transform);
                            if (gestManager.sourcePressed && !isActive && !annotManager.annotating && gazeManager.FocusedObject.tag != "Node")
                            {

                                turnOnRadialMenu();

                            }



                        }
                        */


            /*            if (radialMode == 3 && switcher.optionCounter == 4)
            {
                RadialMenu.transform.LookAt(Camera.main.transform);
                if (gestManager.sourcePressed && !isActive && gazeManager.FocusedObject.tag != "Node")
                {
                    turnOnRadialMenu();
                }
                
                

                if (!gestManager.sourcePressed && isActive )
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



                if (isActive)
                {
                    if(cursor.transform.position.y > startPos)
                    {
                        if (!up.activeSelf)
                        {
                            up.SetActive(true);
                            down.SetActive(false);
                        }

                        scrollManag.holdScrollUp();
                        scrollManag.scrollingDown = false;

                    }

                    if (cursor.transform.position.y < startPos)
                    {
                        if (!down.activeSelf)
                        {
                            up.SetActive(false);
                            down.SetActive(true);
                        }

                        scrollManag.holdScrollDown();
                        scrollManag.scrollingUp = false;

                    }
                }
                else

                {
                        up.SetActive(false);
                        down.SetActive(false);
                    }

                Debug.Log(gazeManager.FocusedObject.tag);
            }
            */
        }

        // Update is called once per frame
        void Update()
        {


            if (radialMode == 2 && canOpen)
            {

                RadialMenu.transform.LookAt(Camera.main.transform);

                if (gazeManager.FocusedObject != null && gazeManager.FocusedObject.tag == "Button")
                {
                    focusedButton = gazeManager.FocusedObject;
                }
                else if (gazeManager.FocusedObject == null)
                {
                    focusedButton = null;
                }

                if ((gazeManager.FocusedObject.tag != "Button" && gazeManager.FocusedObject.tag != "Backplate") || radialOpenNotClicked)
                {
                    line.GetComponent<LineTest>().line.SetActive(false);
                    line.SetActive(false);
                    Debug.Log("line off");
                }
                else if (!line.activeSelf && (gazeManager.FocusedObject.tag == "Button" || gazeManager.FocusedObject.tag == "Backplate") && !radialOpenNotClicked)
                {
                    line.SetActive(true);
                    line.GetComponent<LineTest>().line.SetActive(true);
                    Debug.Log("line on");

                }

                if (gestManager.sourcePressed && !isActive && !annotManager.annotating && gazeManager.FocusedObject.tag != "Node")
                {
                    turnOnRadialMenu();
                }

                if (!gestManager.sourcePressed && isActive && !annotManager.annotating && gazeManager.FocusedObject.tag != "Button")
                {
                    radialOpenNotClicked = true;

                }

                if (gestManager.sourcePressed && isActive && radialOpenNotClicked  && gazeManager.FocusedObject.tag != "Button")
                {
                    turnOffRadialMenu();
                    radialOpenNotClicked = false;
                }

                if (!gestManager.sourcePressed && isActive && !annotManager.annotating && gazeManager.FocusedObject.tag == "Button" && !radialOpenNotClicked)
                {
                    turnOffRadialMenu();
                }



                Debug.Log(gazeManager.FocusedObject.tag);


            }




        }

        public void turnOnRadialMenu()
        {
            RadialMenu.SetActive(true);
            RadialMenu.transform.position = RadialHolder.position;
            RadialMenu.transform.LookAt(Camera.main.transform);
            isActive = true;

            //test
            if (radialMode != 3)
            {
                line.SetActive(true);
                line.GetComponent<LineTest>().line.SetActive(true);

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
                line.SetActive(false);
                line.GetComponent<LineTest>().line.SetActive(false);
            }

            if (focusedButton != null)
            {
                //if(radialMode == 0)
                //{
                //    BroadcastMessage("OnGazeLeave");
                //    focusedButton.SendMessage("OnSelect", SendMessageOptions.DontRequireReceiver);
                //    RadialMenu.SetActive(false);
                //    RadialMenu.transform.position = RadialHolder.position;
                //    RadialMenu.transform.LookAt(Camera.main.transform);
                //    isActive = false;
                //}   

                //if(radialMode == 1)
                //{
                //    BroadcastMessage("OnGazeLeave");
                //    RadialMenu.SetActive(false);
                //    RadialMenu.transform.position = RadialHolder.position;
                //    RadialMenu.transform.LookAt(Camera.main.transform);
                //    isActive = false;
                //}

                if(radialMode == 2)
                {
                                 
                    BroadcastMessage("OnGazeLeave");
                    focusedButton.SendMessage("OnSelect", SendMessageOptions.DontRequireReceiver);
                    RadialMenu.SetActive(false);
                    RadialMenu.transform.position = RadialHolder.position;
                    RadialMenu.transform.LookAt(Camera.main.transform);
                    isActive = false;
                    line.SetActive(false);
                    line.GetComponent<LineTest>().line.SetActive(false);
                }
                Invoke("opener", .3f);
                canOpen = false;



            }

        }

        void opener()
        {
            canOpen = true;
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

                line.SetActive(false);
                line.GetComponent<LineTest>().line.SetActive(false);
            }
        }

        public void switchRadial()
        {
            //turnOffRadialMenu();
            //radialCounter += 1;

            //if (radialCounter >= 3)
            //{
            //    radialCounter = 0;
            //}

            //if (radialCounter == 0)
            //{
            //    RadialMenu = RadialAlt;
            //}
            //else if (radialCounter == 1)
            //{
            //    RadialMenu = RadialAlt2;
            //}
            //else if (radialCounter == 2)
            //{
            //    RadialMenu = RadialAlt3;
            //}
        }

        public void Mode()
        {
            //turnOffRadialMenu();
            //radialMode += 1;
            //if(radialMode >= 3)
            //{
            //    radialMode = 0;
            //}

            // if (radialMode == 1)
            //{
            //    //RadialMenu.GetComponent<SimpleTagalong>().enabled = true;
            //}
            //else if (radialMode == 0)
            //{
            //    //RadialMenu.GetComponent<SimpleTagalong>().enabled = false;
            //}
        }
    }
}