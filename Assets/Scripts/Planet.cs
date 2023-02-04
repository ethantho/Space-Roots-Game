using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    private bool planted = false;


    public void Plant()
    {
        if (!planted)
        {
            planted = true;
        }
    }
}
