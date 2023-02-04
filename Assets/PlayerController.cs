using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float rotationSpeed = 100f;
    public float speed = 20;
    public float speedLimit = 1;
    public float burstMultiplier;


    float doubleTapThreshold = 0.4f;
    int LCount = 0;
    float LCool = 0.4f;
    int RCount = 0;
    float RCool = 0.4f;
    int UCount = 0;
    float UCool = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(transform.up * speed);

        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (UCool > 0 && UCount == 1/*Number of Taps you want Minus One*/)
            {
                Debug.Log("Double Tapped U");
                rb.AddForce(transform.up * speed * burstMultiplier);
            }
            else
            {
                UCool = doubleTapThreshold;
                UCount += 1;
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, 0, 1), rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (LCool > 0 && LCount == 1/*Number of Taps you want Minus One*/)
            {
                Debug.Log("Double Tapped L");
                rb.AddForce(transform.right * speed * burstMultiplier * -1);
            }
            else
            {
                LCool = doubleTapThreshold;
                LCount += 1;
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 0, 1), -rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            if (RCool > 0 && RCount == 1/*Number of Taps you want Minus One*/)
            {
                Debug.Log("Double Tapped R");
                rb.AddForce(transform.right * speed * burstMultiplier);
            }
            else
            {
                RCool = doubleTapThreshold;
                RCount += 1;
            }
        }


        if (rb.velocity.magnitude > speedLimit)
        {
            float multiplier = speedLimit / rb.velocity.magnitude;
            rb.velocity = rb.velocity * multiplier;
        }
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.Rotate(new Vector3(0, 0, 1), -rotationSpeed * Time.deltaTime);
        //}





        if (UCool > 0)
        {

            UCool -= 1 * Time.deltaTime;

        }
        else
        {
            UCount = 0;
        }
        if (LCool > 0) 
        {

            LCool -= 1 * Time.deltaTime;

        }
        else
        {
            LCount = 0;
        }

        if (RCool > 0)
        {

            RCool -= 1 * Time.deltaTime;

        }
        else
        {
            RCount = 0;
        }

    }
}
