using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followViz : MonoBehaviour {

    public List<GameObject> followers;
    public GameObject opposite;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject fol in followers)
        {
            fol.GetComponent<MeshRenderer>().enabled = gameObject.GetComponent<MeshRenderer>().enabled;
        }
        if (opposite != null)
        {
            opposite.GetComponent<MeshRenderer>().enabled = !gameObject.GetComponent<MeshRenderer>().enabled;
        }
	}
}
