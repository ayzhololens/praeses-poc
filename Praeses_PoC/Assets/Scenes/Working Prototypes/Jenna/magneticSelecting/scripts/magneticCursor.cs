using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity
{
    public class magneticCursor : MonoBehaviour
    {

        public bool collided;
        GameObject collidedObj;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Button" && !collided)
            {
                collided = true;
                //transform.position = collision.gameObject.transform.position;
                Debug.Log("collided");
                for (int i = 0; i< transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().enabled = false;
                }
                
                collidedObj = collision.gameObject;
                collidedObj.SendMessage("magHighlightOn", SendMessageOptions.DontRequireReceiver);

            }

        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.tag == "Button" && collided)
            {
                collided = false;
                Debug.Log("not collided");
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().enabled = true;
                }
                collidedObj.SendMessage("magHighlightOff", SendMessageOptions.DontRequireReceiver);
                collidedObj = null;
            }

        }
    }
}
