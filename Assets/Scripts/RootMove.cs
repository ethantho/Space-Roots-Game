using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootMove : MonoBehaviour
{
    public LineRenderer line;
    public GameObject start;
    public GameObject end;
    [SerializeField] DistanceJoint2D joint;



    // Start is called before the first frame update
    void Start()
    {
        line.SetPosition(0, start.transform.position);
        line.SetPosition(1, end.transform.position);
        joint = end.GetComponent<DistanceJoint2D>();
        //joint.connectedBody = end.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        line.SetPosition(0, start.transform.position);
        line.SetPosition(1, end.transform.position);
        if (Input.GetKey(KeyCode.C))
        {
            
            joint.enabled = true;
            joint.distance = Vector2.Distance(start.transform.position, end.transform.position);
            joint.connectedBody = start.GetComponent<Rigidbody2D>();
        }
        else
        {
            joint.enabled = false;
        }


        //joint.connectedBody = end.GetComponent<Rigidbody2D>();
    }
}