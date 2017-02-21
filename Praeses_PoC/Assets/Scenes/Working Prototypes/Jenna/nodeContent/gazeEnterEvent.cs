using UnityEngine;
using UnityEngine.Events;
using HoloToolkit.Unity.InputModule;

public class gazeEnterEvent : MonoBehaviour,  IFocusable
{
    public UnityEvent Event;

    void Start()
    {
        // dummy Start function so we can use this.enabled
    }

    void GazeEnter()
    {
        if (this.enabled == false) return;
        if (Event != null)
        {
            Event.Invoke();
        }
    }


    public void OnFocusEnter()
    {
        GazeEnter();
    }

    public void OnFocusExit()
    {

    }

 

}