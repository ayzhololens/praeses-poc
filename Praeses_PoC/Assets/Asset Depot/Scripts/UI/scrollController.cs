using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;

public class scrollController : MonoBehaviour {
    bool scrolling;
    Vector3 startPos;
    Vector3 curPos;
    float offset;
    public float sensitivity;
    public GameObject ScrollContent;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (sourceManager.Instance.sourcePressed && GazeManager.Instance.HitObject !=null)
        {



            if ( GazeManager.Instance.HitObject.tag == "ScrollContent" && GazeManager.Instance.HitObject == this.gameObject)
            {
                if (!scrolling)
                {
                    startPos = HandsManager.Instance.ManipulationHandPosition;
                    scrolling = true;
                }
                float lastPos = curPos.y;
                curPos = HandsManager.Instance.ManipulationHandPosition;

                offset = (curPos.y - startPos.y) * sensitivity;
                ScrollContent.transform.position = new Vector3(ScrollContent.transform.position.x, ScrollContent.transform.position.y + offset, ScrollContent.transform.position.z);
                if (curPos.y > startPos.y)
                {
                    if (lastPos > curPos.y)
                    {
                    }



                }

                if (curPos.y < startPos.y)
                {

                }
            }



        }
        else
        {
            scrolling = false;
        }



    }
}
