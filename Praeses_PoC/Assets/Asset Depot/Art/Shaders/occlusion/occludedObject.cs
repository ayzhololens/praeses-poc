using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class occludedObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
        foreach(Renderer renderer in renderers)
        {
            renderer.material.renderQueue = 2002;
        } 
	}
	
}
