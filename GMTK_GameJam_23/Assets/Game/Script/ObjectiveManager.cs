using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;

public class ObjectiveManager : MonoBehaviour
{
	public GoToLevelEntryPoint levelGoal;

	[SerializeField]
	private int scoreRequired;

	private int curScore = -1;

	public int RemainingEnemeies => scoreRequired - Mathf.Max(curScore);


	private bool isExitOpen = false;

	private void Start()
	{
		//DisallowExit();
		// Set score to zero on level start
		CorgiEnginePointsEvent.Trigger(PointsMethods.Set, 0);
	}

	private void Update()
	{
		int updatedScore = GameManager.Instance.Points;
		if (updatedScore != curScore)
		{
			curScore = updatedScore;
			levelGoal.RequiresButtonActivationAbility = curScore < scoreRequired;
		}
	}



	/*
	// This is cheating, but works. I'm changing one of the components on the goal to make it register or not
	private void AllowExit()
	{
		levelGoal.RequiresButtonActivationAbility = false;
	}

	private void DisallowExit()
	{
		levelGoal.RequiresButtonActivationAbility = true;
	}

	public void InformOfDefeatedEnemy()
	{
		remainingEnemies--;
		if (remainingEnemies <= 0)
		{
			AllowExit();
		}
		else
		{
			DisallowExit();
		}
	}

	public void ResetDefeatedEnemies()
	{
		remainingEnemies = 
	}
	*/
}
