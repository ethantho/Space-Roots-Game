using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public List<Score> sd;

    public IEnumerable<Score> GetHighScores()
    {
        return sd.OrderByDescending(x => x.score);
    }

    public void AddScore(Score score)
	{
        sd.Add(score);
	}
}
