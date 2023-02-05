using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FuelBar : MonoBehaviour
{
	private static float fuel = 100.0f;
	public static int planetsRemaining = 9;
	public RectTransform rectTransform;
	public TextMeshProUGUI planetsRemainingTxt;

	public float deathTimer = 3f;
	public static float getFuel()
	{
		return fuel;
	}
	
	public static void depleteFuel(float amount)
	{
		fuel -= amount;
	}
	
	public static void replenishFuel(float amount)
	{
		fuel += amount;
	}
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		float width = 480;
		float height = 80;
		
		width *= fuel/100.0f;
		rectTransform.sizeDelta = new Vector2(width, height);
		//planetsRemainingTxt.text = "PLANETS REMAINING: " + planetsRemaining;
		if(fuel > 100.0f)
		{
			fuel = 100.0f;
		}
		
		if(fuel <= 0.0f)
		{
			fuel = 0.0f;

			deathTimer -= Time.deltaTime;

		}

		if(deathTimer <= 0f)
        {
			Debug.Log("You died");
			SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
		}
    }
}
