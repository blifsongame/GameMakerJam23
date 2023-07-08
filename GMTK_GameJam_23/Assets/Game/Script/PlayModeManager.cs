using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayModeManager : MonoBehaviour
{
    public enum PlayMode
	{
		None,
		BuildMode,
		PlayMode
	}

	// TODO: See if we need to consider pause menu
	public PlayMode playmode { get; private set; } = PlayMode.BuildMode;

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

	private void OnDestroy()
	{
		if (instance == this)
		{
			instance = null;
		}
	}
}
