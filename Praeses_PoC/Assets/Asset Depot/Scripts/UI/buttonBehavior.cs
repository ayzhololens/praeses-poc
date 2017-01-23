using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonBehavior : MonoBehaviour {
    public bool subButton;
    public Transform frontHolder;
    public GameObject subButtonParent;
    public GameObject nextButtonHolder;
    public GameObject currentButtonHolder;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void keepSubButtonsOn()
    {
        subButtonParent.GetComponent<subMenu>().subButtonsOn = true;
    }

    public void goToNextButton()
    {
        currentButtonHolder.SetActive(false);
        nextButtonHolder.transform.LookAt(Camera.main.transform);
        nextButtonHolder.SetActive(true);
    }
}
