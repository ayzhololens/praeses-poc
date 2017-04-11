using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity;

public class addCommentButton : MonoBehaviour {

    public GameObject addNewCommentWindow;
    public InputField field;
    public GameObject contentParent;
    public GameObject commentSimplePrefab;

    public List<GameObject> commentHolder;

    public Text title;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        addNewCommentWindow.SetActive(true);
        title.text = ("Leave A New Comment, " + metaManager.Instance.user); 
        field.ActivateInputField();
    }

    public void closeWindow()
    {
        field.text = "";
        addNewCommentWindow.SetActive(false);
    }

    public void addOneViolationComment()
    {
        GameObject newItem;
        newItem = Instantiate(commentSimplePrefab);
        float xOffset = 5 + 540 * commentHolder.Count;
        newItem.transform.SetParent(contentParent.transform);
        newItem.GetComponent<RectTransform>().localPosition = new Vector3(xOffset, -18, 0);
        newItem.GetComponent<RectTransform>().localScale = Vector3.one;
        contentParent.GetComponent<RectTransform>().sizeDelta = new Vector2((commentHolder.Count+1) * 540 + 10,
                                                                            contentParent.GetComponent<RectTransform>().rect.height);
        newItem.GetComponent<offsiteFieldItemValueHolder>().content.text = field.text;
        newItem.GetComponent<offsiteFieldItemValueHolder>().user = metaManager.Instance.user;
        newItem.GetComponent<offsiteFieldItemValueHolder>().date = metaManager.Instance.date;

        commentHolder.Add(newItem);
        closeWindow();
    }
}
