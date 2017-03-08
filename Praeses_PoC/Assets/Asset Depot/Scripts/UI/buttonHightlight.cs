using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonHightlight : MonoBehaviour {

    public Material mainMat;
    public Material highlightMat;

    // Use this for initialization
    void Start () {
        //mat = GetComponent<Renderer>().material;
        GetComponent<Renderer>().material = mainMat;
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
        GetComponent<Renderer>().material = mainMat;
    }
}
