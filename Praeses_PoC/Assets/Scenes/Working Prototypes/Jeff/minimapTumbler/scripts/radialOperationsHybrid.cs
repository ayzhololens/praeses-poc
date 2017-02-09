using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity
{
    public class radialOperationsHybrid : MonoBehaviour
    {
        private float rotationFactor;
        public float rotationMultiplier;
        public GameObject tumbledObject;
        public int typing;

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
                tumbledObject.transform.Rotate(new Vector3(0, -1 * rotationFactor * rotationMultiplier, 0));
            }
            else if (typing == 2)
            {
                float scaleFactor = 1 + rotationFactor;
                tumbledObject.transform.localScale *= scaleFactor;
            }

        }

        private void OnTriggerEnter(Collider other)
        {
            
            if (other.gameObject.tag == "handCursorCollide")
            {
                if (typing == 1)
                {
                    rotationFactor = 2;

                }
                else if (typing == 2)
                {
                    rotationFactor = .01f * rotationMultiplier;
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            rotationFactor = 0;
        }


    }
}
