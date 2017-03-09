using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using HoloToolkit.Unity;

public class deleteNode : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DeleteNode()
    {
        foreach (GameObject node in annotationManager.Instance.activeAnnotations)
        {
            if(node == this.gameObject)
            {
                if (GetComponent<openAnnotationNode>().miniNode != null)
                {
                    DestroyImmediate(GetComponent<openAnnotationNode>().miniNode);
                }
                
                if (GetComponent<annotationMediaHolder>().filepath != null)
                {
                    if (File.Exists(GetComponent<annotationMediaHolder>().filepath))
                    {
                        File.Delete(GetComponent<annotationMediaHolder>().filepath);
                    }
                }
                DestroyImmediate(this.gameObject);
                Debug.Log("found it");
            }
        }
    }
}
