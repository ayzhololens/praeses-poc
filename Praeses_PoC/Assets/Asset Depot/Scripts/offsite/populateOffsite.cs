using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;

public class populateOffsite : MonoBehaviour {

    public List<GameObject> cameras;

	// Use this for initialization
	void Start () {
        databaseMan.Instance.loadDefCmd();
        //offsiteJSonLoader.Instance.populateOffsiteForm();
        addNodeFromJSon.Instance.spawnNodeList();
        foreach (GameObject cam in cameras)
        {
            cam.GetComponent<CameraControlOffsite>().focus(0);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
