using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class largerHitbox : MonoBehaviour {

    Collider childCollider;
    //states
    //0=ready
    //1=bigBoxHit
    //2=initialHit
    //3=botHit
    //4=leave

    public int state;
    public bool smallBoxSelected;
    public GameObject magneticGazeManager;

	// Use this for initialization
	void Start () {
        childCollider = gameObject.GetComponentsInChildren<Collider>()[1];
        gameObject.GetComponent<Collider>().enabled = false;
        smallBoxSelected = false;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void bigBoxHitFunc()
    {
        if (state == 0) {
            state = 1;
        gameObject.GetComponent<Collider>().enabled = true;
    }
    }

    void leaveBigBox()
    {
        if (state == 2)
        {
            if (!smallBoxSelected)
            {
                gameObject.GetComponent<Collider>().enabled = false;
                childCollider.enabled = true;
                state = 0;
            }
        }else if(state == 4)
        {
            gameObject.GetComponent<Collider>().enabled = false;
            childCollider.enabled = true;
            state = 0;
        }
    }

    public void leaveBigBoxDeferred()
    {
        Invoke("leaveBigBox", .1f);
    }

    public void smallBoxLeft()
    {
        if (state == 3) { 
        state = 4;
        //gameObject.GetComponent<Collider>().enabled = false;
        childCollider.enabled = true;
            smallBoxSelected = false;
        }
    }

    public void smallBoxHit()
    {
        if (state == 2)
        {
            state = 3;
            gameObject.GetComponent<Collider>().enabled = true;
            childCollider.enabled = false;
            smallBoxSelected = true;
        } else if (state == 1){
            if (!smallBoxSelected)
            {
                gameObject.GetComponent<Collider>().enabled = true;
                state = 2;
            }
            else if (state == 4)
            {

            }
        }
    }
}
