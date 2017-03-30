using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity
{
    public class nodeHighlight : MonoBehaviour {
        
        Material mat;
        public GameObject NodeMesh;
        public Material nodeMat;
        public Material nodeHighlightMat;

        // Use this for initialization
        void Start() {
            mat = NodeMesh.transform.GetChild(0).GetComponent<Renderer>().material;


        }

        // Update is called once per frame
        void Update() {

        }

        public void highlightNode()
        {

            for (int i = 0; i < NodeMesh.transform.childCount; i++)
            {
                if (NodeMesh.transform.GetChild(i).GetComponent<Renderer>() != null)
                {
                    NodeMesh.transform.GetChild(i).GetComponent<Renderer>().material = nodeHighlightMat;
                    //NodeMesh.transform.GetChild(i).GetComponent<Renderer>().material.SetColor("_EmissionColor", highlightEmissColor);
                }
            }
            


    }

        public void unhighlightNode()
        {
            for (int i = 0; i < NodeMesh.transform.childCount; i++)
            {
                if (NodeMesh.transform.GetChild(i).GetComponent<Renderer>() != null)
                {
                    NodeMesh.transform.GetChild(i).GetComponent<Renderer>().material = nodeMat;
                    //NodeMesh.transform.GetChild(i).GetComponent<Renderer>().material.SetColor("_EmissionColor", startEmissColor);
                }

            }
            
        }
    }
}
