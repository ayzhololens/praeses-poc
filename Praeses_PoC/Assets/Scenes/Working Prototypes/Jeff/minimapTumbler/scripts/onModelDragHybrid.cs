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

        public GameObject handPosLocal;

        public followCursorScript followCur;

        public radialOperationsHybrid col1;
        public radialOperationsHybrid col2;
        public radialOperationsHybrid col3;
        public radialOperationsHybrid col4;

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
        
                    handPosLocal.transform.position = new Vector3(Mathf.Clamp(handPos.x, -.1f, .1f),
                                                                    Mathf.Clamp(handPos.y, -.1f, .1f),
                                                                    handPos.z);

                    xPos = handPosLocal.transform.localPosition.x;
                    yPos = handPosLocal.transform.localPosition.y;

                    cursorHand.transform.localPosition = new Vector3(xPos, yPos, tempDist / 100 - .025f);

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
                col1.rotationFactor = 0;
                col2.rotationFactor = 0;
                col3.rotationFactor = 0;
                col4.rotationFactor = 0;
                followCur.iconIndex = 0;
                buttonsGrp.SetActive(false);
            }

        }

    }
}

