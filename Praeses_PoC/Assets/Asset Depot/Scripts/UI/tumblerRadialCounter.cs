using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class tumblerRadialCounter : MonoBehaviour {

    public float loaderSpeed;
    public bool counting;

    // Use this for initialization
    void Start () {
        counting = false;
        //transform.parent.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetButtonDown("Jump"))
        //{
        //    toggleAnim();
        //}
    }

    public void radialCounterOn()
    {
        //print("startedCounting");
        counting = true;
        //transform.parent.gameObject.GetComponent<MeshRenderer>().enabled = true;
        GetComponent<Animator>().SetBool("anim", true);
        GetComponent<Animator>().SetFloat("speed", 1 / loaderSpeed);
        Invoke("finish", loaderSpeed* 21/12);
    }

    public void radialCounterInterrupt()
    {
        if (!counting) { return; };
        //print("interruptedCounting");
        
        //transform.parent.gameObject.GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Animator>().SetBool("anim", false);
        GetComponent<Animator>().SetFloat("speed", 0);
        CancelInvoke();
        counting = false;

    }

    private void finish()
    {
        //print("finishCounting");
        
        //transform.parent.gameObject.GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Animator>().SetBool("anim", false);
        GetComponent<Animator>().SetFloat("speed", 0);

    }

    public void toggleAnim()
    {
        if (counting)
        {
            radialCounterInterrupt();
            counting = false;
        }
        else
        {
            radialCounterOn();
            counting = true;
        }
    }

}
