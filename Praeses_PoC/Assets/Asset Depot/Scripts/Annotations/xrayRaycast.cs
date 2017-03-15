using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class xrayRaycast : MonoBehaviour {

    float distance = 50.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;
        if (gameObject.GetComponent<Collider>().Raycast(ray, out hit, distance))
        {
            //Debug.Log(hit.transform.name);
            //blockingObject.layer = "ignoreRaycast";
            GazeManager.Instance.HitObject = gameObject;
            //print(GazeManager.Instance.HitObject);
        }
        //Debug.DrawLine(ray.origin, ray.origin + ray.direction * distance);
}

    public void test()
    {
        print("eggg");
    }
}
