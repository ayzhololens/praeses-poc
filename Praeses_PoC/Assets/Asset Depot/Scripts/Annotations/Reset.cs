using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace HoloToolkit.Unity
{

    public class Reset : MonoBehaviour
    {

        public videoRecorder vidRecorder;
        public annotationManager annotManager;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void clearNodes()
        {
            foreach (GameObject a in annotManager.activeAnnotations)
            {
                DestroyImmediate(a);
            }
            annotManager.activeAnnotations.Clear();

            for (int i = 0; i < vidRecorder.vidCounter; i++)
            {
                if (File.Exists(vidRecorder.fileList[i]))
                {
                    File.Delete(vidRecorder.fileList[i]);
                }
            }

            //vidRecorder.vidCounter = 0;


        }
    }
}
