using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class formController : MonoBehaviour {

    public GameObject inspectionTab;
    public GameObject equipmentTab;
    public GameObject locationTab;
    public GameObject contentHolder;
    bool isOpen;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void openEquipmentTab()
    {
        if (!equipmentTab.activeSelf)
        {
            equipmentTab.SetActive(true);
        }
        if (inspectionTab.activeSelf)
        {
            inspectionTab.SetActive(false);
        }
        if (locationTab.activeSelf)
        {
            locationTab.SetActive(false);
        }
    }

    public void openLocationTab()
    {
        if (equipmentTab.activeSelf)
        {
            equipmentTab.SetActive(false);
        }
        if (inspectionTab.activeSelf)
        {
            inspectionTab.SetActive(false);
        }
        if (!locationTab.activeSelf)
        {
            locationTab.SetActive(true);
        }
    }

    public void openInspectionTab()
    {
        if (equipmentTab.activeSelf)
        {
            equipmentTab.SetActive(false);
        }
        if (!inspectionTab.activeSelf)
        {
            inspectionTab.SetActive(true);
        }
        if (locationTab.activeSelf)
        {
            locationTab.SetActive(false);
        }
    }

    public void toggleForm()
    {
        contentHolder.SetActive(!contentHolder.activeSelf);
    }

    public void closeForm()
    {
        contentHolder.SetActive(false);
    }

    public void openForm()
    {
        contentHolder.SetActive(true);
    }
}
