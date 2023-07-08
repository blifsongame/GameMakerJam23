using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyShowInCertainMode : MonoBehaviour
{
    [SerializeField]
    private PlayModeManager.PlayModeState[] showStates;
	
	[SerializeField]
	private GameObject visualRoot;

	[SerializeField]
	private PlayModeManager manager = null;

	private void Start()
	{
		if (manager == null)
		{
			manager = FindObjectOfType<PlayModeManager>();
		}
	}


	private void OnEnable()
	{
		manager.OnPlayModeChanged += UpdateBasedOnState;
		UpdateBasedOnState();
	}

	private void OnDisable()
	{
		manager.OnPlayModeChanged -= UpdateBasedOnState;
		UpdateBasedOnState();
	}

	private void UpdateBasedOnState()
	{
		visualRoot.SetActive(IsInGoodState(manager.playmode));
	}

	private void UpdateBasedOnState(PlayModeManager.PlayModeState state)
	{
		visualRoot.SetActive(IsInGoodState(state));
	}

	private bool IsInGoodState(PlayModeManager.PlayModeState state)
	{
		for(int i = 0; i < showStates.Length; i++)
		{
			if (showStates[i] == state)
			{
				return true;
			}
		}
		return false;
	}
}
