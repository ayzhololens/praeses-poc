using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity
{
    public class onModelDragHybrid : MonoBehaviour
    {
        private float rotationFactor;
        private float scaleFactor;
        public float rotationMultiplier;
        public float scaleMultiplier;
        public GameObject rotatedObject;
        public GameObject scaledObject;

        public GameObject cursorOri;
        public GameObject cursorHand;
        bool allowRot;
        bool allowSca;
        bool allowManip;
        Vector3 initHandPos;

        public GameObject buttonsGrp;

        Transform oriParent;
        bool editState;
        float xPos;
        float yPos;

        float tempDist;
        int reverser;

        // Use this for initialization
        void Start()
        {
            initHandPos = new Vector3(0, 0, 0);
            allowRot = false;
            allowSca = false;

            allowManip = false;
            oriParent = buttonsGrp.transform.parent;
            editState = false;
            adjustWithEdit();

            tempDist = 0.0f;
        }

        // Update is called once per frame
        void Update()
        {
            if (Camera.main.transform.rotation.y > .5 || Camera.main.transform.rotation.y < -.5)
            {
                reverser =-1;
            }
            else
            {
                reverser = 1;
            }

            menuOn();      
        }

        private void menuOn()
        {
            if (GazeManager.Instance.FocusedObject == gameObject || allowManip)
            {
                if (HandsManager.Instance.HandsPressed)
                {
                    float limit = .02f;

                    if (!allowManip)
                    {
                        tempDist = Vector3.Distance(Camera.main.transform.position, GazeManager.Instance.Position);

                        initHandPos = HandsManager.Instance.ManipulationHandPosition;
                        editState = true;
                        adjustWithEdit();
                        allowManip = true;
                    }
                    allowManip = true;
                    cursorOri.SetActive(false);
                    cursorHand.SetActive(true);

                    Vector3 handPos = HandsManager.Instance.ManipulationHandPosition - initHandPos;
                    
                        rotationFactor = 0;
                        scaleFactor = 0;
                        
                        xPos = handPos.x * 2 * reverser;
                        yPos = handPos.y * 2;

                    cursorHand.transform.localPosition = new Vector3(xPos, yPos, tempDist /100 - .05f);
                    //rotatedObject.transform.Rotate(new Vector3(0, -1 * rotationFactor * rotationMultiplier, 0));
                    float scaleFactor1 = 1 + scaleFactor;
                    float scaleMin = .5f;
                    float scaleMax = 2;
                    //scaledObject.transform.localScale = new Vector3(Mathf.Clamp(scaledObject.transform.localScale.x * scaleFactor1, scaleMin, scaleMax),
                    //                                        Mathf.Clamp(scaledObject.transform.localScale.y * scaleFactor1, scaleMin, scaleMax),
                    //                                        Mathf.Clamp(scaledObject.transform.localScale.z * scaleFactor1, scaleMin, scaleMax));

                }
                else
                {
                    editState = false;
                    allowManip = false;
                    adjustWithEdit();
                    cursorOri.SetActive(true);
                    cursorHand.SetActive(false);
                    initHandPos = new Vector3(0, 0, 0);
                    rotationFactor = 0;
                    scaleFactor = 0;
                }
            }
        }

        private void adjustWithEdit()
        {
            if (editState)
            {
                Vector3 up = oriParent.up;
                Vector3 forward = Vector3.ProjectOnPlane(Camera.main.transform.forward, up).normalized;

                buttonsGrp.SetActive(true);
                buttonsGrp.transform.SetParent(Camera.main.transform);
                buttonsGrp.transform.localPosition = new Vector3(0, 0, tempDist);
                buttonsGrp.transform.rotation = Quaternion.LookRotation(forward, up);
                buttonsGrp.transform.SetParent(oriParent);
            }
            else
            {
                buttonsGrp.SetActive(false);
            }

        }
       
    }
    }
