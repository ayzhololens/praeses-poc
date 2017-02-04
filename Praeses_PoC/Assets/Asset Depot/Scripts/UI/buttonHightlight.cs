using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonHightlight : MonoBehaviour {

    Material mat;
    public Material highlightMat;

    // Use this for initialization
    void Start () {
        mat = GetComponent<Renderer>().material;
		
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
