using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class scrollNavigator : MonoBehaviour, INavigationHandler
{

    bool navigating;
    public float sensitivity;
    public GameObject NavCursor;
    public GameObject scrollBackPlate;
    public float deadZone;
    Vector3 rotatedManipulationOffset;
    Vector3 worldObjectPosition;
    Vector3 initialManipulationPosition;
    Vector3 initialObjectPosition;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GazeManager.Instance.HitObject != null && GazeManager.Instance.HitObject.tag == "ScrollContent")
        {
            if (!navigating && sourceManager.Instance.sourcePressed)
            {
                turnOnScroll();
            }

            if (navigating && !sourceManager.Instance.sourcePressed)
            {
                turnOffScroll();
            }
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
        rotatedManipulationOffset = Quaternion.FromToRotation((Vector3.forward), Camera.main.transform.forward) * eventData.CumulativeDelta;
        worldObjectPosition = initialManipulationPosition + rotatedManipulationOffset * sensitivity;

        NavCursor.transform.position = new Vector3(worldObjectPosition.x, worldObjectPosition.y, NavCursor.transform.position.z);

        float scrollDist = NavCursor.transform.position.y + initialManipulationPosition.y;
        if (scrollDist > initialManipulationPosition.y + deadZone)
        {
            Debug.Log("UP");
            NavCursor.transform.GetChild(0).gameObject.SetActive(true);
            NavCursor.transform.GetChild(1).gameObject.SetActive(false);

            if (scrollDist > .5)
            {

            }
        }

        if (scrollDist < initialManipulationPosition.y - deadZone)
        {
            Debug.Log("Down");
            NavCursor.transform.GetChild(0).gameObject.SetActive(false);
            NavCursor.transform.GetChild(1).gameObject.SetActive(true);
        }

    }


    public void OnNavigationCompleted(NavigationEventData eventData)
    {
        NavCursor.SetActive(false);
        scrollBackPlate.SetActive(false);

    }


    public void OnNavigationCanceled(NavigationEventData eventData)
    {
        NavCursor.SetActive(false);
        scrollBackPlate.SetActive(false);
    }

    void turnOnScroll()
    {
        NavCursor.SetActive(true);
        scrollBackPlate.SetActive(true);
        NavCursor.transform.position = GazeManager.Instance.HitPosition;
        scrollBackPlate.transform.position = GazeManager.Instance.HitPosition;
        navigating = true;
        OnNavigationStarted(null);
    }


    void turnOffScroll()
    {
        navigating = false;
        NavCursor.SetActive(false);
        scrollBackPlate.SetActive(false);
        navigating = false;

    }
    public void HandScrolling()
    {
        //float scrollDist = NavCursor.transform.position.y + initialManipulationPosition.y;
        ////dist = Vector3.Distance(lineEnd.transform.position, startPos) * 20;
        ////holdSpeed = holdSpeed * dist;



        //scrollArrow.transform.position = new Vector3(scrollArrow.transform.position.x, scrollDist, scrollArrow.transform.position.z);
        ////cursor.SetActive(false);
        ////cursor.SetActive(false);
        //////gazeScroll = true;

        ////if (lineEnd.transform.position.y > startPos.y + .005f)
        ////{
        ////    holdScrollDown();
        ////    lineEnd.transform.GetChild(0).gameObject.SetActive(true);
        ////    lineEnd.transform.GetChild(1).gameObject.SetActive(false);
        ////    scrollingUp = false;

        ////    if (lineEnd.transform.position.y > startPos.y + .03f)
        ////    {
        ////        lineEnd.transform.position = new Vector3(lineEnd.transform.position.x, startPos.y + .03f, lineEnd.transform.position.z);
        ////    }
        ////}
        ////if (lineEnd.transform.position.y < startPos.y - .005f)
        ////{
        ////    holdScrollUp();
        ////    lineEnd.transform.GetChild(0).gameObject.SetActive(false);
        ////    lineEnd.transform.GetChild(1).gameObject.SetActive(true);
        ////    scrollingDown = false;

        ////    if (lineEnd.transform.position.y < startPos.y - .03f)
        ////    {
        ////        lineEnd.transform.position = new Vector3(lineEnd.transform.position.x, startPos.y - .03f, lineEnd.transform.position.z);
        ////    }
        ////}
    }
}
