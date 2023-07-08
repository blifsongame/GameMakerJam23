using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.CorgiEngine;

public class ObjectiveManager : MonoBehaviour
{
	public GoToLevelEntryPoint levelGoal;
	private SpriteRenderer levelGoalSprite; 

	[SerializeField]
	private int scoreRequired;

	private int curScore = -1;

	public int RemainingEnemeies => scoreRequired - Mathf.Max(curScore);


	private bool isExitOpen = false;
	private bool first = true;

	private void Start()
	{
		//DisallowExit();
		// Set score to zero on level start
		levelGoalSprite = levelGoal.GetComponent<SpriteRenderer>();
		CorgiEnginePointsEvent.Trigger(PointsMethods.Set, 0);
	}

	private void Update()
	{
		int updatedScore = GameManager.Instance.Points;
		if (updatedScore != curScore || first)
		{
			first = false;
			curScore = updatedScore;
			isExitOpen = curScore >= scoreRequired;
			levelGoal.RequiresButtonActivationAbility = !isExitOpen;
			if (isExitOpen)
			{
				levelGoalSprite.color = new Color32(255, 255, 255, 255);
			}
			else
			{
				levelGoalSprite.color = new Color32(200, 200, 255, 180);
			}
		}
	}



	
}
