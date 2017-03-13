using UnityEngine;
using UnityEngine.Events;
using HoloToolkit.Unity.InputModule;

public class selectEvent : MonoBehaviour,  IInputClickHandler, IFocusable 
{
    public UnityEvent Event;


    bool focused;
    void Start()
    {
        // dummy Start function so we can use this.enabled
    }

    public void OnSelect()
    {


        if (this.enabled == false) return;
        if (Event != null)
        {
            Event.Invoke();
            Debug.Log("select");

        }
    }





    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (GazeManager.Instance.HitObject == this.gameObject)
        {
            OnSelect();
        }
        
    }

    public void OnFocusEnter()
    {
        focused = true;
    }

    public void OnFocusExit()
    {
        focused = false;
    }

}