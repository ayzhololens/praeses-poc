using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class tumblerNavigationDrag : MonoBehaviour, INavigationHandler
{

    bool navigating;
    public float sensitivity;
    public GameObject NavCursor;
    Vector3 rotatedManipulationOffset;
    Vector3 worldObjectPosition;
    Vector3 initialManipulationPosition;
    Vector3 initialObjectPosition;
    public GameObject menuParent;

    // Use this for initialization
    void Start()
    {
        menuParent.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (!navigating && sourceManager.Instance.sourcePressed)
        {
            NavCursor.SetActive(true);
            menuParent.SetActive(true);
            NavCursor.transform.position = GazeManager.Instance.HitPosition;
            navigating = true;
            NavCursor.SendMessage("startNav", SendMessageOptions.DontRequireReceiver);
            OnNavigationStarted(null);
        }

        if (navigating && !sourceManager.Instance.sourcePressed)
        {
            navigating = false;
            NavCursor.SetActive(false);
            menuParent.SetActive(false);
        }

    }

    public void OnNavigationStarted(NavigationEventData eventData)
    {
        rotatedManipulationOffset = Vector3.zero;
        worldObjectPosition = Vector3.zero;
        initialManipulationPosition = NavCursor.transform.position;
        initialObjectPosition = initialManipulationPosition;
    }

    public void OnNavigationUpdated(NavigationEventData eventData)
    {
        rotatedManipulationOffset = Quaternion.FromToRotation(Vector3.forward, Camera.main.transform.forward) * eventData.CumulativeDelta;
        worldObjectPosition = initialManipulationPosition + rotatedManipulationOffset * sensitivity;
        NavCursor.transform.position = worldObjectPosition;
    }


    public void OnNavigationCompleted(NavigationEventData eventData)
    {
        NavCursor.SetActive(false);
        menuParent.SetActive(false);
    }


    public void OnNavigationCanceled(NavigationEventData eventData)
    {
        NavCursor.SetActive(false);
        menuParent.SetActive(false);
    }
}
