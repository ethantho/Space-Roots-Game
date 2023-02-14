

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] TextMeshProUGUI distanceWarning;
    [SerializeField] AudioSource boostSound;
    [SerializeField] AudioSource forwardSound;
    public Bullet bulletPrefab;
    public Booster rightBoost;
    public Booster leftBoost;
    public Booster backBoost;
    public Booster frontBoost;
    public SpriteRenderer Exhaust;
    public SpriteRenderer sr;
    public float rotationSpeed = 100f;
    public float speed = 20;
    public float speedLimit = 1;
    public float burstMultiplier;
    public Sprite otis;
    public Sprite chungus;
    PlayerLine pl;


    float doubleTapThreshold = 0.3f;
    int LCount;
    float LCool;
    int RCount;
    float RCool;
    int UCount;
    float UCool;
    int DCount;
    float DCool;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        pl = GetComponent<PlayerLine>();

        sr.sprite = otis;

        LCount = 0;
        LCool = doubleTapThreshold;
        RCount = 0;
        RCool = doubleTapThreshold;
        UCount = 0;
        UCool = doubleTapThreshold;
        DCount = 0;
        DCool = doubleTapThreshold;

        forwardSound.mute = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (FuelBar.getFuel() > 0)
        {
            doBasicMovement();


            doBurstMovement();
        }


        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.creator = gameObject;
            bullet.rigidbody.velocity = rb.velocity;
            bullet.Project(transform.up * 5);

        }*/

        if(this.GetComponent<PlayerLine>().line)
        {
            FuelBar.depleteFuel(-0.03f);
        }

        if (Vector3.Distance(transform.position, new Vector3(0f, 0f, 0f)) > 120)
        {
            distanceWarning.enabled = true;
        }
        else
        {
            distanceWarning.enabled = false;
        }
    }

    private void FixedUpdate()
    {
        doRotation();
    }

    void doRotation()
    {
        if (FuelBar.getFuel() > 0)
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
    }
    void doBasicMovement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(transform.up * speed);
            FuelBar.depleteFuel(0.01f);
            Exhaust.enabled = true;
            forwardSound.mute = false;

        }
        else
        {
            Exhaust.enabled = false;
            forwardSound.mute = true;
        }



        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.drag = 2f;
        }
        else
        {
            rb.drag = 0;
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("World");
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
                FuelBar.depleteFuel(3f);
                boostSound.Play();
            }
            else
            {
                UCool = doubleTapThreshold;
                UCount += 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (DCool > 0 && DCount == 1/*Number of Taps you want Minus One*/)
            {
                Debug.Log("Double Tapped D");
                rb.AddForce(transform.up * speed * burstMultiplier * -1);
                frontBoost.Boost();
                FuelBar.depleteFuel(3f);
                boostSound.Play();
            }
            else
            {
                DCool = doubleTapThreshold;
                DCount += 1;
            }
        }



        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (LCool > 0 && LCount == 1/*Number of Taps you want Minus One*/)
            {
                Debug.Log("Double Tapped L");
                rb.AddForce(transform.right * speed * burstMultiplier * -1);
                rightBoost.Boost();
                FuelBar.depleteFuel(3f);
                boostSound.Play();
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
                FuelBar.depleteFuel(3f);
                boostSound.Play();
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

        if (DCool > 0)
        {

            DCool -= 1 * Time.deltaTime;

        }
        else
        {
            DCount = 0;
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

    void takeDamage()
    {
        if (PlayerPrefs.GetInt("Chungus") == 1)
        {
            StartCoroutine(HitEffect());
        }
        //Debug.Log("Took damage");
        FuelBar.depleteFuel(20f);
        pl.BreakLine();
        pl.plantSound.Stop();
        
    }

    private IEnumerator HitEffect()
    {
        sr.sprite = chungus;
        yield return new WaitForSeconds(0.5f);
        sr.sprite = otis;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            takeDamage();
        }

    }
}
