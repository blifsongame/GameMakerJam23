using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class AdviceMsg : MonoBehaviour
{
	public TextMeshProUGUI textMesh;
	//private PlayModeManager playModeManager;

	private PlayModeManager.PlayModeState state = PlayModeManager.PlayModeState.None;

	private void Update()
	{
		if (PlayModeManager.Instance)
		{
			if (PlayModeManager.Instance.playmode != state)
			{
				state = PlayModeManager.Instance.playmode;
				if (state == PlayModeManager.PlayModeState.BuildMode)
				{
					textMesh.text = "L-Click to Place\nR-Click to Remove";
				}
				else if (state == PlayModeManager.PlayModeState.PlayMode)
				{
					textMesh.text = "L-Shift to Stop";
				}
			}
		}
	}
}
