using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour {

    public GameObject[] options;
    public int optionCounter;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void switchOptions()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].SetActive(false);
        }
        optionCounter += 1;
        if(optionCounter > options.Length-1)
        {
            optionCounter = 0;
        }
        options[optionCounter].SetActive(true);
    }
}
