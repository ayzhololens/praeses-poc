using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace HoloToolkit.Unity
{

    public class Reset : MonoBehaviour
    {

        public List<GameObject> clearedNodes;
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
            foreach(GameObject node in mediaManager.Instance.activeNodes)
            {
                if (!node.GetComponent<nodeController>().fromJSON)
                {

                    if (node.GetComponent<nodeMediaHolder>().activeFilepath.Length>1)
                    {
                        Debug.Log(node.name + " " + node.GetComponent<nodeMediaHolder>().activeFilepath);
                        //File.Delete(node.GetComponent<nodeMediaHolder>().activeFilepath);
                        //if (File.Exists(node.GetComponent<nodeMediaHolder>().activeFilepath))
                        //{
                        //    Debug.Log(node.name + " " + node.GetComponent<nodeMediaHolder>().activeFilepath);

                        //}
                    }

                    if (node.GetComponent<commentManager>() != null)
                    {
                        foreach (GameObject comment in node.GetComponent<commentManager>().activeComments)
                        {
                            if (comment.GetComponent<commentContents>().filepath != null && File.Exists(comment.GetComponent<commentContents>().filepath))
                            {
                                //Debug.Log(comment.GetComponent<commentContents>().filepath);
                                //File.Delete(comment.GetComponent<commentContents>().filepath);
                            }

                        }
                    }
                    else if (node.GetComponent<nodeController>().linkedField.GetComponent<commentManager>() != null)
                    {
                        foreach (GameObject comment in node.GetComponent<nodeController>().linkedField.GetComponent<commentManager>().activeComments)
                        {
                            if (comment.GetComponent<commentContents>().filepath != null && File.Exists(comment.GetComponent<commentContents>().filepath))
                            {
                                //Debug.Log(comment.GetComponent<commentContents>().filepath);
                                //File.Delete(comment.GetComponent<commentContents>().filepath);
                            }

                        }
                    }


                    clearedNodes.Add(node);
                    //mediaManager.Instance.activeNodes.Remove(node);
                    //DestroyImmediate(node);
                    //clearNodes();
                }
            }

            wipeList();
            //vidRecorder.vidCounter = 0;


        }

        void wipeList()
        {
            foreach(GameObject node in clearedNodes)
            {
                mediaManager.Instance.activeNodes.Remove(node);
                //DestroyImmediate(node);
            }

            clearedNodes.Clear();
        }
    }
}
