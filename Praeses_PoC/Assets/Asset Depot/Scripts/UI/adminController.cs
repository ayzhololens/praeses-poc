﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HoloLensXboxController;

public class adminController : MonoBehaviour {

    //private ControllerInput controllerInput;
    public GameObject contentHolder;

    // Use this for initialization
    void Start () {

        //controllerInput = new ControllerInput(0, 0.19f);

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("pressed AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            toggleMenu();

        }

        //if (controllerInput.GetButtonDown(ControllerButton.LeftThumbstick))
        //{
        //    toggleMenu();
        //}

    }

    public void toggleMenu()
    {
        contentHolder.SetActive(!contentHolder.activeSelf);
    }
}
