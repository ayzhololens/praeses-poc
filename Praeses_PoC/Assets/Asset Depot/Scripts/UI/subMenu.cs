using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subMenu : MonoBehaviour {

    public GameObject[] subButtons;
    public bool subButtonsOn;
    public float timeOutCounter;

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

            gameObject.GetComponent<popForward>().moveBackward();
            gameObject.GetComponent<buttonHightlight>().unHighlight();

        }
        

    }
}
