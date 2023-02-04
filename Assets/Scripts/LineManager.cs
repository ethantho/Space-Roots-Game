using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    public GameObject home;
    public GameObject player;
    public GameObject linePrefab;

    // Start is called before the first frame update
    void Start()
    {
        GameObject temp = Instantiate(linePrefab);
        temp.GetComponent<RootMove>().start = home;
        temp.GetComponent<RootMove>().end = player;
        player.GetComponent<PlayerLine>().line = temp.GetComponent<RootMove>();
    }

    public void newLine(GameObject newhome, GameObject newend)
    {
        GameObject temp = Instantiate(linePrefab);
        temp.GetComponent<RootMove>().start = newhome;
        temp.GetComponent<RootMove>().end = newend;
        player.GetComponent<PlayerLine>().line = temp.GetComponent<RootMove>();
    }
}
