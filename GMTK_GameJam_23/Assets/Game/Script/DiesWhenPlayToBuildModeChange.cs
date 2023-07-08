using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;

public class DiesWhenPlayToBuildModeChange : MMMonoBehaviour
{
    // Bad way to do this, but whatever. Quick

    private PlayModeManager.PlayModeState previousState = PlayModeManager.PlayModeState.None;

	private Health _health;

	private void Awake()
	{
		_health = GetComponent<Health>();
	}

	private void Update()
	{
		var curState = PlayModeManager.Instance.playmode;
		if (curState != previousState)
		{
			if (previousState == PlayModeManager.PlayModeState.PlayMode && curState == PlayModeManager.PlayModeState.BuildMode)
			{
				_health.Kill();
			}
			previousState = curState;
		}
	}
}
