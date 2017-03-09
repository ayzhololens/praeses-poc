using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followViz : MonoBehaviour {

    public List<GameObject> meshViz;
    public GameObject opposite;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        foreach(GameObject obj in meshViz)
        {
            if(obj.GetComponent<MeshRenderer>() != null)
            {
                obj.GetComponent<MeshRenderer>().enabled = gameObject.GetComponent<MeshRenderer>().enabled;
            }
        }
        if (opposite != null)
        {
            opposite.GetComponent<MeshRenderer>().enabled = !gameObject.GetComponent<MeshRenderer>().enabled;
        }
	}
}
