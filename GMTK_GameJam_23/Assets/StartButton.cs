using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;
using TMPro;

public class StartButton : MonoBehaviour
{
	[SerializeField]
	private GoToLevelEntryPoint goToLevelEntryPoint;

	[SerializeField]
	private AudioSource audioSource;

	public TextMeshProUGUI textMesh; 

	bool hasBeenClicked;

	public void OnButtonClick()
	{
		if (!hasBeenClicked)
		{
			audioSource.loop = false;
			audioSource.Play();
			hasBeenClicked = true;
		}
	}

	private void Update()
	{
		if (hasBeenClicked)
		{
			textMesh.enabled = Mathf.FloorToInt(Time.realtimeSinceStartup * 4) % 2 == 1;
		}
		if(hasBeenClicked && !audioSource.isPlaying)
		{
			goToLevelEntryPoint.GoToNextLevel();
		}
	}
}
