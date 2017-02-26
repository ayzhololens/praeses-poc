using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity
{
    public class radialOperationsHybrid : MonoBehaviour
    {
        public float rotationFactor;
        public float rotationMultiplier;
        public GameObject tumbledObject;
        public int typing;

        public followCursorScript followCur;
        public int cursorIndex;

        //1 = rotation
        //2 = scaler

        // Use this for initialization
        void Start()
        {
        }


        // Update is called once per frame
        void FixedUpdate()
        {
            if (sourceManager.Instance.sourcePressed)
            {
                if (typing == 1)
                {
                    tumbledObject.transform.Rotate(new Vector3(0, -1 * rotationFactor* rotationMultiplier, 0));
                }
                else if (typing == 2)
                {
                    float scaleFactor1 = 1 + rotationFactor;
                    float scaleMin = .5f;
                    float scaleMax = 2;
                    tumbledObject.transform.localScale = new Vector3(Mathf.Clamp(tumbledObject.transform.localScale.x * scaleFactor1, scaleMin, scaleMax),
                                                            Mathf.Clamp(tumbledObject.transform.localScale.y * scaleFactor1, scaleMin, scaleMax),
                                                            Mathf.Clamp(tumbledObject.transform.localScale.z * scaleFactor1, scaleMin, scaleMax));
                }
            }
        }


        private void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.tag != "handCursorCollide"){ return; };
                //Debug.Log("collide enter tag");
                followCur.iconIndex = cursorIndex;
                if (typing == 1)
                {
                    //Debug.Log(other.gameObject + "collide enter tag rotate");
                    rotationFactor = 2;
                }
                else if (typing == 2)
                {
                    //Debug.Log("collide enter tag scale");
                    rotationFactor = .01f * rotationMultiplier;
                }
      
        }

        private void OnTriggerExit(Collider other)
        {
            
            followCur.iconIndex = 0;
            rotationFactor = 0;

        }


    }
}
