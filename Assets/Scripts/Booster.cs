using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    float animationLength = 0.24f;
    float animCounter;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Animator>().enabled = false;
        animCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (animCounter > 0)
        {
            animCounter -= Time.deltaTime;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Animator>().enabled = false;
            animCounter = 0;
        }
    }

    public void Boost()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Animator>().enabled = true;
        animCounter = animationLength;
    }
}
