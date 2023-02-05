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

    public RootMove newLine(GameObject newhome, GameObject newend)
    {
        RootMove temp = Instantiate(linePrefab).GetComponent<RootMove>();
        temp.start = newhome;
        temp.end = newend;
        player.GetComponent<PlayerLine>().line = temp;
        return temp;
    }
}
