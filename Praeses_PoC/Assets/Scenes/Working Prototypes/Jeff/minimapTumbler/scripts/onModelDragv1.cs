using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity
{
    public class onModelDragv1 : MonoBehaviour
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

        public GameObject crosshair;
        public GameObject hori;
        public GameObject vert;
        public GameObject neutral;

        Transform oriParent;
        bool editState;
        bool lockCursorX;
        bool lockCursorY;
        float xPos;
        float yPos;

        // Use this for initialization
        void Start()
        {
            initHandPos = new Vector3(0, 0, 0);
            allowRot = false;
            allowSca = false;

            allowManip = false;
            oriParent = crosshair.transform.parent;
            editState = false;
            adjustWithEdit();
            hori.SetActive(false);
            vert.SetActive(false);
            neutral.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
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
                        initHandPos = HandsManager.Instance.ManipulationHandPosition;
                        editState = true;
                        adjustWithEdit();
                        allowManip = true;
                    }
                    allowManip = true;
                    cursorOri.SetActive(false);
                    cursorHand.SetActive(true);
       
                    Vector3 handPos = HandsManager.Instance.ManipulationHandPosition - initHandPos;
                    
                    if (handPos.x > limit || handPos.x < -limit)
                    {
                        if (!lockCursorX) { 
                        lockCursorY = true;
                        xPos = handPos.x * -30;
                        yPos = crosshair.transform.position.y;
                        rotationFactor = handPos.x;
                            hori.SetActive(true);
                            vert.SetActive(false);
                            neutral.SetActive(false);
                        }
                }
                else if (handPos.y > limit || handPos.y < -limit)
                {
                    if (!lockCursorY) { 
                    lockCursorX = true;
                    xPos = crosshair.transform.position.x;
                    yPos = handPos.y * -30;
                    scaleFactor = .01f * scaleMultiplier * (handPos.y);
                            hori.SetActive(false);
                            vert.SetActive(true);
                            neutral.SetActive(false);
                        }
                    }
                    else
                    {
                        lockCursorX = false;
                        lockCursorY = false;
                        rotationFactor = 0;
                        scaleFactor = 0;
                        if (!lockCursorX && !lockCursorY) { 
                        xPos = handPos.x * -30;
                        yPos = handPos.y * -30;
                         }
                        hori.SetActive(false);
                        vert.SetActive(false);
                        neutral.SetActive(true);
                    }
                    cursorHand.transform.localPosition = new Vector3(xPos, yPos, crosshair.transform.position.z - .05f);
                    rotatedObject.transform.Rotate(new Vector3(0, -1 * rotationFactor * rotationMultiplier, 0));
                    float scaleFactor1 = 1 + scaleFactor;
                    float scaleMin = .5f;
                    float scaleMax = 2;
                    scaledObject.transform.localScale = new Vector3(Mathf.Clamp(scaledObject.transform.localScale.x * scaleFactor1, scaleMin, scaleMax),
                                                            Mathf.Clamp(scaledObject.transform.localScale.y * scaleFactor1, scaleMin, scaleMax),
                                                            Mathf.Clamp(scaledObject.transform.localScale.z * scaleFactor1, scaleMin, scaleMax));

                }
                else
                {
                    editState = false;
                    allowManip = false;
                    adjustWithEdit();
                    cursorOri.SetActive(true);
                    cursorHand.SetActive(false);
                    initHandPos = new Vector3(0, 0, 0);
                    lockCursorX = false;
                    lockCursorY = false;
                    rotationFactor = 0;
                    scaleFactor = 0;
                }
            }
        }

        private void adjustWithEdit()
        {
            if (editState)
            {
                crosshair.SetActive(true);
                crosshair.transform.SetParent(Camera.main.transform);
                crosshair.transform.localPosition = new Vector3(0, 0, .9f);
                crosshair.transform.localRotation = new Quaternion(180, 0, 0, 0);
                crosshair.transform.SetParent(oriParent);
            }
            else
            {
                crosshair.SetActive(false);
            }

        }
        // private void PerformRotation()
        //{
        //    if (GazeManager.Instance.FocusedObject == gameObject || allowRot)
        //    {
        //        if (HandsManager.Instance.HandsPressed)
        //        {
        //            otherObject.GetComponent<Collider>().enabled = false;
        //            if (!allowRot)
        //            {
        //                initHandPos = HandsManager.Instance.ManipulationHandPosition;
        //                allowRot = true;
        //            }
        //            allowRot = true;
        //            cursorOri.SetActive(false);
        //            cursorHand.SetActive(true);
        //            Vector3 handPos = HandsManager.Instance.ManipulationHandPosition - initHandPos;
        //            rotationFactor = handPos.x;
        //            cursorHand.transform.position = new Vector3(handPos.x, transform.position.y, transform.position.z - .05f);
        //        }
        //        else
        //        {
        //            otherObject.GetComponent<Collider>().enabled = true;
        //            allowRot = false;
        //            cursorOri.SetActive(true);
        //            cursorHand.SetActive(false);
        //            rotationFactor = 0;
        //            initHandPos = new Vector3(0, 0, 0);
        //        }
        //        tumbledObject.transform.Rotate(new Vector3(0, -1 * rotationFactor * rotationMultiplier, 0));
        //        if (rotationFactor > 0)
        //        {
        //            Rarrow.GetComponent<MeshRenderer>().material.color = Color.red;
        //            Larrow.GetComponent<MeshRenderer>().material.color = Color.white;
        //        }
        //        else if (rotationFactor < 0)
        //        {
        //            Larrow.GetComponent<MeshRenderer>().material.color = Color.red;
        //            Rarrow.GetComponent<MeshRenderer>().material.color = Color.white;
        //        }
        //        else
        //        {
        //            Rarrow.GetComponent<MeshRenderer>().material.color = Color.white;
        //            Larrow.GetComponent<MeshRenderer>().material.color = Color.white;
        //        }
        //    }
        //}

        //private void PerformScale()
        //{
        //    if (GazeManager.Instance.FocusedObject == gameObject || allowSca)
        //    {
        //        if (HandsManager.Instance.HandsPressed)
        //        {
        //            otherObject.GetComponent<Collider>().enabled = false;
        //            if (!allowSca)
        //            {
        //                initHandPos = HandsManager.Instance.ManipulationHandPosition;
        //                allowSca = true;
        //            }
        //            allowSca = true;
        //            cursorOri.SetActive(false);
        //            cursorHand.SetActive(true);
        //            rotationFactor = 0;
        //            Vector3 handPos = HandsManager.Instance.ManipulationHandPosition - initHandPos;
        //            rotationFactor = .01f * rotationMultiplier * (handPos.x);
        //            cursorHand.transform.position = new Vector3(handPos.x, transform.position.y, transform.position.z - .05f);
        //        }
        //        else
        //        {
        //            otherObject.GetComponent<Collider>().enabled = true;
        //            allowSca = false;
        //            cursorOri.SetActive(true);
        //            cursorHand.SetActive(false);
        //            rotationFactor = 0;

        //        }
        //        float scaleFactor = 1 + rotationFactor;
        //        tumbledObject.transform.localScale = new Vector3(Mathf.Clamp(tumbledObject.transform.localScale.x * scaleFactor, .2f, 2),
        //                                                Mathf.Clamp(tumbledObject.transform.localScale.y * scaleFactor, .2f, 2),
        //                                                Mathf.Clamp(tumbledObject.transform.localScale.z * scaleFactor, .2f, 2));
        //        if (rotationFactor > 0)
        //        {
        //            RSca.GetComponent<MeshRenderer>().material.color = Color.red;
        //            LSca.GetComponent<MeshRenderer>().material.color = Color.white;
        //        }
        //        else if (rotationFactor < 0)
        //        {
        //            LSca.GetComponent<MeshRenderer>().material.color = Color.red;
        //            RSca.GetComponent<MeshRenderer>().material.color = Color.white;
        //        }
        //        else
        //        {
        //            RSca.GetComponent<MeshRenderer>().material.color = Color.white;
        //            LSca.GetComponent<MeshRenderer>().material.color = Color.white;
        //        }
        //    }
    }
    }
