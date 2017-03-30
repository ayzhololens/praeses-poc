using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;

namespace HoloToolkit.Unity
{
    public class nodeOpener : MonoBehaviour
    {

        public GameObject contentHolder;
        private GameObject parentNode;
        public bool isMiniNode;
        Vector3 contentStartLoc;
        SimpleTagalong nodeTagalong;
        public bool contentOpen;
        public float distanceThreshold;
        public float moveSpeed;
        


        void Start()
        {
            // set initial location of the node content
            if (!isMiniNode)
            {
                contentStartLoc = contentHolder.transform.position;
                nodeTagalong = contentHolder.GetComponent<SimpleTagalong>();
            }
        }
        
        void Update()
        {
            if (contentOpen)
            {
                distanceChecker();
            }

        }

        

        //Open node's content
        public void openNode()
        {
            // if mini node, open the parent
            if (isMiniNode)
            {
                nodeOpener parentOpener = parentNode.GetComponent<nodeOpener>();
                if (!parentOpener.contentOpen)
                {
                    parentOpener.openNode();
                    miniMapToggle.Instance.toggleMiniMap();
                    
                }
            }
            else
            {
                //open node content
                if (!contentOpen)
                {
                    
                    contentOpen = true;
                    contentHolder.SetActive(true);
                    contentHolder.transform.position = contentStartLoc;
                    contentStartLoc = contentHolder.transform.position;

                }
            }
        }

        public void closeNode()
        {
            //close node content
            if (contentOpen)
            {
                contentHolder.SetActive(false);
                contentOpen = false;
            }
        }


        // determine whether or not to tag along
        void distanceChecker()
        {
            //get user's distance from the node
            Vector3 contentPos = contentHolder.transform.position;
            Vector3 camPos = Camera.main.transform.position;
            float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);

            if (camDistance > distanceThreshold )
            {
                //check if the node is close enough to user to enable tagalong, if not move it closer
                float contentDistance = Vector3.Distance(contentPos, camPos);

                if (contentDistance > nodeTagalong.TagalongDistance)
                {
                    if (!nodeTagalong.enabled)
                    {
                        contentHolder.transform.position = Vector3.MoveTowards(contentPos, camPos, moveSpeed);
                    }
                }
                else
                {
                    if (!nodeTagalong.enabled)
                    {
                        nodeTagalong.enabled = true;
                    }
                }

            }
            else
            {
                // turn off tagalong and move content back to the node
                if (nodeTagalong.enabled)
                {
                    nodeTagalong.enabled = false;
                    contentHolder.GetComponent<Interpolator>().enabled = false;
                }
                if (contentPos != contentStartLoc)
                {
                    contentHolder.transform.position = Vector3.MoveTowards(contentPos, contentStartLoc, moveSpeed);
                }
            }
        }


    }
}