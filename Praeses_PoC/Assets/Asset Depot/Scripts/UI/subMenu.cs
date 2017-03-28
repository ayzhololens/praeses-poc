using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subMenu : MonoBehaviour {

    public GameObject[] subButtons;
    public bool subButtonsOn;
    public float timeOutCounter;
    public GameObject[] hide;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void turnOnSubButtons()
    {
        for(int i=0; i<subButtons.Length; i++)
        {
            subButtons[i].SetActive(true);
        }
        subButtonsOn = true;
        if (hide.Length > 0)
        {
            for(int i =0; i<hide.Length; i++) { hide[i].SetActive(false); }
        }
    }

    public void turnOffCounter()
    {
        Invoke("turnOffSubButtons", timeOutCounter);
        subButtonsOn = false;
    }

    public void turnOffSubButtons()
    {

        if (!subButtonsOn)
        {
            for (int i = 0; i < subButtons.Length; i++)
            {
                subButtons[i].SetActive(false);
            }
            if (gameObject.GetComponent<popForward>() != null)
            {
                gameObject.GetComponent<popForward>().moveBackward();
            }
            if (gameObject.GetComponent<buttonHightlight>() != null)
            {
                gameObject.GetComponent<buttonHightlight>().unHighlight();
            }


            if (hide.Length > 0)
            {
                for (int i = 0; i < hide.Length; i++) { hide[i].SetActive(true); }
            }

            //BroadcastMessage("OnFocusExit", SendMessageOptions.DontRequireReceiver);
        }
        //if (subButtonsOn)
        //    Debug.Log(" turn off");
        //{
        //    for (int i = 0; i < subButtons.Length; i++)
        //    {
        //        subButtons[i].SetActive(false);
        //    }
        //    if (gameObject.GetComponent<buttonHightlight>() != null)
        //    {
        //        gameObject.GetComponent<buttonHightlight>().unHighlight();
        //    }


        //    //BroadcastMessage("OnFocusExit", SendMessageOptions.DontRequireReceiver);
        //}


    }
}
