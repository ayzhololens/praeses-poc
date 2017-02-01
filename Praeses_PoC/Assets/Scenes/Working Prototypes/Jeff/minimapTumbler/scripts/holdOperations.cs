using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity
{
    public class holdOperations : MonoBehaviour
    {
        private float rotationFactor;
        public float rotationMultiplier;
        public GameObject tumbledObject;
        public int typing;
        bool allowRot;
        bool allowSca;

        public GameObject other1;
        public GameObject other2;
       public  GameObject other3;

        //1 = rotation
        //2 = scaler

        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (typing == 1) { 
            PerformRotation();
                }else if (typing == 2)
            {
                PerformScale();
            }

        }

        private void PerformRotation()
        {
            if (GazeManager.Instance.FocusedObject == gameObject || allowRot)
            {
                if (GestureManager.Instance.sourcePressed)
                {
                    if (!allowRot)
                    {
                        allowRot = true;
                    }
                    rotationFactor = 2;
                    other1.GetComponent<Collider>().enabled = false;
                    other2.GetComponent<Collider>().enabled = false;
                    other3.GetComponent<Collider>().enabled = false;

                }
                else
                {
                    allowRot = false;
                    rotationFactor = 0;
                    other1.GetComponent<Collider>().enabled = true;
                    other2.GetComponent<Collider>().enabled = true;
                    other3.GetComponent<Collider>().enabled = true;

                }
                tumbledObject.transform.Rotate(new Vector3(0, -1 * rotationFactor * rotationMultiplier, 0));
            }
        }

        private void PerformScale()
        {
            if (GazeManager.Instance.FocusedObject == gameObject || allowSca)
            {
                if (GestureManager.Instance.sourcePressed)
                {
                    if (!allowSca)
                    {
                        allowSca = true;
                    }
                    rotationFactor = .01f * rotationMultiplier;

                }
                else
                {
                    allowSca = false;
                    rotationFactor = 0;

                }
                float scaleFactor = 1 + rotationFactor;
                tumbledObject.transform.localScale *= scaleFactor;
            }
        }


    }
}
