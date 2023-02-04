using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootCreate : MonoBehaviour
{
    public GameObject line;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            createLine();
        }
    }

    public void createLine()
    {
        Debug.Log("hi");
        //For creating line renderer object
        Instantiate(line);
    }
}
