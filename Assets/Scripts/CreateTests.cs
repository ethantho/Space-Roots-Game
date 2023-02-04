using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTests : MonoBehaviour
{
    public GameObject anchor;
    public GameObject end;
    public GameObject line;
    public GameObject newLine;
    public GameObject newEnd;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spawnTest();
        }
    }

    public void spawnTest()
    {
        newEnd = Instantiate(end, new Vector3 (20, 0, 0), transform.rotation);
        newLine = Instantiate(line);
        newLine.GetComponent<RootMove>().start = anchor;
        newLine.GetComponent<RootMove>().end = newEnd;
    }
}
