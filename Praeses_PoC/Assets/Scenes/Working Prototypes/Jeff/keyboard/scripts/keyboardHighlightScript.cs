using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity
{
    public class keyboardHighlightScript : MonoBehaviour
    {

        Transform oriParent;

        // Use this for initialization
        void Start()
        {
            oriParent = transform.parent;
            gameObject.GetComponent<MeshRenderer>().enabled = false;

        }

        // Update is called once per frame
        void Update()
        {
            highlighter();
        }

        public void highlighter()
        {
            if (GazeManager.Instance.FocusedObject) { 
                if (GazeManager.Instance.FocusedObject.tag == "keyboard")
                {
                    transform.SetParent(GazeManager.Instance.FocusedObject.transform);
                    transform.localPosition = new Vector3(0, -.05f, 0);
                    transform.localRotation = new Quaternion(0, 0, 0, 0);
                    transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
                    transform.SetParent(oriParent);
                    gameObject.GetComponent<MeshRenderer>().enabled = true;
                }else
                {
                    gameObject.GetComponent<MeshRenderer>().enabled = false;

                }
            }else
            {
                gameObject.GetComponent<MeshRenderer>().enabled = false;

            }
        }
    }
}
