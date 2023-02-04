using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLine : MonoBehaviour
{
    public RootMove line;
    public GameObject rangeIndicator;
    float timer;
    public float range = 10;
    public float timeToPlant = 1;
    public LineManager lm;

    private void Update()
    {
        Collider2D planet = Physics2D.OverlapCircle(transform.position, range, LayerMask.GetMask("Objects"));
        if(planet)
        {
            Debug.Log("in range");
        }
        if (Input.GetKeyDown(KeyCode.Space) && planet)
        {
            timer = Time.time;
            //line.end = planet.gameObject;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            if (Time.time - timer > timeToPlant)
            {
                Debug.Log(Time.time - timer);
                //by making it positive inf, we won't subsequently run this code by accident,
                //since X - +inf = -inf, which is always less than holdDur
                timer = float.PositiveInfinity;


                //perform your action
                line.end = planet.gameObject;
                lm.newLine(planet.gameObject, this.gameObject);
            }
        }
        else
        {
            timer = float.PositiveInfinity;
        }
    }
}
