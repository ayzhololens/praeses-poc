using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;

public class violatoinSpawner :  Singleton<violatoinSpawner>{

    public violationController activeViolationController;
    public GameObject violationPrefab;
    public GameObject violationCategoryPrefab;
    public GameObject violationSubCategoryPrefab;
    public GameObject violationFieldPrefab;
    public GameObject violationPreview;
    public GameObject violationPreviewField;
    public int amount;
    public int rowLengthBox;
    public float hOffsetBox;
    public float vOffsetBox;
    public float vOffsetField;
    public List<string> VioCat;
    public List<string> VioSubCat;
    public List<string> Vios;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void spawnViolation(GameObject vioNode)
    {
        //spawn violation
        GameObject spawnedViolation = Instantiate(violationPrefab, transform.position, Quaternion.identity);
        
        //link violation and node
        violationController curVio = spawnedViolation.GetComponent<violationController>();
        vioNode.GetComponent<nodeController>().linkedField = spawnedViolation;
        vioNode.GetComponent<nodeController>().contentHolder = curVio.contentHolder;
        curVio.linkedNode = vioNode;

        //store violation during categorization
        activeViolationController = curVio;
        populateCategories();
    }

    public void populateCategories()
    {

        Vector3 startPos = activeViolationController.boxStartPos.localPosition;
        float vOff = 0;
        float hCount = 0;
        Vector3 spawnPos = new Vector3(startPos.x, startPos.y, startPos.z);
        int rLength = rowLengthBox;

        for (int i = 0; i<VioCat.Count; i++)
        {
            if (i == rLength)
            {

                vOff = vOff + vOffsetBox;
                hCount = 0;
                rLength *= 2;
            }


            GameObject spawnedViolation = Instantiate(violationCategoryPrefab, transform.position, Quaternion.identity);
            spawnedViolation.transform.SetParent(activeViolationController.violationTabs[0].transform);
            spawnedViolation.transform.localScale = violationCategoryPrefab.transform.localScale;
            spawnPos = new Vector3(startPos.x + hOffsetBox * hCount, startPos.y - vOff, startPos.z);
            spawnedViolation.transform.localPosition = spawnPos;
            spawnedViolation.transform.localRotation = activeViolationController.boxStartPos.localRotation;

            spawnedViolation.GetComponent<violationComponent>().linkedViolation = activeViolationController;
            spawnedViolation.GetComponent<violationComponent>().Index = i;
            spawnedViolation.GetComponent<violationComponent>().optionTitle.text = VioCat[i];
            hCount += 1;

        }



    }

    public void populateSubCategories(int violationIndex)
    {
        
        Vector3 startPos = activeViolationController.boxStartPos.localPosition;
        float vOff = 0;
        float hCount = 0;
        Vector3 spawnPos = new Vector3(startPos.x, startPos.y, startPos.z);
        int rLength = rowLengthBox;

        for (int i = 0; i < VioSubCat.Count; i++)
        {
            if (i == rLength)
            {

                vOff = vOff + vOffsetBox;
                hCount = 0;
                rLength *= 2;
            }

            GameObject spawnedViolation = Instantiate(violationSubCategoryPrefab, spawnPos, Quaternion.identity);
            spawnedViolation.transform.SetParent(activeViolationController.violationTabs[1].transform);
            spawnedViolation.transform.localScale = violationSubCategoryPrefab.transform.localScale;
            spawnPos = new Vector3(startPos.x + hOffsetBox * hCount, startPos.y - vOff, startPos.z);
            spawnedViolation.transform.localRotation = activeViolationController.boxStartPos.localRotation;
            spawnedViolation.transform.localPosition = spawnPos;
            spawnedViolation.GetComponent<violationComponent>().linkedViolation = activeViolationController;
            spawnedViolation.GetComponent<violationComponent>().Index = i;
            spawnedViolation.GetComponent<violationComponent>().optionTitle.text = VioSubCat[i];
            hCount += 1;

        }

    }

    public void populateViolations(int violationIndex)
    {
        Vector3 startPos = activeViolationController.fieldStartPos.localPosition;
        float vCount = 0;
        Vector3 spawnPos = new Vector3(startPos.x, startPos.y, startPos.z);

        for (int i = 0; i<Vios.Count; i++)
        {

            GameObject spawnedViolation = Instantiate(violationFieldPrefab, transform.position, Quaternion.identity);
            spawnedViolation.transform.SetParent(activeViolationController.violationTabs[2].transform);
            spawnedViolation.transform.localScale = violationFieldPrefab.transform.localScale;
            spawnPos = new Vector3(startPos.x, startPos.y - vOffsetField * vCount, startPos.z);
            spawnedViolation.transform.localRotation = activeViolationController.fieldStartPos.localRotation;
            spawnedViolation.transform.localPosition = spawnPos;
            spawnedViolation.GetComponent<violationComponent>().linkedViolation = activeViolationController;
            spawnedViolation.GetComponent<violationComponent>().Index = i;
            

            string violatioName = "NB# " +
                +activeViolationController.violationIndices[0] + "."
                + activeViolationController.violationIndices[1] + "."
                + i + " | " 
                + activeViolationController.violationData[0] + " -"
                + activeViolationController.violationData[1] + " ";

            spawnedViolation.GetComponent<violationComponent>().optionTitle.text = violatioName;
            vCount += 1;
        }

    }

    public void populatePreviewField()
    {

        if(activeViolationController.linkedPreview == null)
        {
            violationPreview.GetComponent<viewViolationController>().repositionFields();
            GameObject spawnedPreview = Instantiate(violationPreviewField, violationPreview.transform.position, Quaternion.identity);
            spawnedPreview.transform.SetParent(violationPreview.GetComponent<viewViolationController>().fieldParent);
            spawnedPreview.transform.position = violationPreview.GetComponent<viewViolationController>().activePos.position;
            spawnedPreview.transform.localScale = violationPreviewField.transform.localScale;
            spawnedPreview.transform.localRotation = violationPreviewField.transform.localRotation;
            spawnedPreview.GetComponent<viewViolationContent>().linkedViolation = activeViolationController.gameObject;
            spawnedPreview.GetComponent<viewViolationContent>().viewViolationHolder = violationPreview;
            activeViolationController.linkedPreview = spawnedPreview;
            violationPreview.GetComponent<viewViolationController>().vioFields.Add(spawnedPreview);
        }

        viewViolationContent spawnedContent = activeViolationController.linkedPreview.GetComponent<viewViolationContent>();
        spawnedContent.ViolationName.text = activeViolationController.violationData[2];
        spawnedContent.DueDate.text = "Due: " + activeViolationController.violationData[4];
        spawnedContent.DueDate.text = spawnedContent.DueDate.text.Substring(0, spawnedContent.DueDate.text.Length-11);
        spawnedContent.Severity.text = "Severity: " + activeViolationController.violationData[3];
        spawnedContent.metaDate.text = "Added: " + activeViolationController.linkedNode.GetComponent<nodeMediaHolder>().Date;
        spawnedContent.metaDate.text = spawnedContent.metaDate.text.Substring(0, spawnedContent.metaDate.text.Length - 11);

    }
}
