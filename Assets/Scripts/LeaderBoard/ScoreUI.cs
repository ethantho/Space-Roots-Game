using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUi : MonoBehaviour
{
    public RowUI rowui;
    public ScoreManager sm;

	private void Start()
	{
		var scores = sm.GetHighScores().ToArray();
		for (int i = 0; i < scores.Length; ++i)
		{
			var row = Instantiate(rowui, transform).GetComponent<RowUI>();
			row.uname.text = scores[i].uname;
			row.score.text = scores[i].score.ToString();
		}
	}
}
