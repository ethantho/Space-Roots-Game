using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    public int totalPlanets;
    public int planetsClaimed = 0;
    public Timer t;
    public SceneManager sm;
    private bool win = false;
    [SerializeField] WorldGeneration wg;

    [SerializeField] AudioSource synths;
    [SerializeField] AudioSource flute;
    [SerializeField] AudioSource ePianoVibraphone;
    [SerializeField] AudioSource congasShaker;
    [SerializeField] AudioSource bass;
    public AudioSource drumset;
    [SerializeField] TextMeshProUGUI planetText;


    // Start is called before the first frame update
    void Start()
    {
        //totalPlanets = wg.planetstoSpawn;
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
        //Debug.Log(planetsClaimed + "/" + totalPlanets);
        if(planetsClaimed >= totalPlanets)
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

        planetText.text = planetsClaimed + "/" + totalPlanets;


    }

    void Win()
    {
        Debug.Log("Omedetou");
        t.stop = true;
        if (!win)
        {
            win = true;
            SceneManager.LoadSceneAsync("WinScreen");
        }
    }

    public void Score()
    {
        planetsClaimed++;
        wg.SpawnEnemies((float)planetsClaimed / totalPlanets / 2);

    }


}
