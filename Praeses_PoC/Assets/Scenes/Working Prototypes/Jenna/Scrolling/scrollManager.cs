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
        public float speed;
        public float holdSpeed;
        public bool scrollingDown;
        public bool scrollingUp;
        public int scrollCheck;
        public bool holdScroll;



        // Use this for initialization
        void Start()
        {


            for (int i = 0; i < paneContent.Length; i++)
            {
                paneContent[i].transform.position = paneLoc[i + 1].transform.position;
                if (i > displayCount - 1 && !holdScroll)
                {
                    paneContent[i].transform.GetChild(0).gameObject.SetActive(false);
                }
            }




        }

        // Update is called once per frame
        void Update()
        {
            if (GestureManager.Instance.sourcePressed && scrollingUp && holdScroll)
            {
                holdScrollUp();
            }

            if (GestureManager.Instance.sourcePressed && scrollingDown && holdScroll)
            {
                holdScrollDown();
            }

            if (!GestureManager.Instance.sourcePressed && scrollingUp)
            {
                scrollingUp = false;
            }

            if (!GestureManager.Instance.sourcePressed && scrollingDown)
            {
                scrollingDown = false;
            }





            if (!holdScroll)
            {
                if (scrollingDown)
                {
                    scrollDown();
                }

                if (scrollingUp)
                {
                    scrollUp();
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