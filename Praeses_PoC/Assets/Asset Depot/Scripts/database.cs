using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class database : MonoBehaviour
{
    public string saveDir; 
    public string loadDir; 
    public string JsonText;
    public MainForm formObject;

    private void Start()
    {
        saveDir = "C:/Users/jjohar/Documents/json test/JJ_write/savedJson.txt";
        loadDir = "C:/Users/jjohar/Documents/PRAESES/JO_JJ.txt";
        JsonText = File.ReadAllText(loadDir);
    }
    
    [System.Serializable]
    public class MainForm
    {
        public EquipmentFieldsClass EquipmentFields = new EquipmentFieldsClass();
        public EquipmentFieldsClass EquipmentInspectionFields = new EquipmentFieldsClass();
        public LocationsClass Locations = new LocationsClass();
        public string City;
        public string County;
        public string Country;
        public int LocationID;
        public string LocationName;
        public string State;
        public string Zip;
    }

    [System.Serializable]
    public class EquipmentFieldsClass
    {
        public List<fieldItem> threeNine = new List<fieldItem>();
    }

    [System.Serializable]
    public class fieldItem
    {
        public string DisplayName;
        public int FieldType;
        public string Name;
        public bool Required;
        public Dictionary<string,string> Options = new Dictionary<string, string>();
    }

    [System.Serializable]
    public class LocationsClass
    {
        public string address1;
        public string address2;
        public List<ObjectsClass> Equipment = new List<ObjectsClass>();
    }

    [System.Serializable]
    public class ObjectsClass
    {
        public ObjectsDataClass EquipmentData = new ObjectsDataClass();
        public PreviousInspectionClass PreviousInspection = new PreviousInspectionClass();
        public List<ViolationsClass> Violations = new List<ViolationsClass>();
    }

    [System.Serializable]
    public class ObjectsDataClass
    {
        public ItemClass strJurisNumber = new ItemClass();
        public ItemClass dtCertExpire = new ItemClass();
        public ItemClass strNBNumber = new ItemClass();
        public ItemClass intObjCategoryID = new ItemClass();
        public ItemClass intObjID = new ItemClass();
        public ItemClass intObjStatusId = new ItemClass();
        public ItemClass fltSV1SizeIn  = new ItemClass();
        public ItemClass intObjSizeTypeID = new ItemClass();
        public ItemClass intObjTypeId = new ItemClass();
        public ItemClass intStampedMAWP = new ItemClass();
        public ItemClass strOtherNumber = new ItemClass();
        public ItemClass strOwnerNumber = new ItemClass();
    }

    [System.Serializable]
    public class PreviousInspectionClass
    {
        public Dictionary<string, string> InspectionData = new Dictionary<string, string>();
    }

    [System.Serializable]
    public class ViolationsClass
    {
        public Dictionary<string, string> ViolationData = new Dictionary<string, string>();
    }

    [System.Serializable]
    public class ItemClass
    {
        public string value;
        public List<AnnotationClass> annotations = new List<AnnotationClass>();
    }

    [System.Serializable]
    public class AnnotationClass
    {
        public string type;
        public string value;
        public List<float> coordinate = new List<float>();
    }

    public void saveCmd()
    {
        string json = JsonConvert.SerializeObject(formObject, Formatting.Indented);
        System.IO.File.WriteAllText(saveDir, json);
        print("jsonSaved");
    }

    public void loadCmd()
    {
        formObject = JsonConvert.DeserializeObject<MainForm>(JsonText);
        print("jsonLoaded");
        foreach (KeyValuePair<string, string> temp in formObject.Locations.Equipment[0].PreviousInspection.InspectionData)
        {
            print(temp.Value);
        }
    }

    public void addAnnotation(string type, string value, List<float> coordinate)
    {
        AnnotationClass newAnn = new AnnotationClass();
        newAnn.type = type;
        newAnn.value = value;
        newAnn.coordinate = coordinate;
        formObject.Locations.Equipment[0].EquipmentData.strJurisNumber.annotations.Add(newAnn);
    }
}
