using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonNavigator : MonoBehaviour {
    public GameObject nextButtonHolder;
    public GameObject currentButtonHolder;
    public GameObject currentButton;
    // Use this for initialization
    void Start () {
        currentButton = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void goToNextButton()
    {
        currentButtonHolder.SetActive(false);
        nextButtonHolder.SetActive(true);
    }
}
