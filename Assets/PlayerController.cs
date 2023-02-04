using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public Bullet bulletPrefab;
    public Booster rightBoost;
    public Booster leftBoost;
    public Booster backBoost;
    public SpriteRenderer Exhaust;
    public float rotationSpeed = 100f;
    public float speed = 20;
    public float speedLimit = 1;
    public float burstMultiplier;


    float doubleTapThreshold = 0.3f;
    int LCount;
    float LCool;
    int RCount;
    float RCool;
    int UCount;
    float UCool;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        LCount = 0;
        LCool = doubleTapThreshold;
        RCount = 0;
        RCool = doubleTapThreshold;
        UCount = 0;
        UCool = doubleTapThreshold;
    }

    // Update is called once per frame
    void Update()
    {
        doBasicMovement();


        doBurstMovement();


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.creator = gameObject;
            bullet.rigidbody.velocity = rb.velocity;
            bullet.Project(transform.up * 5);
            
        }
    }

    private void FixedUpdate()
    {
        doRotation();
    }

    void doRotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, 0, 1), rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 0, 1), -rotationSpeed * Time.deltaTime);
        }
    }
    void doBasicMovement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(transform.up * speed);
            Exhaust.enabled = true;

        }
        else
        {
            Exhaust.enabled = false;
        }

        

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.drag = 0.75f;
        }
        else
        {
            rb.drag = 0;
        }
    }

    void doBurstMovement()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (UCool > 0 && UCount == 1/*Number of Taps you want Minus One*/)
            {
                Debug.Log("Double Tapped U");
                rb.AddForce(transform.up * speed * burstMultiplier);
                backBoost.Boost();
            }
            else
            {
                UCool = doubleTapThreshold;
                UCount += 1;
            }
        }



        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (LCool > 0 && LCount == 1/*Number of Taps you want Minus One*/)
            {
                Debug.Log("Double Tapped L");
                rb.AddForce(transform.right * speed * burstMultiplier * -1);
                rightBoost.Boost();
            }
            else
            {
                LCool = doubleTapThreshold;
                LCount += 1;
            }
        }



        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            if (RCool > 0 && RCount == 1/*Number of Taps you want Minus One*/)
            {
                Debug.Log("Double Tapped R");
                rb.AddForce(transform.right * speed * burstMultiplier);
                leftBoost.Boost();
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
