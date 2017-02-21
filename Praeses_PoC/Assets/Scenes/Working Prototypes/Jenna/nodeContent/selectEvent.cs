using UnityEngine;
using UnityEngine.Events;
using HoloToolkit.Unity.InputModule;

public class selectEvent : MonoBehaviour,  IInputClickHandler 
{
    public UnityEvent Event;

    void Start()
    {
        // dummy Start function so we can use this.enabled
    }

    void OnSelect()
    {
        if (this.enabled == false) return;
        if (Event != null)
        {
            Event.Invoke();
        }
    }





    public void OnInputClicked(InputClickedEventData eventData)
    {
        OnSelect();
    }

}