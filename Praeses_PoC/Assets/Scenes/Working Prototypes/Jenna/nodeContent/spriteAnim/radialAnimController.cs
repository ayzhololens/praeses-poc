using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radialAnimController : MonoBehaviour {
     
   

	// Use this for initialization
	void Start () {
        //GetComponent<Animation>().Play();
        GetComponent<Animator>().SetTrigger("radialStart");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
