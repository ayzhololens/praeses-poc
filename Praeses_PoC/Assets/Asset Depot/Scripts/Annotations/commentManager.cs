using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;
using UnityEngine.UI;
using HoloToolkit.Unity.InputModule;

public class commentManager : MonoBehaviour {

    public List<GameObject> activeComments;
    public Collider scrollBoxCollider;
    int commentCount;
    public Transform commentParent;
    public Transform CommmentStartPos;
    Vector3 startPos;
    public GameObject newCommentBox;
    public float offsetDist;
    InputField activeInputField;
    

	// Use this for initialization
	void Start () {
        startPos = CommmentStartPos.position;
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
        if (commentCount == 0)
        {
            commentParent.parent.gameObject.SetActive(true);
        }

        if(commentCount == 2)
        {
            scrollBoxCollider.enabled = true;
        }

        activeComments.Add((GameObject)Instantiate(newCommentBox, transform.position, Quaternion.identity));
        activeComments[commentCount].transform.SetParent(commentParent);
        activeComments[commentCount].transform.localScale = newCommentBox.transform.localScale;
        activeComments[commentCount].transform.position = startPos;
        //activeComments[commentCount].AddComponent<inputFieldManager>();
        //activeInputField = activeComments[commentCount].GetComponent<commentContents>().inputField;
        //activeComments[commentCount].AddComponent<inputFieldManager>().mainInputField = activeInputField;
        activeComments[commentCount].GetComponent<inputFieldManager>().activateField();
        activeComments[commentCount].GetComponent<commentContents>().commentMeta.text = ("Reviewer, " + System.DateTime.Now);
        //activeComments[commentCount].GetComponent<commentContents>().commentMain.text = ("Comment "+ commentCount);
        startPos = new Vector3(startPos.x, startPos.y - offsetDist, startPos.z);
        commentCount += 1;
    }
}
