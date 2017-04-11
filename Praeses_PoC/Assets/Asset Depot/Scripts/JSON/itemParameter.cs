using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemParameter : MonoBehaviour {
    public string itemName;
    public string value;
    public string itemType;

    void Start()
    {
        refreshText();
    }

    void refreshText()
    {
        gameObject.GetComponent<TextMesh>().text = itemName +": " + value;
    }

}
