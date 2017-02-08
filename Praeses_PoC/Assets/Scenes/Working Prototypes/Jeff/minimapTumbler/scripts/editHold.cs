using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity
{
    public class editHold : MonoBehaviour
    {
        bool editState;
        public GameObject buttonsGrp;
        Transform oriParent;

        public float tempDist;

        // Use this for initialization
        void Start()
        {
            editState = false;
            oriParent = buttonsGrp.transform.parent;
            adjustWithEdit();
        }

        // Update is called once per frame
        void Update()
        {
            performEdit();

        }

        private void performEdit()
        {
            if (GazeManager.Instance.FocusedObject == gameObject)
            {
                if (GestureManager.Instance.sourcePressed)
                {

                    //gameObject.GetComponent<MeshRenderer>().enabled = false;
                    gameObject.GetComponent<Collider>().enabled = false;
                    if (!editState) {
                        tempDist = Vector3.Distance(Camera.main.transform.position, GazeManager.Instance.Position);
                    editState = true;
                    }
                    adjustWithEdit();
                }

            }
            if (!GestureManager.Instance.sourcePressed)
            {
               // gameObject.GetComponent<MeshRenderer>().enabled = true;
                gameObject.GetComponent<Collider>().enabled = true;
                editState = false;
                adjustWithEdit();
            }
        }

        private void adjustWithEdit()
        {
            if (editState)
            {

                buttonsGrp.SetActive(true);
                buttonsGrp.transform.SetParent(Camera.main.transform);

                //buttonsGrp.transform.localPosition = new Vector3(0, 0, .9f);   
                buttonsGrp.transform.localPosition = new Vector3(0, 0, tempDist);
                buttonsGrp.transform.localRotation = new Quaternion(0, 0, 0,0);
                buttonsGrp.transform.SetParent(oriParent);
            }
                else
                {
                buttonsGrp.SetActive(false);
            }

        }
    }
}
