using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fourCorners : MonoBehaviour {
    List<bool> hits;
    public bool Hit { get; private set; }
    public float MaxGazeDistance = 15.0f;
    public LayerMask RaycastLayerMask = Physics.DefaultRaycastLayers;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hitInfo;
        int hitPointIndex;
        hits.Clear();
        for (hitPointIndex = 0; hitPointIndex < 4; hitPointIndex++)
        {
            Vector3 p = Camera.main.ScreenToWorldPoint(new Vector3(CreateAreaRectangle()[hitPointIndex][0], CreateAreaRectangle()[hitPointIndex][1], 0));
            bool hit = Physics.Raycast(p, Camera.main.transform.forward, out hitInfo, MaxGazeDistance, RaycastLayerMask);
            hits.Add(hit);
        }
        foreach (bool hit in hits)
        {
            if (hit) { Hit = hit; };
        }
    }

    public virtual Vector2[] CreateAreaRectangle()
    {
        //work out center points for screen x and y
        float centerScreenX = Screen.width / 2;
        float centerScreenY = Screen.height / 2;
        //work out a clickable area
        Vector2 xTopLeft = new Vector2(centerScreenX - 30, centerScreenY - 30);
        Vector2 xTopRight = new Vector2(centerScreenX + 30, centerScreenY - 30);
        Vector2 xBottomLeft = new Vector2(centerScreenX - 30, centerScreenY + 30);
        Vector2 xBottomRight = new Vector2(centerScreenX + 30, centerScreenY + 30);
        return (new Vector2[] { xTopLeft, xTopRight, xBottomLeft, xBottomRight });
    }
}
