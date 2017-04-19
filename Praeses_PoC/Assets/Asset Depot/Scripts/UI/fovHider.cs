using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;

public class fovHider : Singleton<fovHider> {
    public GameObject Hider;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void toggleFOVHider(bool on)
    {
        Hider.SetActive(on);
    }
}
