using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity
{
    public class dragOperation : MonoBehaviour
    {
        private float rotationFactor;
        public float rotationMultiplier;
        public GameObject tumbledObject;
        public int typing;
        public GameObject Rarrow;
        public GameObject Larrow;
        public GameObject RSca;
        public GameObject LSca;
        private float offset;

        public GameObject cursorOri;
        public GameObject cursorHand;
        bool allowRot;
        bool allowSca;
        Vector3 initHandPos;

        public GameObject otherObject;
        Transform oriParent;

        // Use this for initialization
        void Start()
        {
            offset = 0;
            initHandPos = new Vector3(0, 0, 0);
            allowRot = false;
            allowSca = false;
            oriParent = cursorHand.transform.parent;
        }

        // Update is called once per frame
        void Update()
        {
            if (typing == 1 )
            {
                PerformRotation();
                
            }
            else if (typing == 2 )
            {
                PerformScale();
             
            }
        
        }

        private void PerformRotation()
        {
            if (GazeManager.Instance.FocusedObject == gameObject || allowRot)
            {
                if (HandsManager.Instance.HandsPressed)
                {
                    otherObject.GetComponent<Collider>().enabled = false;
                    if (!allowRot)
                    {
                        initHandPos = HandsManager.Instance.ManipulationHandPosition;
                        allowRot = true;
                    }
                    allowRot = true;
                    cursorOri.SetActive(false);
                    cursorHand.SetActive(true);
                    Vector3 handPos = HandsManager.Instance.ManipulationHandPosition - initHandPos;
                    rotationFactor = handPos.x;
                    cursorHand.transform.SetParent(gameObject.transform);
                    cursorHand.transform.localPosition = new Vector3(handPos.x * -30, 2, 0);
                }
                else
                {
                    otherObject.GetComponent<Collider>().enabled = true;
                    allowRot = false;
                    cursorOri.SetActive(true);
                    cursorHand.SetActive(false);
                    rotationFactor = 0;
                    initHandPos = new Vector3(0, 0, 0);
                    cursorHand.transform.SetParent(oriParent);
                }
                tumbledObject.transform.Rotate(new Vector3(0, -1 * rotationFactor * rotationMultiplier, 0));
                if (rotationFactor > 0)
                {
                    Rarrow.GetComponent<MeshRenderer>().material.color = Color.red;
                    Larrow.GetComponent<MeshRenderer>().material.color = Color.white;
                }
                else if (rotationFactor < 0)
                {
                    Larrow.GetComponent<MeshRenderer>().material.color = Color.red;
                    Rarrow.GetComponent<MeshRenderer>().material.color = Color.white;
                }
                else
                {
                    Rarrow.GetComponent<MeshRenderer>().material.color = Color.white;
                    Larrow.GetComponent<MeshRenderer>().material.color = Color.white;
                }
            }
        }

        private void PerformScale()
        {
            if (GazeManager.Instance.FocusedObject == gameObject || allowSca)
            {
                if (HandsManager.Instance.HandsPressed)
                {
                    otherObject.GetComponent<Collider>().enabled = false;
                    if (!allowSca)
                    {
                        initHandPos = HandsManager.Instance.ManipulationHandPosition;
                        allowSca = true;
                    }
                    allowSca = true;
                    cursorOri.SetActive(false);
                    cursorHand.SetActive(true);
                    rotationFactor = 0;
                    Vector3 handPos = HandsManager.Instance.ManipulationHandPosition - initHandPos;
                    rotationFactor = .01f * rotationMultiplier * (handPos.x);
                    cursorHand.transform.SetParent(gameObject.transform);
                    cursorHand.transform.localPosition = new Vector3(handPos.x * 30, 2, 0);
                }
                else
                {
                    otherObject.GetComponent<Collider>().enabled = true;
                    allowSca = false;
                    cursorOri.SetActive(true);
                    cursorHand.SetActive(false);
                    rotationFactor = 0;
                    cursorHand.transform.SetParent(oriParent);
                }
                float scaleFactor = 1 + rotationFactor;
                tumbledObject.transform.localScale  = new Vector3(Mathf.Clamp(tumbledObject.transform.localScale.x * scaleFactor, .2f, 2),
                                                        Mathf.Clamp(tumbledObject.transform.localScale.y * scaleFactor, .2f, 2),
                                                        Mathf.Clamp(tumbledObject.transform.localScale.z * scaleFactor, .2f, 2));
                if (rotationFactor > 0)
                {
                    RSca.GetComponent<MeshRenderer>().material.color = Color.red;
                    LSca.GetComponent<MeshRenderer>().material.color = Color.white;
                }
                else if (rotationFactor < 0)
                {
                    LSca.GetComponent<MeshRenderer>().material.color = Color.red;
                    RSca.GetComponent<MeshRenderer>().material.color = Color.white;
                }
                else
                {
                    RSca.GetComponent<MeshRenderer>().material.color = Color.white;
                    LSca.GetComponent<MeshRenderer>().material.color = Color.white;
                }
            }
        }
    }
}
