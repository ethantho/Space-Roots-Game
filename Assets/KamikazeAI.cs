using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class KamikazeAI : MonoBehaviour
{
    Rigidbody2D rb;
    public Transform target;
    public float leadMultiplier;
    public float speed;
    public float speedLimit;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 targ = target.position + (new Vector3(target.gameObject.GetComponent<Rigidbody2D>().velocity.x, target.gameObject.GetComponent<Rigidbody2D>().velocity.y, 0) * leadMultiplier);
            targ.z = 0f;
            Vector3 objectPos = transform.position;
            targ.x = targ.x - objectPos.x;
            targ.y = targ.y - objectPos.y;

            float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));



            rb.AddForce(transform.up * speed);

            if (rb.velocity.magnitude > speedLimit)
            {
                float multiplier = speedLimit / rb.velocity.magnitude;
                rb.velocity = rb.velocity * multiplier;
            }
        }
    }
}
