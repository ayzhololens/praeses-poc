using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magneticListener : MonoBehaviour {


    public GameObject magHighlight;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void magHighlightOn()
    {
        magHighlight.SetActive(true);
    }

    public void magHighlightOff()
    {
        magHighlight.SetActive(false);
    }
}
