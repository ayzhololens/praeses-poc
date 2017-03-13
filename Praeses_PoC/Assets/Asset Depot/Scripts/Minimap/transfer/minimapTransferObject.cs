using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity;

public class minimapTransferObject : Singleton<minimapTransferObject> {
    //Vector3 initPos;

    public void mainFunc(GameObject processObj)
    {
        //print("processed:" + processObj);
        //initPos = gameObject.transform.position;
        minimapSpawn.Instance.MiniMapHolderParent.transform.localScale = minimapSpawn.Instance.MiniMapHolderParent.transform.localScale / minimapSpawn.Instance.scaleOffset;
        minimapSpawn.Instance.MiniMapHolderParent.transform.position = minimapSpawn.Instance.boilerPivot;
        processObj.transform.SetParent(minimapSpawn.Instance.MiniMapHolderParent.transform);
        minimapSpawn.Instance.MiniMapHolderParent.transform.localPosition = Vector3.zero;
        minimapSpawn.Instance.MiniMapHolderParent.transform.localScale = Vector3.one;
        processObj.transform.SetParent(minimapSpawn.Instance.miniMapHolder.transform);
    }
}
