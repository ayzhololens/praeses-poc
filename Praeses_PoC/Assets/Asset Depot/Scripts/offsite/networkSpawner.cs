using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class networkSpawner : MonoBehaviour {

    public GameObject avatarPrefab;
    private NetworkStartPosition[] spawnPoints;
    private int spawnPointIndex;
     
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //if (isServer) { return; };
        //if (Input.GetButtonDown("Jump"))
        //{
        //    CmdspawnPlayer();
        //}
    }

    private void OnServerInitialized()
    {
        print("serverInitialized");

    }

    void OnConnectedToServer()
    {
        print("clientConnected");
        //CmdspawnPlayer();
    }

    
    //[Command]
    //void CmdspawnPlayer()
    //{
    //    print("cmdFired");
    //    GameObject Trainer = null;
    //    spawnPoints = FindObjectsOfType<NetworkStartPosition>();
    //    spawnPointIndex = 0;
    //    Trainer = (GameObject)GameObject.Instantiate(avatarPrefab, spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.rotation);

    //    NetworkServer.Spawn(Trainer);
    //    //spawnPointIndex = (spawnPointIndex + 1) % spawnPoints.Length;
    //}

    void spawnPlayer()
    {
        print("cmdFired");
        GameObject Trainer = null;
        spawnPoints = FindObjectsOfType<NetworkStartPosition>();
        spawnPointIndex = 0;
        Trainer = (GameObject)GameObject.Instantiate(avatarPrefab, spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.rotation);

        NetworkServer.Spawn(Trainer);
        //spawnPointIndex = (spawnPointIndex + 1) % spawnPoints.Length;
    }

}
