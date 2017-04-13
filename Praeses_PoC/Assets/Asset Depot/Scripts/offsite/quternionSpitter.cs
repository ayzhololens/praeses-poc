using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quternionSpitter : MonoBehaviour {

    public GameObject subject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump"))
        {
            printQuater();
        }
		
	}

    public void printQuater()
    {
        print(subject.transform.localRotation);
    }
}
