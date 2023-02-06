using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Results : MonoBehaviour
{
    ScoreBoard sb;
    float finalTime;
    [SerializeField] TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        sb = (ScoreBoard)FindObjectOfType(typeof(ScoreBoard));
        finalTime = sb.t.currentTime;
        text.text = finalTime.ToString("0.0000");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
