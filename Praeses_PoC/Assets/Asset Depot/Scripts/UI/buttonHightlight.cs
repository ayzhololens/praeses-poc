using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonHightlight : MonoBehaviour {

    public Material mat;
    public Material highlightMat;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void highlight()
    {
        GetComponent<Renderer>().material = highlightMat;
    }

    public void unHighlight()
    {
        GetComponent<Renderer>().material = mat;
    }
}
