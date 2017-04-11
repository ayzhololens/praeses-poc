using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class connectToServer : MonoBehaviour {

    public GameObject NetworkManagerNull;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void connectToserver()
    {
        print("hello");
        NetworkManagerNull.GetComponent<NetworkManager>().networkAddress = "10.10.13.0";
        NetworkManagerNull.GetComponent<NetworkManager>().StartClient();
    }

}
