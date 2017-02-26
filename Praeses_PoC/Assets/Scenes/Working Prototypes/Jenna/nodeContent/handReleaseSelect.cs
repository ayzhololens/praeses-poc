using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

public class handReleaseSelect : MonoBehaviour {

    public UnityEvent Event;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        
		
	}

    void HandSelect()
    {
        if (this.enabled == false) return;
        if (Event != null)
        {
            Event.Invoke();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "handCursor")
        {
            if (!sourceManager.Instance.sourcePressed)
            {
                HandSelect();
            }
        }
    }
}
