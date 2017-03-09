using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;

public class lookAtAvatar : Singleton<lookAtAvatar> {

    public Transform avatarObj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (avatarObj)
        {
            transform.LookAt(new Vector3(avatarObj.position.x, transform.position.y, avatarObj.position.z));
        }
    }
}
