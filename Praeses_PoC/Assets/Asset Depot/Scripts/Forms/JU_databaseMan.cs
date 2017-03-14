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

public class JU_databaseMan : Singleton<JU_databaseMan>
{
    public MainForm definitions;
    public ValuesClass values;
    public NodesManager nodesManager;
    public ViolationsManager violationsManager;

    public Dictionary<string, GameObject> formPairs = new Dictionary<string, GameObject>();

    private void Start()
    {

    }

    [System.Serializable]
    public class MainForm
    {
        public LocationsClass LocationFields = new LocationsClass();
        public EquipmentInspectionFields EquipmentData = new EquipmentInspectionFields();
        public EquipmentInspectionFields InspectionFields = new EquipmentInspectionFields();
    }

    [System.Serializable]
    public class EquipmentInspectionFields
    {
        public List<fieldItem> fields = new List<fieldItem>();
    }

    [System.Serializable]
    public class fieldItem
    {
        public string DisplayName;
        public int FieldType;
        public string Name;
        public bool Required;
        public Dictionary<string, string> Options = new Dictionary<string, string>();
    }

    [System.Serializable]
    public class LocationsClass
    {
        public string address1;
        public string address2;
        public string City;
        public string County;
        public string Country;
        public int LocationID;
        public string LocationName;
        public string State;
        public string Zip;
    }

    [System.Serializable]
    public class NodesManager
    {
        public List<nodeItem> nodes = new List<nodeItem>();
    }

    [System.Serializable]
    public class nodeItem
    {
        public List<float> transform = new List<float>();
        public string title;
        public string user;
        public string date;
        public string description;
        public List<comment> comments = new List<comment>();
        public List<media> photos = new List<media>();
        public List<media> videos = new List<media>();
        public int indexNum;
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
        public string path;
        public string user;
        public string date;
    }

    [System.Serializable]
    public class ValuesClass
    {
        public List<valueItem> presentData = new List<valueItem>();
        public List<valueItem> historicData = new List<valueItem>();
    }

    [System.Serializable]
    public class valueItem
    {
        public string name;
        public string value;
        public int nodeIndex;
    }

    [System.Serializable]
    public class ViolationsManager
    {
        public List<ViolationsItem> violations = new List<ViolationsItem>();
    }

    [System.Serializable]
    public class ViolationsItem
    {
        public int index;
        public ViolationCategories categories = new ViolationCategories();
        public ViolationSeverity severity;
        public string date;
        public conditionsAndRequirements conditionsAndRequirements;
        public string comment;
        public int nodeIndex;
    }

    [System.Serializable]
    public class ViolationCategories
    {
        public int selection;
        public ViolationCategory category1 = new ViolationCategory();
        public ViolationCategory category2 = new ViolationCategory();
        public ViolationCategory category3 = new ViolationCategory();
        public ViolationCategoryA category4 = new ViolationCategoryA();
        public ViolationCategory category5 = new ViolationCategory();
        public ViolationCategory category6 = new ViolationCategory();
        public ViolationCategory category7 = new ViolationCategory();
    }

    [System.Serializable]
    public class ViolationCategoryA
    {
        public string value;
        public int selection;
        public ViolationSubCategoryA subCategory1 = new ViolationSubCategoryA();
        public ViolationSubCategory subCategory2 = new ViolationSubCategory();
        public ViolationSubCategory subCategory3 = new ViolationSubCategory();
        public ViolationSubCategory subCategory4 = new ViolationSubCategory();
        public ViolationSubCategory subCategory5 = new ViolationSubCategory();
        public ViolationSubCategory subCategory6 = new ViolationSubCategory();
        public ViolationSubCategory subCategory7 = new ViolationSubCategory();
        public ViolationSubCategory subCategory8 = new ViolationSubCategory();
    }

    [System.Serializable]
    public class ViolationCategory
    {
        public string value;
    }

    [System.Serializable]
    public class ViolationSubCategoryA
    {
        public string value;
        public int selection;
        public ViolationSpecificA speCategory1 = new ViolationSpecificA();
        public ViolationSpecific speCategory2 = new ViolationSpecific();
        public ViolationSpecific speCategory3 = new ViolationSpecific();
        public ViolationSpecific speCategory4 = new ViolationSpecific();
        public ViolationSpecific speCategory5 = new ViolationSpecific();
        public ViolationSpecific speCategory6 = new ViolationSpecific();
        public ViolationSpecific speCategory7 = new ViolationSpecific();
    }

    [System.Serializable]
    public class ViolationSubCategory
    {
        public string value;
    }

    [System.Serializable]
    public class ViolationSpecificA
    {
        public string value;
    }

    [System.Serializable]
    public class ViolationSpecific
    {
        public string value;
    }

    [System.Serializable]
    public class ViolationSeverity
    {
        public fieldItem field;
    }

    [System.Serializable]
    public class conditionsAndRequirements
    {
        public string conditions;
        public string requirements;
    }

