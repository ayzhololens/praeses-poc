using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundingHide : MonoBehaviour {

    int startingLayer;

    //private void OnTriggerEnter(Collider other)
    //{
    //    print(other);
    //} 

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<MeshRenderer>() && other.gameObject.tag == "miniMapMesh") {
            if (other.gameObject.GetComponent<MeshRenderer>().enabled == true) { return; }; 
        other.gameObject.GetComponent<MeshRenderer>().enabled = true;
            other.gameObject.layer = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log(other.gameObject);
        if (other.gameObject.GetComponent<MeshRenderer>() && other.gameObject.tag == "miniMapMesh")
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            other.gameObject.layer = 2;

        }
    }
}
