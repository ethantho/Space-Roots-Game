using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{
    public TMPro.TextMeshProUGUI myScore;
    public TMPro.TextMeshProUGUI myName;
    public float currentScore;

    private void Update()
    {
        myScore.text = $"{PlayerPrefs.GetFloat("score")}";
    }

    public void SendScore()
    {
        Debug.Log(myName.text + ": " + PlayerPrefs.GetFloat("score"));
        HighScores.UploadScore(myName.text.ToUpper(), (int)(10000000 - PlayerPrefs.GetFloat("score") * 10000));
        
    }
}
