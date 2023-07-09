using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;

public class StartButton : MonoBehaviour
{
	[SerializeField]
	private GoToLevelEntryPoint goToLevelEntryPoint;

	public void OnButtonClick()
	{
		goToLevelEntryPoint.GoToNextLevel();
	}
}
