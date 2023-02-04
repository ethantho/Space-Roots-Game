using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootMove : MonoBehaviour
{
    public LineRenderer line;
    public GameObject start;
    public GameObject end;

    // Start is called before the first frame update
    void Start()
    {
        line.SetPosition(0, start.transform.position);
        line.SetPosition(1, end.transform.position);
    }

    void Update()
    {
        line.SetPosition(0, start.transform.position);
        line.SetPosition(1, end.transform.position);
    }
}