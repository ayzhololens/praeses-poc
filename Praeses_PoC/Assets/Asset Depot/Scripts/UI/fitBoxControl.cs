using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fitBoxControl : MonoBehaviour {
    public GameObject fitBox;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void toggleFitbox()
    {
        fitBox.SetActive(!fitBox.activeSelf);
    }
}
