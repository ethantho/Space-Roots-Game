using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public RectTransform sr;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<RectTransform>();
        speed = Random.Range(0.8f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        sr.transform.Rotate(new Vector3(0, 0, speed));
    }
}
