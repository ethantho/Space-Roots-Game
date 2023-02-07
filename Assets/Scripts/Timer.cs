using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float currentTime = 0f;
    [SerializeField] TextMeshProUGUI text;
    public bool stop;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0f;
        stop = false;
        //text = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            currentTime += Time.deltaTime;
            text.text = currentTime.ToString("0.0000");
            PlayerPrefs.SetFloat("score", currentTime);
        }
        
    }
}
