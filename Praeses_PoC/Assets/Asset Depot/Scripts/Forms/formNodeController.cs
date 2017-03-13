using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;

public class formNodeController : MonoBehaviour {
    public GameObject masterForm;
    public GameObject linkedField;
    public Transform contentHolder;
    public Transform contentLoc;
    float camDistance;
    float contentDistance;
    public float distanceThreshold;
    public float speed;
    bool contentOpen;


    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        //camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        //if (contentHolder.gameObject.activeSelf && contentOpen)
        //{
        //    if (camDistance > distanceThreshold)
        //    {
        //        contentDistance = Vector3.Distance(contentHolder.transform.position, Camera.main.transform.position);
        //        if (contentDistance > 2 && contentHolder.GetComponent<SimpleTagalong>().enabled != true)
        //        {
        //            contentHolder.transform.position = Vector3.MoveTowards(contentHolder.transform.position, Camera.main.transform.position, speed / 1.5f);
        //        }

        //        if (contentDistance < 2 && contentHolder.GetComponent<SimpleTagalong>().enabled != true)
        //        {
        //            contentHolder.GetComponent<SimpleTagalong>().enabled = true;
        //        }



        //    }

        //    if (camDistance < distanceThreshold)
        //    {
        //        if (contentHolder.GetComponent<SimpleTagalong>().enabled == true)
        //        {
        //            contentHolder.GetComponent<SimpleTagalong>().enabled = false;
        //            contentHolder.GetComponent<Interpolator>().enabled = false;
        //        }

        //        contentHolder.transform.position = Vector3.MoveTowards(contentHolder.transform.position, contentLoc.position, speed);


        //    }

        //}






    }



    public void openForm()
    {
        //if (masterForm == null)
        //{
        //    //masterForm = fieldSpawner.Instance.MasterForm;
        //}
        //if(linkedField !=null)
        //{
        //    linkedField.GetComponent<formFieldController>().linkedNode = this.gameObject;
        //}
        //masterForm.SetActive(true);
        ////contentHolder.gameObject.SetActive(true);
        //contentOpen = true;
        //masterForm.transform.position = contentLoc.position;
    }




}
