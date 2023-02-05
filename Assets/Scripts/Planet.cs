using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    private bool planted = false;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("plantedAnim", false);
    }
    public void Plant()
    {
        if (!planted)
        {
            planted = true;
            anim.SetBool("plantedAnim", true);
        }
        Debug.Log("Planted!");
    }

    public bool isPlanted()
    {
        return planted;
    }
}
