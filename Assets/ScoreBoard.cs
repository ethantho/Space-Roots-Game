using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    public int totalPlanets;
    public int planetsClaimed = 0;
    // Start is called before the first frame update
    void Start()
    {
        planetsClaimed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(planetsClaimed == totalPlanets)
        {
            Win();
        }
    }

    void Win()
    {
        Debug.Log("Omedetou");
    }

    public void Score()
    {
        planetsClaimed++;
    }
}
