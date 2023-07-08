using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayModeManager : MonoBehaviour
{
    public enum PlayModeState
	{
		None,
		BuildMode,
		PlayMode
	}

	// TODO: See if we need to consider pause menu
	public PlayModeState playmode { get; private set; } = PlayModeState.BuildMode;

	private static PlayModeManager instance;
	public static PlayModeManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType<PlayModeManager>();
			}
			return instance;
		}
	}

	public System.Action<PlayModeState> OnPlayModeChanged;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
	}
	private void Start()
	{
		// Is this what we want?
		SetPlayMode(PlayModeState.BuildMode);
	}

	private void OnDestroy()
	{
		if (instance == this)
		{
			instance = null;
		}
	}

	public void TogglePlayMode()
	{
		if (playmode == PlayModeState.BuildMode)
		{
			SetPlayMode(PlayModeState.PlayMode);
		}
		else if (playmode == PlayModeState.PlayMode)
		{
			SetPlayMode(PlayModeState.BuildMode);
		}
	}

	private void SetPlayMode(PlayModeState playmode)
	{
		this.playmode = playmode;
		OnPlayModeChanged?.Invoke(this.playmode);
	}
}
