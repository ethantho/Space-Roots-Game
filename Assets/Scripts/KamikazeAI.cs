using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class KamikazeAI : MonoBehaviour
{
    Rigidbody2D rb;
    CircleCollider2D col;
    public Transform target;
    public float leadMultiplier;
    public float speed;
    public float speedLimit;
    public float rotDif;

    public bool aggroed;
    public float innerAggroDist;
    public float outerAggroDist;

    public float rotationStrength;
    public float maxAngleForBoost;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(target.transform.position, transform.position);
        if(!aggroed && dist < innerAggroDist)
        {
            aggroed = true;
        }

        if (aggroed && dist > outerAggroDist)
        {
            aggroed = false;
        }
        if (target != null && aggroed)
        {
            Vector3 targ = target.position; //+ (new Vector3(target.gameObject.GetComponent<Rigidbody2D>().velocity.x, target.gameObject.GetComponent<Rigidbody2D>().velocity.y, 0) * leadMultiplier);
            targ.z = 0f;
            Vector3 objectPos = transform.position;
            targ.x = targ.x - objectPos.x;
            targ.y = targ.y - objectPos.y;

            float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg - 90;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
            float str = Mathf.Min(rotationStrength * Time.deltaTime, 1);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, str);


            rotDif = Quaternion.Angle(transform.rotation, targetRotation);
            //transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, Time.deltaTime / scalingFactor);

            if (Mathf.Abs(rotDif) < maxAngleForBoost)
                rb.AddForce(transform.up * speed);

            if (rb.velocity.magnitude > speedLimit)
            {
                float multiplier = speedLimit / rb.velocity.magnitude;
                rb.velocity = rb.velocity * multiplier;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}