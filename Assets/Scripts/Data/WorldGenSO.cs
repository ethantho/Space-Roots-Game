using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WorldGenParameters_", menuName = "Data/WorldGenData")]
public class WorldGenSO : ScriptableObject
{
    [SerializeField]
    public Sprite bg;
        
    [SerializeField]
    public int planets = 9;
}
