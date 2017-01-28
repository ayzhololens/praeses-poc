using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonFuncs : MonoBehaviour {

    Vector3 startScale;
    float Scalefactor = 1.1f;
    public bool scaleSelect = true;
    public bool colorSelect = true;
    Color startColor;

	// Use this for initialization
	void Start () {
        startScale = transform.localScale;
        startColor = gameObject.GetComponent<MeshRenderer>().material.color;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void highlighted()
    {
        if (gameObject.tag == "Button") { 
        if (scaleSelect)
        {
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(Scalefactor, Scalefactor, Scalefactor));
        }
        if (colorSelect)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }
    }

    public void nonHighlighted()
    {
        transform.localScale = startScale;
        gameObject.GetComponent<MeshRenderer>().material.color = startColor;
    }
}
