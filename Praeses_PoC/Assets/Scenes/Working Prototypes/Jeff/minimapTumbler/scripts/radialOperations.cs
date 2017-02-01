using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity
{
    public class radialOperations : MonoBehaviour
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
            PerformRotation();
                }else if (typing == 2)
            {
                PerformScale();
            }

        }

        private void PerformRotation()
        {
            if (GazeManager.Instance.FocusedObject == gameObject )
            {
                if (GestureManager.Instance.sourcePressed)
                {

                    rotationFactor = 2;

                }
                else
                {
                    rotationFactor = 0;

                }
                tumbledObject.transform.Rotate(new Vector3(0, -1 * rotationFactor * rotationMultiplier, 0));
            }
        }

        private void PerformScale()
        {
            if (GazeManager.Instance.FocusedObject == gameObject )
            {
                if (GestureManager.Instance.sourcePressed)
                {

                    rotationFactor = .01f * rotationMultiplier;

                }
                else
                {
                    rotationFactor = 0;

                }
                float scaleFactor = 1 + rotationFactor;
                tumbledObject.transform.localScale *= scaleFactor;
            }
        }


    }
}
