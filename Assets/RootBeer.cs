using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootBeer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnTriggerEnter2D(Collider2D c2d)
    {
		FuelBar.replenishFuel(20.0f);
		if(c2d.CompareTag("Player"))
		{
			Destroy(gameObject);
		}
	}
}
