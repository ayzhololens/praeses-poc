using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spatialRadiate : MonoBehaviour {

    public Material spatTap;
    public Material occlusion;
    Transform boiler;
    public float speed;
    float offset;
    bool radiating;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (radiating)
        {

            offset += speed;
            spatTap.SetFloat("_Radius", offset);
        }
		
	}

    public void spatRadiate()
    {
        for(int i=0; i<transform.childCount; i++)
        {
            if(transform.GetChild(i).gameObject.GetComponent<Renderer>() == null)
            {
                transform.GetChild(i).GetChild(0).gameObject.GetComponent<Renderer>().material = spatTap;
            }
            else
            {
                transform.GetChild(i).gameObject.GetComponent<Renderer>().material = spatTap;
            }
            

            if (transform.GetChild(i).gameObject.tag == "boilerPrefab")
            {
                boiler = transform.GetChild(i);
            }
        }

        Vector4 loc = new Vector4(boiler.position.x, boiler.position.y, boiler.position.z, 0);

        spatTap.SetVector("_Center", loc);
        spatTap.SetFloat("_Radius", 0);
        offset = 0;
        radiating = true;
        Invoke("finishRadiating", 8);

    }

    void finishRadiating()
    {
        radiating = false;
        offset = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.GetComponent<Renderer>() == null)
            {
                transform.GetChild(i).GetChild(0).gameObject.GetComponent<Renderer>().material = occlusion;
            }
            else
            {
                transform.GetChild(i).gameObject.GetComponent<Renderer>().material = occlusion;
            }
            
        }

    }
}
