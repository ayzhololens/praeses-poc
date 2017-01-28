using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity
{
    public class twoDReactor : MonoBehaviour
    {
        public bool isCollider;
        public bool isTrigger;

        public GameObject colliderObject;
        public GameObject triggerObject;

        public float scaleMult;
        public bool timerOn;

        Vector3 objectScaleDefault;

        // Use this for initialization
        void Start()
        {
            objectScaleDefault = transform.localScale;
            scaleMult = 1;
        }

        // Update is called once per frame
        void Update()
        {
            if (isTrigger) {
                if (timerOn)
                {
                    scaleMult -= Time.deltaTime * .2f;
                    if (scaleMult < .2f)
                    {
                        timerOn = false;
                    }
                }
                transform.localScale = objectScaleDefault * scaleMult;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Button")
            {
                if (isTrigger)
                {
                    print(other.gameObject.name + " trigger is hit");
                    colliderObject.SetActive(true);
                    timerOn = true;
                };
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag == "Button")
            {
                if (isTrigger)
                {
                    print("exiting trigger " + other.gameObject.name);
                    colliderObject.transform.localPosition = new Vector3(0, 0, 0);
                    timerOn = false;
                    scaleMult = 1;
                    GazeManagerMagnetic.Instance.gazeOffset = new Vector3(0, 0, 0);
                };
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (isCollider) {
                ContactPoint2D contact = collision.contacts[0];
                print(contact.point);
                GazeManagerMagnetic.Instance.gazeOffset = new Vector3(contact.point[0]*.5f, contact.point[1]*.2f, 0);
                //GazeManagerMagnetic.Instance.gazeOffset = -transform.localPosition;
                gameObject.SetActive(false);
                transform.localPosition = new Vector3(0, 0, 0);
            }
        }

    }
}