    public void loadDefCmd()
    {
        readLocationFields();
        readEquipmentFields();
        readInspectionFields();
        print("JU_jsonDefinitionsLoaded");
        loadNodesCmd();
        loadViolationsCmd();
        loadValCmd();
    }

    public void loadValCmd()
    {
        loadPresent();
        loadHistoric();
    }

    void loadNodesCmd()
    {
        databaseMan.ObjectsClass objectItem = databaseMan.Instance.values.Location.Equipment[0];
        foreach (databaseMan.NodeClass node in objectItem.Nodes)
        {
            nodeItem newNodeItem = new nodeItem();

            newNodeItem.transform = node.transform;

            newNodeItem.title = node.title;
            newNodeItem.user = node.user;
            newNodeItem.date = node.date;
            newNodeItem.description = node.description;
            foreach (databaseMan.comment commentItem in node.comments)
            {
                comment newComment = new comment();
                newComment.content = commentItem.content;
                newComment.user = commentItem.user;
                newComment.date = commentItem.date;
                newNodeItem.comments.Add(newComment);
            }
            foreach (databaseMan.media mediaItem in node.medias)
            {
                media newMedia = new media();
                newMedia.path = mediaItem.path;
                newMedia.user = mediaItem.user;
                newMedia.date = mediaItem.date;
                if (mediaItem.type == 0)
                {
                    newNodeItem.photos.Add(newMedia);
                }else if(mediaItem.type == 1)
                {
                    newNodeItem.videos.Add(newMedia);
                }
                
            }
            newNodeItem.indexNum = node.indexNum;
            newNodeItem.type = node.type;

            nodesManager.nodes.Add(newNodeItem);
        }
    }

    void loadViolationsCmd()
    {
        foreach (databaseMan.ViolationsClass violation in databaseMan.Instance.values.Location.Equipment[0].Violations)
        {
            ViolationsItem newViolationItem = new ViolationsItem();

            violationsManager.violations.Add(scriptedViolation(newViolationItem));
        }
    }

    void readLocationFields()
    {
        definitions.LocationFields.address1 = databaseMan.Instance.values.Location.Address.address1;
        definitions.LocationFields.address2 = databaseMan.Instance.values.Location.Address.address2;
        definitions.LocationFields.City = databaseMan.Instance.values.Location.Address.City;
        definitions.LocationFields.County = databaseMan.Instance.values.Location.Address.County;
        definitions.LocationFields.Country = databaseMan.Instance.values.Location.Address.Country;
        definitions.LocationFields.LocationID = databaseMan.Instance.values.Location.LocationID;
        definitions.LocationFields.LocationName = databaseMan.Instance.values.Location.LocationName;
        definitions.LocationFields.State = databaseMan.Instance.values.Location.Address.State;
        definitions.LocationFields.Zip = databaseMan.Instance.values.Location.Address.Zip;
    }

    void readEquipmentFields()
    {
        foreach (databaseMan.fieldItem fieldItem in databaseMan.Instance.definitions.EquipmentFields.threeNine)
        {
            fieldItem newFieldItem = new fieldItem();
            newFieldItem.DisplayName = fieldItem.DisplayName;
            newFieldItem.FieldType = fieldItem.FieldType;
            newFieldItem.Name = fieldItem.Name;
            newFieldItem.Required = fieldItem.Required;
            newFieldItem.Options = fieldItem.Options;
            definitions.EquipmentData.fields.Add(newFieldItem);
        }
    }

    void readInspectionFields()
    {
        foreach (databaseMan.fieldItem fieldItem in databaseMan.Instance.definitions.EquipmentInspectionFields.threeNine)
        {
            fieldItem newFieldItem = new fieldItem();
            newFieldItem.DisplayName = fieldItem.DisplayName;
            newFieldItem.FieldType = fieldItem.FieldType;
            newFieldItem.Name = fieldItem.Name;
            newFieldItem.Required = fieldItem.Required;
            newFieldItem.Options = fieldItem.Options;
            definitions.InspectionFields.fields.Add(newFieldItem);
        }
    }

    void loadPresent()
    {
        foreach (databaseMan.ItemClass item in databaseMan.Instance.values.Location.Equipment[0].EquipmentData)
        {
            valueItem newValueItem = new valueItem();
            newValueItem.name = item.name;
            newValueItem.value = item.value;
            newValueItem.nodeIndex = item.nodeIndex;

            values.presentData.Add(newValueItem);
        }
    }

    void loadHistoric()
    {
        foreach (databaseMan.ItemClass item in databaseMan.Instance.values.Location.Equipment[0].PreviousInspection[0].InspectionData)
        {
            valueItem newValueItem = new valueItem();
            newValueItem.name = item.name;
            newValueItem.value = item.value;
            newValueItem.nodeIndex = item.nodeIndex;

            values.historicData.Add(newValueItem);
        }
    } 

    public virtual ViolationsItem scriptedViolation(ViolationsItem incomingItem)
    {
        return incomingItem;
    }
}
