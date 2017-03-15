//#if WINDOWS_UWP
//using Newtonsoft.Json;
//using System.Collections;
//#endif

using Newtonsoft.Json;
using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using System.IO;

using UnityEngine.UI;
using HoloToolkit.Unity;

public class databaseMan : Singleton<databaseMan>
{
    public string saveDir; 
    public string definitionsDir;
    public string valuesDir;
    public string defJsonText;
    public string valJsonText;
    public MainForm definitions;
    public ValuesClass values;


    public Dictionary<string, GameObject> formPairs = new Dictionary<string, GameObject>();

    private void Start()
    {
        definitionsDir = Path.Combine(Application.persistentDataPath, "JO_JJ.json");
        valuesDir = Path.Combine(Application.persistentDataPath, "JO_JJ_values.json");
        saveDir = Path.Combine(Application.persistentDataPath, "savedJson.json");
    }
    
    [System.Serializable]
    public class MainForm
    {
        public EquipmentFieldsClass EquipmentFields = new EquipmentFieldsClass();
        public EquipmentFieldsClass EquipmentInspectionFields = new EquipmentFieldsClass();
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
    public class ValuesClass
    {
        public LocationsClass Location = new LocationsClass();
    }

    [System.Serializable]
    public class LocationsClass
    {
        public int LocationID;
        public string LocationName;
        public AddressClass Address = new AddressClass();
        public List<ObjectsClass> Equipment = new List<ObjectsClass>();
    }

    [System.Serializable]
    public class AddressClass
    {
        public string address1;
        public string address2;
        public string City;
        public string County;
        public string Country;
        public string State;
        public string Zip;
    }

    [System.Serializable]
    public class ObjectsClass
    {
        public List<ItemClass> EquipmentData = new List<ItemClass>();
        public List<PreviousInspectionClass> PreviousInspection = new List<PreviousInspectionClass>();
        public List<ViolationsClass> Violations = new List<ViolationsClass>();
        public List<NodeClass> Nodes = new List<NodeClass>();
    }

    [System.Serializable]
    public class PreviousInspectionClass
    {
        public List<ItemClass> InspectionData = new List<ItemClass>();
    }

    [System.Serializable]
    public class ViolationsClass
    {
        public Dictionary<string, string> ViolationData = new Dictionary<string, string>();
        public int nodeIndex;
    }

    [System.Serializable]
    public class ItemClass
    {
        public string name;
        public string value;
        public int nodeIndex;
    }

    [System.Serializable]
    public class NodeClass
    {
        public List<float> transform = new List<float>();
        public string title;
        public string user;
        public string date;
        public string description;
        public string audioPath;
        public List<comment> comments = new List<comment>();
        public List<media> medias = new List<media>();
        public int indexNum;
        //1=generic,2=form, 3=violation
        public string type;
    }

    [System.Serializable]
    public class comment
    {
        public string content;
        public string user;
        public string date;
    }

    [System.Serializable]
    public class media
    {
        //1=simple,2=photo,3=video
        public int type;
        public string path;
        public string user;
        public string date;
    }

    public void saveCmd()
    {
        //#if WINDOWS_UWP
        //        string json = JsonConvert.SerializeObject(values, Formatting.Indented);
        //        System.IO.File.WriteAllText(saveDir, json);
        //#endif
        string json = JsonConvert.SerializeObject(values, Formatting.Indented);
        System.IO.File.WriteAllText(saveDir, json);

        print("jsonSaved");
    }

    public void loadDefCmd()
    {
        //#if WINDOWS_UWP
        //        defJsonText = File.ReadAllText(definitionsDir);
        //        definitions = JsonConvert.DeserializeObject<MainForm>(defJsonText);
        //#endif

        defJsonText = File.ReadAllText(definitionsDir);
        definitions = JsonConvert.DeserializeObject<MainForm>(defJsonText);

        print("jsonDefinitionsLoaded");
        loadValCmd();
        JU_databaseMan.Instance.loadDefCmd();
        //#if WINDOWS_UWP
        //        buildUI(EFcanvasObject,definitions.EquipmentFields.threeNine, values.Location.Equipment[0].EquipmentData);
        //        buildUI(EIFcanvasObject, definitions.EquipmentInspectionFields.threeNine, values.Location.Equipment[0].PreviousInspection[0].InspectionData);
        //#endif

        //buildUI(EFcanvasObject,definitions.EquipmentFields.threeNine, values.Location.Equipment[0].EquipmentData);
        //buildUI(EIFcanvasObject, definitions.EquipmentInspectionFields.threeNine, values.Location.Equipment[0].PreviousInspection[0].InspectionData);
    }

    public void loadValCmd()
    {
        //#if WINDOWS_UWP
        //        valJsonText = File.ReadAllText(valuesDir);
        //        values = JsonConvert.DeserializeObject<ValuesClass>(valJsonText);
        //#endif

        valJsonText = File.ReadAllText(valuesDir);
        values = JsonConvert.DeserializeObject<ValuesClass>(valJsonText);

        print("jsonValuesLoaded");
    }

    public void addAnnotation(GameObject nodeObj)
    {
        NodeClass newNode = new NodeClass();
        Vector3 pos = nodeObj.transform.position;
        Quaternion rot = nodeObj.transform.rotation;
        Vector3 sca = nodeObj.transform.localScale;

        float[] floats = new float[] { pos.x, pos.y, pos.z, rot.x, rot.y, rot.z, rot.w, sca.x, sca.y, sca.z };
        foreach(float flo in floats)
        {
            newNode.transform.Add(flo);
        };

        if (nodeObj.GetComponent<annotationMediaHolder>() != null)
        {
            newNode.type = "0";
        }else if(nodeObj.GetComponent<formNodeController>() != null)
        {
            newNode.type = "1";
        }
        //newNode.title = ;
        //public string user;
        //public string date;
        //public string description;
        //public string audioPath;
        //public List<comment> comments = new List<comment>();
        //public List<media> medias = new List<media>();
        //public int indexNum;
        ////1=generic,2=form, 3=violation
        //public string type;
    }

    public void formToClassValueSync(string keyword, string value)
    {
        List<ItemClass> itemClasses = new List<ItemClass>();
        foreach (ItemClass item in values.Location.Equipment[0].EquipmentData)
        {
            itemClasses.Add(item);
        };
        foreach (ItemClass item in values.Location.Equipment[0].PreviousInspection[0].InspectionData)
        {
            itemClasses.Add(item);
        };
        foreach (ItemClass item in itemClasses)
        {
            if (item.name == keyword)
            {
                InputField field = formPairs[keyword].GetComponentInChildren<InputField>();
                item.value = value;
            }
        };
    }

}
