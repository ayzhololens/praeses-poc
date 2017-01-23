using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniMapToggle : MonoBehaviour {

    public GameObject MiniMapTagAlong;
    public GameObject MiniMapHolder;
    public bool active;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void toggleMiniMap()
    {
        for(int i=0; i< MiniMapHolder.transform.childCount; i++)
        {
            MiniMapHolder.transform.GetChild(i).gameObject.SetActive(!MiniMapHolder.transform.GetChild(i).gameObject.activeSelf);
        }
        active = MiniMapHolder.transform.GetChild(0).gameObject.activeSelf;

        

    }
}
