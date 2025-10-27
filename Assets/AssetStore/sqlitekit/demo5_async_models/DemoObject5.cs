
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Threading;
using System.Diagnostics;
using SQLiteExtension;
using System.Linq;
using System.Collections.Generic;

public class DemoObject5 : MonoBehaviour {


	private string log;
    
	IEnumerator Start () {
		yield return SelectScoreByLevel();

    }
    
    IEnumerator InsertNewScore()
    {
		Demo5ScoreModel scoreModel = new Demo5ScoreModel();
		scoreModel.score = Time.deltaTime;
		scoreModel.name = "something";
        scoreModel.level = "level1";

        yield return Demo5DB.Instance.InsertScore(scoreModel,
            (Demo5ScoreModel score) =>
            {
				log += "\n The new Score {id=" + score.id + ", name=" + score.name + ", level=" + score.level + ", score=" + score.score + " }";
            }
        );
    }


    IEnumerator SelectScoreByLevel()
    {
        yield return Demo5DB.Instance.SelectScoreByLevel("level1",
            (List<Demo5ScoreModel> scores) =>
            {
                foreach (Demo5ScoreModel score in scores)
                {
                    log += "\n Score {id=" + score.id + ", name=" + score.name + ", level=" + score.level + ", score=" + score.score + " }";
                }
            }
        );
    }

	
	void OnGUI()
	{

        if ( GUI.Button(new Rect (10,10,150,50), "Insert new score") ) 
		{
            StartCoroutine(InsertNewScore());
        }

		if ( GUI.Button(new Rect (10,70,150,70), "Select all scores") ) 
		{
			StartCoroutine(SelectScoreByLevel());
		}

        GUI.Label(new Rect(10, 150, 600, 600), log);
    }
	
	
}
