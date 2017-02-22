using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;


public class sourceManager : Singleton<sourceManager>, ISourceStateHandler, IInputHandler {

    public bool sourcePressed;
    public bool sourceDetected;


	// Use this for initialization
	void Start () {
        InputManager.Instance.PushModalInputHandler(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnSourceDetected(SourceStateEventData eventData)
    {

        if (!sourceDetected)
        {
            sourceDetected = true;
        }
        
    }


    public void OnSourceLost(SourceStateEventData eventData)
    {
        if (sourceDetected)
        {
            sourceDetected = false;
        }
    }


    public void OnInputUp(InputEventData eventData)
    {

        if (sourcePressed)
        {
            sourcePressed = false;
        }
        
    }

    public void OnInputDown(InputEventData eventData)
    {
        if (!sourcePressed)
        {
            sourcePressed = true;
        }
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {

    }


}
