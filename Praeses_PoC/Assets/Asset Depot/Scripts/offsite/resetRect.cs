using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetRect : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<RectTransform>().transform.localPosition = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
