using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;
using UnityEngine.UI;
using HoloToolkit.Unity.InputModule;

public class commentManager : MonoBehaviour {

    public List<GameObject> activeComments;
    public Collider scrollBoxCollider;
    public int commentCount;
    public Transform commentParent;
    public Transform CommmentStartPos;
    Vector3 startPos;
    public GameObject newCommentBox;
    public float offsetDist;
    InputField activeInputField;
    

	// Use this for initialization
	void Start () {
        
        //GameObject comment1 = Instantiate(newCommentBox, transform.position, Quaternion.identity);
        //comment1.transform.SetParent(commentParent);
        //comment1.transform.localScale = newCommentBox.transform.localScale;
        //comment1.transform.position = CommmentStartPos.position;
        //GameObject comment2 = Instantiate(newCommentBox, transform.position, Quaternion.identity);
        //comment2.transform.SetParent(commentParent);
        //comment2.transform.localScale = newCommentBox.transform.localScale;
        //comment2.transform.position = new Vector3 (comment1.transform.position.x, comment1.transform.position.y-offsetDist, comment1.transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void spawnNewComment()
    {
        startPos = CommmentStartPos.position;
        if (commentCount == 0)
        {
            commentParent.parent.gameObject.SetActive(true);
        }

        if (commentCount == 2)
        {
            scrollBoxCollider.enabled = true;
        }

        for (int i = 0; i < activeComments.Count; i++)
        {
            activeComments[i].transform.position = new Vector3(activeComments[i].transform.position.x,
                                                                activeComments[i].transform.position.y - offsetDist,
                                                                activeComments[i].transform.position.z);
        }

        activeComments.Add((GameObject)Instantiate(newCommentBox, transform.position, Quaternion.identity));
        activeComments[commentCount].transform.SetParent(commentParent);
        activeComments[commentCount].transform.localScale = newCommentBox.transform.localScale;
        activeComments[commentCount].transform.position = startPos;
        activeComments[commentCount].transform.localRotation = CommmentStartPos.localRotation;
        //activeComments[commentCount].AddComponent<inputFieldManager>();
        //activeInputField = activeComments[commentCount].GetComponent<commentContents>().inputField;
        //activeComments[commentCount].AddComponent<inputFieldManager>().mainInputField = activeInputField;
        Invoke("fieldActivator", .2f);
        GetComponent<nodeMediaHolder>().activeComments.Add(activeComments[commentCount]);
        activeComments[commentCount].GetComponent<commentContents>().Date = System.DateTime.Now.ToString();
        activeComments[commentCount].GetComponent<commentContents>().user = metaManager.Instance.user;
        activeComments[commentCount].GetComponent<commentContents>().commentMeta.text = (metaManager.Instance.user + " " + System.DateTime.Now);
        activeComments[commentCount].GetComponent<commentContents>().linkedComponent = this.gameObject;

        //activeComments[commentCount].GetComponent<commentContents>().commentMain.text = ("Comment "+ commentCount);
        //startPos = new Vector3(startPos.x, startPos.y - offsetDist, startPos.z);
    }

    public virtual  GameObject spawnNewCommentFromJSon()
    {
        GameObject output;

        startPos = CommmentStartPos.position;
        if (commentCount == 0)
        {
            commentParent.parent.gameObject.SetActive(true);
        }

        if (commentCount == 2)
        {
            scrollBoxCollider.enabled = true;
        }

        for (int i = 0; i < activeComments.Count; i++)
        {
            activeComments[i].transform.position = new Vector3(activeComments[i].transform.position.x,
                                                                activeComments[i].transform.position.y - offsetDist,
                                                                activeComments[i].transform.position.z);
        }

        activeComments.Add((GameObject)Instantiate(newCommentBox, transform.position, Quaternion.identity));
        activeComments[commentCount].transform.SetParent(commentParent);
        activeComments[commentCount].transform.localScale = newCommentBox.transform.localScale;
        activeComments[commentCount].transform.position = startPos;
        activeComments[commentCount].transform.localRotation = CommmentStartPos.localRotation;
        output = activeComments[commentCount];
        GetComponent<nodeMediaHolder>().activeComments.Add(activeComments[commentCount]);
        activeComments[commentCount].GetComponent<commentContents>().linkedComponent = this.gameObject;
        commentCount += 1;
        return output;
    }

    void fieldActivator()
    {

        activeComments[commentCount].GetComponent<inputFieldManager>().activateField();
        commentCount += 1;


    }
}
