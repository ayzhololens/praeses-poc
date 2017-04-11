using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity;

public class metaUpdate : MonoBehaviour {

    public GameObject parentObj;

	// Use this for initialization
	void Start () {
        Invoke("metaUpdateDelayed", .5f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void metaUpdateDelayed()
    {
        string user;

        user = parentObj.GetComponent<offsiteFieldItemValueHolder>().user;
        if ( user == "")
        {
            user = metaManager.Instance.user;
        }

        gameObject.GetComponent<Text>().text = (System.DateTime.Now.ToString("MM/dd/yy")
                                                + " - " +
                                                user
                                                + ":");
    }
}
