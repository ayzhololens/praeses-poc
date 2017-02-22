using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundingHide : MonoBehaviour {

    int startingLayer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //private void OnTriggerEnter(Collider other)
    //{
    //    print(other);
    //} 

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<MeshRenderer>() && other.gameObject.tag == "miniMapMesh") { 
        other.gameObject.GetComponent<MeshRenderer>().enabled = true;
            other.gameObject.layer = 31;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<MeshRenderer>() && other.gameObject.tag == "miniMapMesh")
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            other.gameObject.layer = 2;

        }
    }
}
