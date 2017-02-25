using System.Collections;
using System.Collections.Generic;

using UnityEngine.Events;
using UnityEngine;

public class handLeaveEvent : MonoBehaviour
{

    public UnityEvent Event;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void HandLeave()
    {
        if (this.enabled == false) return;
        if (Event != null)
        {
            Event.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "handCursor")
        {
            HandLeave();
        }
    }
}
