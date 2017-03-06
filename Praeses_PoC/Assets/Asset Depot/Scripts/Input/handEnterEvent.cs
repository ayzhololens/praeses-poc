using System.Collections;
using System.Collections.Generic;

using UnityEngine.Events;
using UnityEngine;

public class handEnterEvent : MonoBehaviour {
    
    public UnityEvent Event;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnFocusEnter()
    {
        if (this.enabled == false) return;
        if (Event != null)
        {
            Event.Invoke();
            Debug.Log("handEnter");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "handCursor")
        {

            OnFocusEnter();
        }
    }
}
