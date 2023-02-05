using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLine : MonoBehaviour
{
    public RootMove line;
    public GameObject rangeIndicator;
    [SerializeField] AudioSource plantSound;
    float timer;
    public float range = 10;
    public float timeToPlant = 1;
    public LineManager lm;
    public Rigidbody2D rb;

    private void Update()
    {
        Collider2D planet = Physics2D.OverlapCircle(transform.position, range, LayerMask.GetMask("Objects"));
        /*if(planet)
        {
            Debug.Log("in range");
        }
        if (line)
        {
            Debug.Log("tethered");
        }*/
        if (Input.GetKeyDown(KeyCode.Space) && planet)
        {
            timer = Time.time;
            rb.velocity = Vector2.zero;
            //plantSound.Play();
            //line.end = planet.gameObject;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            if (!plantSound.isPlaying && planet)
                plantSound.Play();

            if (Time.time - timer > timeToPlant)
            {
                Debug.Log(Time.time - timer);
                //by making it positive inf, we won't subsequently run this code by accident,
                //since X - +inf = -inf, which is always less than holdDur
                timer = float.PositiveInfinity;

                
                //perform your action
                //if tethered
                if (line || planet.CompareTag("Home"))
                {
                    line.end = planet.gameObject;
                    lm.newLine(planet.gameObject, this.gameObject);
                    planet.GetComponent<Planet>().Plant();
                }
                else if(planet.GetComponent<Planet>().isPlanted())
                {
                    lm.newLine(planet.gameObject, this.gameObject);
                }
            }
        }
        else
        {
            timer = float.PositiveInfinity;
            plantSound.Stop();
        }
        if(Input.GetKeyDown(KeyCode.J))
            BreakLine();
    }

    public void BreakLine()
    {
        Destroy(line.gameObject);
    }
}
