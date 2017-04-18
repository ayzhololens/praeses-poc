using UnityEngine;
using UnityEngine.Events;
using HoloToolkit.Unity.InputModule;

public class selectEvent : MonoBehaviour,  IInputClickHandler, IFocusable 
{
    public UnityEvent Event;

    AudioSource aud;
    bool focused;
    public bool gazeExit;
    void Start()
    {
        if (Event != null)
        {
            if (GetComponent<AudioSource>() == null)
            {
                gameObject.AddComponent<AudioSource>();
            }
            if (aud == null)
            {
                aud = GetComponent<AudioSource>();
                aud.spatialBlend = 1;
                aud.minDistance = 2;
                aud.maxDistance = 5;

            }
        }
    }

    public void OnSelect()
    {

        if (this.enabled == false) return;
        if (Event != null)
        {

            Event.Invoke();

            Debug.Log("select");
            aud.clip = audioManager.Instance.selectSound;
            aud.Play();
        }

        if (GetComponent<gazeLeaveEvent>() != null && gazeExit)
        {
            GetComponent<gazeLeaveEvent>().OnFocusExit();
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