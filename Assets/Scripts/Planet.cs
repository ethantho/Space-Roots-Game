using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    private bool planted = false;
    private Animator anim;
    public ScoreBoard sb;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("plantedAnim", false);
        sb = (ScoreBoard)FindObjectOfType(typeof(ScoreBoard));
    }
    public void Plant()
    {
        if (!planted)
        {
            planted = true;
            anim.SetBool("plantedAnim", true);

            if(gameObject.tag != "Home")
                sb.Score();
        }
        Debug.Log("Planted!");
    }

    public bool isPlanted()
    {
        return planted;
    }
}
