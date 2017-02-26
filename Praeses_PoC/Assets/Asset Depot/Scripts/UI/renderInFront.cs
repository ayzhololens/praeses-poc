using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class renderInFront : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<MeshRenderer>().material.renderQueue = 4000;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
