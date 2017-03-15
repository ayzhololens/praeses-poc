using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class printCmd : MonoBehaviour {

    public string saveDir;
    public string saveDir1;
    public string saveDir2;
    public string json;
    public string JO_JJ;
    public string JO_JJ_values;
    //   public GameObject printItem;
    //   public GameObject dataManager;

    //   TextMesh textNode;

    //// Use this for initialization
    //void Start () {
    //       textNode = printItem.GetComponent<TextMesh>();

    //   }

    public void setText()
    {
        print("hello jeff");
        //json = "hi there";
        //saveDir = Path.Combine(Application.persistentDataPath, "hiThere.txt");
        //System.IO.File.WriteAllText(saveDir, json);
        JO_JJ = "{ \"EquipmentFields\": { \"threeNine\": [ { \"DisplayName\": \"Cert Exp Date\", \"FieldType\": 14, \"Name\": \"dtCertExpire\", \"Required\": true, \"Options\": {} }, { \"DisplayName\": \"Jurisdiction Number / Vessel Number\", \"FieldType\": 3, \"Name\": \"strJurisNumber\", \"Required\": true, \"Options\": {} }, { \"DisplayName\": \"National Board #\", \"FieldType\": 3, \"Name\": \"strNBNumber\", \"Required\": false, \"Options\": {} }, { \"DisplayName\": \"Serial/Other Nbr\", \"FieldType\": 3, \"Name\": \"strOtherNumber\", \"Required\": false, \"Options\": {} }, { \"DisplayName\": \"Status\", \"FieldType\": 1, \"Name\": \"intObjStatusId\", \"Required\": true, \"Options\": { \"123\": \"Active\", \"121\": \"Inactive\", \"127\": \"Scrapped\" } }, { \"DisplayName\": \"Type\", \"FieldType\": 1, \"Name\": \"intObjTypeId\", \"Required\": true, \"Options\": { \"252226\": \"Cast Alum\", \"252127\": \"Cast Iron\", \"252128\": \"Chemical Recovery\", \"252129\": \"CI Section\", \"252130\": \"Coil\", \"252131\": \"Economizer\", \"252132\": \"Electric Boiler\", \"252133\": \"Electric Steam Generator\", \"252134\": \"Fire Tube\", \"252135\": \"Fired Storage Water Heater\", \"252243\": \"Hot Water Generator\", \"252136\": \"Ht. Recov. Stm. Gen.\", \"252137\": \"Jacketed Steam Kettle\", \"252138\": \"Other\", \"258832\": \"Steam Generation\", \"252140\": \"Vertical Fire Tube Boiler\", \"252141\": \"Waste Heat Boiler\", \"252142\": \"Water Tube\" } }, { \"DisplayName\": \"MAWP\", \"FieldType\": 3, \"Name\": \"intObjBoilerMAWP\", \"Required\": true, \"Options\": {} }, { \"DisplayName\": \"Size (SV) 1\", \"FieldType\": 3, \"Name\": \"fltSV1SizeIn\", \"Required\": true, \"Options\": {} } ] }, \"EquipmentInspectionFields\": { \"threeNine\": [ { \"DisplayName\": \"Inspection Type\", \"FieldType\": 1, \"Name\": \"intActivityTypeID\", \"Required\": false, \"Options\": { \"5\": \"Internal Cert\", \"6\": \"External Cert\", \"2\": \"Internal Non-Cert\", \"1\": \"External Non-Cert\", \"8\": \"Accident Inspect\" } }, { \"DisplayName\": \"Inspection Date\", \"FieldType\": 14, \"Name\": \"dtActivityDate\", \"Required\": true, \"Options\": {} }, { \"DisplayName\": \"Issue Cert.\", \"FieldType\": 16, \"Name\": \"blnIssueCertOK\", \"Required\": true, \"Options\": {} }, { \"DisplayName\": \"Pressure Allowed\", \"FieldType\": 3, \"Name\": \"intObjBoilerPressureAllowed\", \"Required\": true, \"Options\": {} }, { \"DisplayName\": \"SRV 1 Set At\", \"FieldType\": 3, \"Name\": \"intActivityInspectBoilerSVSetPoint\", \"Required\": true, \"Options\": {} }, { \"DisplayName\": \"SRV 1 Cap\", \"FieldType\": 3, \"Name\": \"intActivityInspectSV1Capacity\", \"Required\": true, \"Options\": {} }, { \"DisplayName\": \"S/SRV Type\", \"FieldType\": 1, \"Name\": \"intActivityInspectSVCapacityBasedOnID\", \"Required\": true, \"Options\": { \"240463\": \"BTU/HR\", \"240461\": \"CFM\", \"240462\": \"GPM\", \"240460\": \"LBS/HR\" } } ] } }";
        saveDir1 = Path.Combine(Application.persistentDataPath, "JO_JJ.json");
        System.IO.File.WriteAllText(saveDir1, JO_JJ);
        JO_JJ_values = "{ \"Location\": { \"LocationID\":164159, \"LocationName\":\"Microsoft Corp. Bldg 34 Cafe\", \"Address\":{ \"Address1\":\"3720 159th Ave NE\", \"Address2\":null, \"City\":\"Redmond\", \"County\":\"King\", \"Country\":\"USA\", \"State\":\"WA\", \"Zip\":\"98052-6306\" }, \"Equipment\": [ {\"EquipmentData\":[ { \"name\":\"strJurisNumber\", \"value\":\"07120-14W\", \"annotationIDs\" : [1,3] }, { \"name\":\"dtCertExpire\", \"value\":\"09/09/2016\" }, { \"name\":\"strNBNumber\", \"value\":\"295130\" }, { \"name\":\"intObjCategoryID\", \"value\":\"2\" }, { \"name\":\"intObjID\", \"value\":\"5719550\" }, { \"name\":\"intObjStatusId\", \"value\":\"123\" }, { \"name\":\"fltSV1SizeIn\", \"value\":\"1912000\" }, { \"name\":\"intObjSizeTypeID\", \"value\":\"251775\", \"annotationIDs\" : [2] }, { \"name\":\"intObjTypeId\", \"value\":\"252243\", \"annotationIDs\" : [3] }, { \"name\":\"intStampedMAWP\", \"value\":\"160\" }, { \"name\":\"strOtherNumber\", \"value\":\"F14H20295130\" }, { \"name\":\"strOwnerNumber\", \"value\":null } ], \"PreviousInspection\":[{ \"InspectionData\":[ { \"name\":\"intActivityTypeID\", \"value\":\"6\", \"annotationIDs\" : [2] }, { \"name\":\"intActivityInspectSV1Capacity\", \"value\":\"1300000\" }, { \"name\":\"intActivityInspectSVCapacityBasedOnID\", \"value\":\"240463\" }, { \"name\":\"dtActivityDate\", \"value\":\"08/09/2016\" }, { \"name\":\"intActivityInspectBoilerSVSetPoint\", \"value\":\"30\" }, { \"name\":\"intObjBoilerPressureAllowed\", \"value\":\"160\" }, { \"name\":\"blnIssueCertOK\", \"value\":false }] }], \"Violations\":[ { \"ViolationData\":{ \"violationNumber\":\"1.1.1\", \"violationDate\":\"05-01-2016\", \"violationClassification\":\"2\", \"violationStatus\":\"2\", \"resolveDate\":\"06-01-2016\", \"strCondition\":\"Low Water Cutoff is not installed or installed incorrectly or inoperable or damaged or leaking.\", \"strRequirement\":\"Install or repair or replace item in accordance with State Law & Regs, ASME BPV Code, National Board Inspection Code and Manufacturer Specifications.\", \"strComments\":\"Seems damaged due to use of faulty sealant.\", }, \"annotationIDs\": [1,3] }], \"Annotations\":[ { \"annotationID\":\"1\", \"dateAdded\":\"05-01-2016\", \"type\":\"audio\", \"value\":\"audioFile1.mp3\", \"coordinate\":[ 1.0, 1.0, 1.0 ] }, { \"annotationID\":\"2\", \"dateAdded\":\"07-01-2016\", \"type\":\"audio\", \"value\":\"audioFile1.mp3\", \"coordinate\":[ 2.0, 4.5, 1.0 ] }, { \"annotationID\":\"3\", \"dateAdded\":\"01-01-2016\", \"type\":\"audio\", \"value\":\"audioFile1.mp3\", \"coordinate\":[ 4.0, 1.0, 2.0 ] } ] } ] } }";
        saveDir2 = Path.Combine(Application.persistentDataPath, "JO_JJ_values.json");
        System.IO.File.WriteAllText(saveDir2, JO_JJ_values);
    }

}
