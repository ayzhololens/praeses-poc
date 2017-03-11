using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class constrainOrientWorld : MonoBehaviour {

    public Transform world;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = world.rotation;

    }
}
