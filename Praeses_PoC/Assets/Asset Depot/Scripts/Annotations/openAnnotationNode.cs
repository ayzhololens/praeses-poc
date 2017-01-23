using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity
{
    public class openAnnotationNode : MonoBehaviour {

        public GameObject contentHoler;
        public bool contentOpen;
        public annotationManager annotManager;
        public bool miniNode;


        // Use this for initialization
        void Start() {

            annotManager = GameObject.Find("AnnotationManager").GetComponent<annotationManager>();
            if (miniNode)
            {
                closeContent();
            }
                        

        }

        // Update is called once per frame
        void Update() {


        }

        public void openContent()
        {

            foreach (GameObject annots in annotManager.activeAnnotations)
            {
                if (annots.GetComponent<openAnnotationNode>() != null)
                {
                    annots.GetComponent<openAnnotationNode>().closeContent();
                }

            }

            //for(int i=0; i<annotManager.gameObject.transform.childCount; i++)
            //{
            //    if (annotManager.gameObject.transform.GetChild(i).GetComponent<openAnnotationNode>() != null)
            //    {
            //        annotManager.gameObject.transform.GetChild(i).GetComponent<openAnnotationNode>().closeContent();
            //    }
            //}
            contentHoler.SetActive(true);

            if (GetComponent<annotationMediaHolder>().videoNode)
            {
                GetComponent<annotationMediaHolder>().LoadVideo();
            }

            if (GetComponent<annotationMediaHolder>().photoNode)
            {
                GetComponent<annotationMediaHolder>().LoadPhoto();
            }
            


        }

        public void closeContent()
        {
            contentHoler.SetActive(false);
        }
    }
}
