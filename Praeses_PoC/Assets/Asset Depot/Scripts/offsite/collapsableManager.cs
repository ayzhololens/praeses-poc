using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collapsableManager : MonoBehaviour {

    public float startCollapse = 1400;
    public GameObject content;


    void adjustToBox(collapseableBox box)
    {
        if (box.boxState)
        {
            startCollapse += box.expandSize;
        }
        else
        {
            startCollapse -= box.expandSize;
        }
    }

    public void readjustBox()
    {
        content.GetComponent<RectTransform>().sizeDelta = new Vector2(content.GetComponent<RectTransform>().rect.width,
            startCollapse);
    }
}
