using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    public int totalPlanets;
    public int planetsClaimed = 0;
    public Timer t;
    [SerializeField] WorldGeneration wg;

    [SerializeField] AudioSource synths;
    [SerializeField] AudioSource flute;
    [SerializeField] AudioSource ePianoVibraphone;
    [SerializeField] AudioSource congasShaker;
    [SerializeField] AudioSource bass;
    public AudioSource drumset;


    // Start is called before the first frame update
    void Start()
    {
        planetsClaimed = 0;
        synths.Play();
        flute.Play();
        ePianoVibraphone.Play();
        congasShaker.Play();
        bass.Play();
        drumset.Play();

        flute.mute = true;
        ePianoVibraphone.mute = true;
        congasShaker.mute = true;
        bass.mute = true;
        drumset.mute = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(planetsClaimed == totalPlanets)
        {
            Win();
        }

        if(planetsClaimed >= 1)
        {
            flute.mute = false;
        }

        if ((float) planetsClaimed / totalPlanets >= 0.25)
        {
            ePianoVibraphone.mute = false;
        }

        if ((float)planetsClaimed / totalPlanets >= 0.5)
        {
            bass.mute = false;
        }

        if ((float)planetsClaimed / totalPlanets >= 0.75)
        {
            congasShaker.mute = false;
        }




    }

    void Win()
    {
        Debug.Log("Omedetou");
        t.stop = true;
    }

    public void Score()
    {
        planetsClaimed++;
        wg.SpawnEnemies((float)planetsClaimed / totalPlanets / 2);

    }



}
