using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.CorgiEngine;

public class PlayModeManager : MonoBehaviour, MMEventListener<CorgiEngineEvent>
{ 
    public enum PlayModeState
	{
		None,
		BuildMode,
		PlayMode,
		Victory
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

	public void SetVictory()
	{
		SetPlayMode(PlayModeState.Victory);
	}
	
	public virtual void OnMMEvent(CorgiEngineEvent corgiEngineEvent)
	{
		switch (corgiEngineEvent.EventType)
		{
			case CorgiEngineEventTypes.LevelComplete:
			case CorgiEngineEventTypes.LevelEnd:
				SetPlayMode(PlayModeState.Victory);
				break;
			case CorgiEngineEventTypes.LevelStart:
				if (playmode == PlayModeState.Victory)
				{
					SetPlayMode(PlayModeState.BuildMode);
				}
				break;
		}
	}
	
}
