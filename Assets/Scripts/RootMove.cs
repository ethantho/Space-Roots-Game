using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootMove : MonoBehaviour
{
    public LineRenderer line;
    public Vector3 start;
    public Vector3 end;

    // Start is called before the first frame update
    void Start()
    {
        start = GameObject.Find("Start").transform.position;
        end = Input.mousePosition;
        line.SetPosition(0, start);
        line.SetPosition(1, end);
    }
    void Update()
    {
        end = GameObject.Find("End").transform.position;
        line.SetPosition(1, end);
    }
}
