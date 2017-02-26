using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;

public class navigationDrag : MonoBehaviour, INavigationHandler
{
    
    bool navigating;
    public float sensitivity;
    public GameObject NavCursor;
    Vector3 rotatedManipulationOffset;
    Vector3 worldObjectPosition;
    Vector3 initialManipulationPosition;
    Vector3 initialObjectPosition;
    private Interpolator interpolator;
    bool manipulating;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (!navigating && sourceManager.Instance.sourcePressed)
        {
            NavCursor.SetActive(true);
            NavCursor.transform.position = GazeManager.Instance.HitPosition;
            navigating = true;
            NavCursor.SendMessage("startNav", SendMessageOptions.DontRequireReceiver);
            OnNavigationStarted(null);
        }

        if (navigating && !sourceManager.Instance.sourcePressed)
        {
            navigating = false;
            NavCursor.SetActive(false);
        }



    }

    public void OnNavigationStarted(NavigationEventData eventData)
    {
        rotatedManipulationOffset = Vector3.zero;
        worldObjectPosition = Vector3.zero;

        //initialManipulationPosition = Camera.main.transform.position + Camera.main.transform.forward;
        initialManipulationPosition = NavCursor.transform.position;
        initialObjectPosition = initialManipulationPosition;

        interpolator = GetComponent<Interpolator>();
    }


    public void OnNavigationUpdated(NavigationEventData eventData)
    {
        rotatedManipulationOffset = Quaternion.FromToRotation((Vector3.forward), Camera.main.transform.forward) * eventData.CumulativeDelta;
        worldObjectPosition = initialManipulationPosition + rotatedManipulationOffset * sensitivity;



        NavCursor.transform.position = worldObjectPosition;
    }


    public void OnNavigationCompleted(NavigationEventData eventData)
    {
        NavCursor.SetActive(false);
        NavCursor.GetComponent<Renderer>().material.color = Color.white;
    }


    public void OnNavigationCanceled(NavigationEventData eventData)
    {
        NavCursor.SetActive(false);
        NavCursor.GetComponent<Renderer>().material.color = Color.white;
    }
}
