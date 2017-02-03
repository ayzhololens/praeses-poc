using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity
{

    public class scrollManager : MonoBehaviour
    {

        public GameObject[] paneLoc;
        public GameObject[] paneContent;
        public int displayCount;
        public GameObject[] altContent;
        public GameObject upButton;
        public GameObject downButton;
        public float speed;
        public float holdSpeed;
        public bool scrollingDown;
        public bool scrollingUp;
        public int scrollCheck;
        public bool holdScroll;
        public bool gazeScroll;
        public bool casino;
        Vector3 startScale;
        public float scaleMult;
        public bool radialHold;
        public GameObject frontHolder;
        public GameObject line;
        GameObject lineLine;
        GameObject lineEnd;
        Vector3 startPos;
        public GameObject cursor;




        // Use this for initialization
        void Start()
        {
            startScale = paneContent[1].transform.localScale;

            for (int i = 0; i < paneContent.Length; i++)
            {
                paneContent[i].transform.position = paneLoc[i + 1].transform.position;
                if (i > displayCount - 1 && !holdScroll)
                {
                    paneContent[i].transform.GetChild(0).gameObject.SetActive(false);
                }
            }

            if(line!= null)
            {
                lineEnd = line.GetComponent<LineTest>().end;
                lineLine = line.GetComponent<LineTest>().line;
            }




        }

        // Update is called once per frame
        void Update()
        {

            if (holdScroll && !gazeScroll)
            {
                if (GazeManager.Instance.FocusedObject == upButton && GestureManager.Instance.sourcePressed)
                {
                    holdScrollUp();
                    scrollingDown = false;
                }

                if (GazeManager.Instance.FocusedObject == downButton && GestureManager.Instance.sourcePressed)
                {
                    holdScrollDown();
                    scrollingUp = false;
                }

                if (!GestureManager.Instance.sourcePressed)
                {
                    scrollingUp = false;
                    scrollingDown = false;
                }

            }

            if (gazeScroll && holdScroll)
            {
                if (GazeManager.Instance.FocusedObject == upButton)
                {
                    holdScrollUp();
                    scrollingDown = false;
                }

                if (GazeManager.Instance.FocusedObject == downButton)
                {
                    holdScrollDown();
                    scrollingUp = false;
                }

                if (GazeManager.Instance.FocusedObject != downButton && GazeManager.Instance.FocusedObject != upButton)
                {
                    scrollingUp = false;
                    scrollingDown = false;
                }
            }

            if (radialHold && GestureManager.Instance.sourcePressed)
            {
                if (!line.activeSelf)
                {
                    //radialHolder.transform.position = frontHolder.transform.position;
                    line.SetActive(true);
                    lineEnd.SetActive(true);
                    lineLine.SetActive(true);
                    startPos = line.transform.position;
                }

                lineEnd.transform.position = new Vector3(lineEnd.transform.position.x, cursor.transform.position.y, lineEnd.transform.position.z);
                //gazeScroll = true;

                if(lineEnd.transform.position.y> startPos.y+.02f)
                {
                    holdScrollUp();
                    lineEnd.transform.GetChild(0).gameObject.SetActive(true);
                    lineEnd.transform.GetChild(1).gameObject.SetActive(false);
                    scrollingDown = false;

                    if(lineEnd.transform.position.y > startPos.y + .05f)
                    {
                        lineEnd.transform.position = new Vector3(lineEnd.transform.position.x, startPos.y + .05f, lineEnd.transform.position.z);
                    }
                }
                if (lineEnd.transform.position.y < startPos.y-.02f)
                {
                    holdScrollDown();
                    lineEnd.transform.GetChild(0).gameObject.SetActive(false);
                    lineEnd.transform.GetChild(1).gameObject.SetActive(true);
                    scrollingUp = false;

                    if (lineEnd.transform.position.y < startPos.y - .05f)
                    {
                        lineEnd.transform.position = new Vector3(lineEnd.transform.position.x, startPos.y - .05f, lineEnd.transform.position.z);
                    }
                }


            }
            if (radialHold && !GestureManager.Instance.sourcePressed)
            {
                gazeScroll = false;
                line.SetActive(false);
                lineEnd.SetActive(false);
                lineLine.SetActive(false);
            }




            if (!holdScroll)
            {
                if (scrollingDown &&!casino)
                {
                    scrollDown();
                }

                if (scrollingUp &&!casino)
                {
                    scrollUp();
                }

                if (scrollingDown && casino)
                {
                    scrollDownCasino();
                }

                if (scrollingUp && casino)
                {
                    scrollUpCasino();
                }
            }


            if (scrollCheck == paneContent.Length)
            {
                scrollingDown = false;
                scrollingUp = false;
                reorderArray();
            }
        }

        public void startScrollDown()
        {
            scrollingDown = true;

        }

        public void startScrollUp()
        {

            scrollingUp = true;

            if (!holdScroll)
            {
                paneContent[paneContent.Length - 1].transform.position = paneLoc[0].transform.position;
                Debug.Log("yoo");
            }

        }

        public void scrollDown()
        {
            if (!scrollingUp)
            {
                scrollCheck = 0;

                for (int u = 0; u < altContent.Length; u++)
                {
                    altContent[u] = null;
                }



                for (int i = 0; i < paneContent.Length; i++)
                {
                    if ((i - 1) < 0)
                    {
                        paneContent[i].transform.position = Vector3.Lerp(paneContent[i].transform.position, paneLoc[0].transform.position, speed);



                        if (paneContent[i].transform.position == paneLoc[0].transform.position)
                        {
                            paneContent[i].transform.GetChild(0).gameObject.SetActive(false);
                            paneContent[i].transform.position = paneLoc[paneLoc.Length - 1].transform.position;
                            altContent[altContent.Length - 1] = paneContent[0];
                            scrollCheck += 1;
                        }

                    }
                    else
                    {
                        if (i > displayCount + 1)
                        {
                            paneContent[i].transform.GetChild(0).gameObject.SetActive(false);
                        }
                        else if (i < displayCount + 1)
                        {
                            paneContent[i].transform.GetChild(0).gameObject.SetActive(true);
                        }

                        paneContent[i].transform.position = Vector3.Lerp(paneContent[i].transform.position, paneLoc[i].transform.position, speed);

                        if (paneContent[i].transform.position == paneLoc[i].transform.position)
                        {
                            Debug.Log(paneContent[i].name + " Complete!!");
                            altContent[i - 1] = paneContent[i];
                            scrollCheck += 1;


                        }
                    }

                }
            }

        }

        public void scrollUp()
        {
            if (!scrollingDown)
            {
                scrollCheck = 0;

                for (int u = 0; u < altContent.Length; u++)
                {
                    altContent[u] = null;
                }
                for (int i = 0; i < paneContent.Length; i++)
                {
                    if (i == paneContent.Length - 1)
                    {
                        paneContent[i].transform.GetChild(0).gameObject.SetActive(true);

                        paneContent[i].transform.position = Vector3.Lerp(paneContent[i].transform.position, paneLoc[1].transform.position, speed);



                        if (paneContent[i].transform.position == paneLoc[1].transform.position)
                        {
                            altContent[0] = paneContent[i];
                            scrollCheck += 1;
                        }

                    }
                    else
                    {
                        paneContent[i].transform.position = Vector3.Lerp(paneContent[i].transform.position, paneLoc[i + 2].transform.position, speed);

                        if (paneContent[i].transform.position == paneLoc[i + 2].transform.position)
                        {
                            Debug.Log(paneContent[i].name + " Complete!!");
                            altContent[i + 1] = paneContent[i];
                            scrollCheck += 1;

                            if (i > displayCount - 2)
                            {
                                paneContent[i].transform.GetChild(0).gameObject.SetActive(false);
                            }
                        }
                    }
                }

            }
        }

        public void scrollDownCasino()
        {
            if (!scrollingUp)
            {
                scrollCheck = 0;

                for (int u = 0; u < altContent.Length; u++)
                {
                    altContent[u] = null;
                }



                for (int i = 0; i < paneContent.Length; i++)
                {
                    if ((i - 1) < 0)
                    {
                        paneContent[i].transform.position = Vector3.Lerp(paneContent[i].transform.position, paneLoc[0].transform.position, speed);



                        if (paneContent[i].transform.position == paneLoc[0].transform.position)
                        {
                            paneContent[i].transform.GetChild(0).gameObject.SetActive(false);
                            paneContent[i].transform.position = paneLoc[paneLoc.Length - 1].transform.position;
                            altContent[altContent.Length - 1] = paneContent[0];
                            scrollCheck += 1;
                        }

                    }
                    else
                    {
                        if (i > displayCount + 1)
                        {
                            paneContent[i].transform.GetChild(0).gameObject.SetActive(false);
                        }
                        else if (i < displayCount + 1)
                        {
                            paneContent[i].transform.GetChild(0).gameObject.SetActive(true);
                        }

                        paneContent[i].transform.position = Vector3.Lerp(paneContent[i].transform.position, paneLoc[i].transform.position, speed);
                        if(i != 2)
                        {

                        }
                        if (paneContent[i].transform.position == paneLoc[i].transform.position)
                        {

                            Debug.Log(paneContent[i].name + " Complete!!");
                            altContent[i - 1] = paneContent[i];
                            scrollCheck += 1;


                        }
                    }

                }
            }

        }


        public void scrollUpCasino()
        {
            if (!scrollingDown)
            {
                scrollCheck = 0;

                for (int u = 0; u < altContent.Length; u++)
                {
                    altContent[u] = null;
                }
                for (int i = 0; i < paneContent.Length; i++)
                {
                    if (i == paneContent.Length - 1)
                    {
                        paneContent[i].transform.GetChild(0).gameObject.SetActive(true);

                        paneContent[i].transform.position = Vector3.Lerp(paneContent[i].transform.position, paneLoc[1].transform.position, speed);



                        if (paneContent[i].transform.position == paneLoc[1].transform.position)
                        {
                            altContent[0] = paneContent[i];
                            scrollCheck += 1;
                        }

                    }
                    else
                    {
                        paneContent[i].transform.position = Vector3.Lerp(paneContent[i].transform.position, paneLoc[i + 2].transform.position, speed);

                        if (paneContent[i].transform.position == paneLoc[i + 2].transform.position)
                        {
                            Debug.Log(paneContent[i].name + " Complete!!");
                            altContent[i + 1] = paneContent[i];
                            scrollCheck += 1;



                            if (i > displayCount - 2)
                            {
                                paneContent[i].transform.GetChild(0).gameObject.SetActive(false);
                            }
                        }
                    }
                }

            }
        }

        public void holdScrollUp()
        {
            scrollingUp = true;
            for (int i = 0; i < paneContent.Length; i++)
            {
                paneContent[i].transform.localPosition = new Vector3(paneContent[i].transform.localPosition.x, paneContent[i].transform.localPosition.y + holdSpeed, paneContent[i].transform.localPosition.z);

            }
        }

        public void holdScrollDown()
        {
            scrollingDown = true;
            for (int i = 0; i < paneContent.Length; i++)
            {
                paneContent[i].transform.localPosition = new Vector3(paneContent[i].transform.localPosition.x, paneContent[i].transform.localPosition.y - holdSpeed, paneContent[i].transform.localPosition.z);

            }
        }




        public void reorderArray()
        {


            for (int i = 0; i < altContent.Length; i++)
            {
                paneContent[i] = altContent[i];
            }
        }
    }
}