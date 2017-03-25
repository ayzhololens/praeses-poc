using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonHightlight : MonoBehaviour {

    public Material mainMat;
    public Material highlightMat;
    public bool isPanel;
    Color panelMain;
    public Color panelHighlight;

    // Use this for initialization
    void Start () {
        //mat = GetComponent<Renderer>().material;
        if (!isPanel)
        {
            GetComponent<Renderer>().material = mainMat;
        }
        if (isPanel)
        {
            panelMain = GetComponent<Image>().color;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void highlight()
    {
        if (!isPanel)
        {
            GetComponent<Renderer>().material = highlightMat;
        }
        if (isPanel)
        {
            GetComponent<Image>().color = panelHighlight;
        }
        
    }

    public void unHighlight()
    {
        if (!isPanel)
        {
            GetComponent<Renderer>().material = mainMat;
        }
        if (isPanel)
        {
            GetComponent<Image>().color = panelMain;
        }

    }
}
