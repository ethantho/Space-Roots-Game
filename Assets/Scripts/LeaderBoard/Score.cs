using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Score
{
    public string player;
    public float score;

    public Score(string name, float score)
	{
        this.player = name;
        this.score = score;
	}
}