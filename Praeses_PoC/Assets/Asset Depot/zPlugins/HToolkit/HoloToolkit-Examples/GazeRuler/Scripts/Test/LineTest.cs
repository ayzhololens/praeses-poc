using UnityEngine;
using System.Collections;

/// <summary>
/// it's a test case, we try create line correctly between two points
/// </summary>
public class LineTest : MonoBehaviour
{

    public GameObject start;
    public GameObject end;
    public GameObject line;
    public GameObject text;

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(start.transform.position, end.transform.position);
        var midPoint = (start.transform.position + end.transform.position) * 0.5f;
        var direction = end.transform.position - start.transform.position;
        line.transform.position = midPoint;
        line.transform.localScale = new Vector3(distance, .004f, .004f);
        line.transform.rotation = Quaternion.LookRotation(direction);
        line.transform.Rotate(Vector3.down, 90f);
        //text.transform.position = midPoint + new Vector3(0, 0.6f, 0);
        //text.transform.rotation = Quaternion.LookRotation(direction.x + direction.y + direction.z < 0 ? direction * -1 : direction);
        //text.transform.Rotate(Vector3.up, -90f);
    }
}
