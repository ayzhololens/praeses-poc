using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity
{
    public class fieldSpawner : Singleton<fieldSpawner>
    {
        public GameObject MasterForm;
        public Transform FieldParent;
        public GameObject fieldPrefab;
        public Transform fieldStartPos;
        public float offsetDist;
        public List<GameObject> ActiveFields;
        public int fieldCount;

        // Use this for initialization
        void Start()
        {
            populateFields();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void populateFields()
        {
            //fieldCount = JU_databaseMan.Instance.definitions.InspectionFields.fields.Count;
            for (int i = 0; i < fieldCount; i++)
            {
                GameObject spawnedField = Instantiate(fieldPrefab, transform.position, Quaternion.identity);
                spawnedField.transform.SetParent(FieldParent);
                spawnedField.transform.localPosition = fieldStartPos.localPosition;
                spawnedField.transform.localScale = fieldPrefab.transform.localScale;
                spawnedField.transform.localRotation = fieldPrefab.transform.localRotation;
                fieldStartPos.position = new Vector3(fieldStartPos.position.x, fieldStartPos.position.y - offsetDist, fieldStartPos.position.z);
                ActiveFields.Add(spawnedField);
                //spawnedField.GetComponent<formFieldController>().Field = JU_databaseMan.Instance.definitions.InspectionFields.fields[i].DisplayName;
                //spawnedField.GetComponent<formFieldController>().DisplayName.text = spawnedField.GetComponent<formFieldController>().Field;
            }
        }
    }
}
