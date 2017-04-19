using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

namespace HoloToolkit.Unity
{
    public class keyboardHighlightScript : MonoBehaviour
    {

        Transform oriParent;
        float variantX;
        public bool test;

        // Use this for initialization
        void Start()
        {
            oriParent = transform.parent;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            variantX = 1.1f;
        }

        // Update is called once per frame
        void Update()
        {
            highlighter();
        }

        public void highlighter()
        {
            if (GazeManager.Instance.HitObject) { 
                if (GazeManager.Instance.HitObject.tag == "keyboard")
                {
                    transform.SetParent(GazeManager.Instance.HitObject.transform);
                    transform.localPosition = new Vector3(0, -.05f, 0);
                    transform.localRotation = new Quaternion(0, 0, 0, 0);
                    if(GazeManager.Instance.HitObject.transform.localScale.x > GazeManager.Instance.HitObject.transform.localScale.y * 2)
                    {
                        variantX = 1.065f;
                    }
                    else if(GazeManager.Instance.HitObject.transform.localScale.x == 0.19)
                    {
                        variantX = 1.09f;
                    }
                    else {
                        variantX = 1.1f;
                    }
                    transform.localScale = new Vector3(variantX, 1.1f, 1.1f);
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
