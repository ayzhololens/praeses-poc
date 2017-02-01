using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectTumbler : MonoBehaviour
{
    public GameObject tumbledObject;

    public int typing;
    //0=scale up
    //1=scale up
    //2=rotateCCW
    //3=rotateCW
    //4=mvRt
    //5=mvDn
    //6=mvLt
    //7=mvUp

    public void executeTap()
    {
        if (typing == 0)
        {
            print("scaUp");
            tumbledObject.transform.localScale *= 1.2f;
        }
        else if (typing == 1)
        {
            print("scaDn");
            tumbledObject.transform.localScale *= .833333f;
        }
        else if (typing == 2)
        {
            print("rotateCCW");
            tumbledObject.transform.localRotation *= Quaternion.Euler(0, -15, 0);
        }
        else if (typing == 3)
        {
            print("rotateCW");
            tumbledObject.transform.localRotation *= Quaternion.Euler(0, 15, 0);
        }
        else if (typing == 4)
        {
            print("mvRt");
        }
        else if (typing == 5)
        {
            print("mvDn");
        }
        else if (typing == 6)
        {
            print("mvLt");
        }
        else if (typing == 7)
        {
            print("mvUp");
        }
    }
}
