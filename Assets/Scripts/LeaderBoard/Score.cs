using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Score
{
    public string uname;
    public float score;

    public Score(string name, float score)
	{
        this.uname = name;
        this.score = score;
	}
}