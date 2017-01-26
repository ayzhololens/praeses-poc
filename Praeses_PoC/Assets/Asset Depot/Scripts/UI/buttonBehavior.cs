using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonBehavior : MonoBehaviour {
    public bool subButton;
    public Transform frontHolder;
    public GameObject subButtonParent;
    public GameObject nextButtonHolder;
    public GameObject currentButtonHolder;
    public GameObject backHolder;
    public GameObject frontPosHolder;
    public GameObject downHolder;
    public float speed;
    public bool moving;


    // Use this for initialization
    void Start () {
        moving = false;
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(moving);
        if (moving)
        {
            Debug.Log("hello");

            //nextButtonHolder.transform.position = Vector3.MoveTowards(nextButtonHolder.transform.position, frontPosHolder.transform.position, speed * Time.deltaTime);
            //currentButtonHolder.transform.position = Vector3.MoveTowards(currentButtonHolder.transform.position, downHolder.transform.position, speed * Time.deltaTime);
            //if (currentButtonHolder.transform.position == downHolder.transform.position)
            //{
            //    moving = false;
            //}
        }
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

    public void acceptInput()
    {
        //nextButtonHolder.SetActive(true);
        moving = true;
        Debug.Log("tried again" + moving);
        //nextButtonHolder.transform.position = backHolder.transform.position;
        //nextButtonHolder.transform.position = Vector3.MoveTowards(nextButtonHolder.transform.position, frontPosHolder.transform.position, speed * Time.deltaTime);
        //currentButtonHolder.transform.position = Vector3.MoveTowards(currentButtonHolder.transform.position, downHolder.transform.position, speed * Time.deltaTime);
        //currentButtonHolder.SetActive(false);
    }

    public void denyInput()
    {

    }
}
