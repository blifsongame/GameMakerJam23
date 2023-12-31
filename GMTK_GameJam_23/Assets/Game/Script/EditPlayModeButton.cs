using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EditPlayModeButton : MonoBehaviour
{
	private PlayModeManager playModeManager;

	[SerializeField]
	private TextMeshProUGUI buttonText;

	[SerializeField]
	private Color buildModeColor;

	[SerializeField]
	private Color playModeColor;

	private void Start()
	{
		if (playModeManager == null)
		playModeManager = PlayModeManager.Instance;
	}

	private void OnEnable()
	{
		// Race condition? Silly
		if (playModeManager == null)
		{
			playModeManager = PlayModeManager.Instance;
		}
		UpdateButtonText();
		playModeManager.OnPlayModeChanged += UpdateButtonText;
	}

	private void OnDisable()
	{
		if (playModeManager)
		{
			playModeManager.OnPlayModeChanged -= UpdateButtonText;
		}
	}

	public void OnButtonClicked()
	{
		if (playModeManager.playmode != PlayModeManager.PlayModeState.Victory)
		{
			playModeManager.TogglePlayMode();
		}
	}

	private void UpdateButtonText()
	{
		UpdateButtonText(playModeManager.playmode);
	}

	private void UpdateButtonText(PlayModeManager.PlayModeState state)
	{
		switch(state)
		{
			case PlayModeManager.PlayModeState.BuildMode:
				buttonText.text = "BUILD MODE";
				buttonText.color = buildModeColor;
				break;
			case PlayModeManager.PlayModeState.PlayMode:
				buttonText.text = "PLAY MODE";
				buttonText.color = playModeColor;
				break;
		}
	}
}
