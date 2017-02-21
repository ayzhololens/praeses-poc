using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onOffVisibility : MonoBehaviour {
    bool offOn;

    void toggleOn()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        offOn = true;
    }

    void toggleOff()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        offOn = false;
    }

    public void toggleViz()
    {
        if (offOn)
        {
            toggleOff();
        }else
        {
            toggleOn();
        }
    }

}
