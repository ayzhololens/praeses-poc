#if WINDOWS_UWP
using System.Collections;
using System.Collections.Generic;
#endif

using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class fieldKeywordVariable : MonoBehaviour {
    public string keyword;

    private void Start()
    {
    }


    public void formToClassValueSyncLambda()
    {
        InputField field = gameObject.GetComponent<InputField>();
        string value = field.text;
        print (value+" reflected in class keyword: " + keyword);
        databaseMan.Instance.formToClassValueSync(keyword, value);
    }

}
