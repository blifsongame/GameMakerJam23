using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;

public class FreezeBasedOnConditions : MMMonoBehaviour
{


	[Tooltip("If frozen when the button hold button is down")]
	public bool FreezeIfStopInput;

	/// The input that returns true if currently downn
	[Tooltip("The name of the tested input")]
	public string InputName = "Stop_Movement";

	[Tooltip("If should freeze if not in Play mode")]
	public bool FreezeIfNotInPlayMode;

	private Character _character;
	private CorgiController _controller;

	private bool isFrozen;

	private bool IsFrozen
	{
		get => isFrozen;
		set
		{
			if (isFrozen != value)
			{
				isFrozen = value;
				Debug.Log($"Freeze = {isFrozen}");
				if (isFrozen)
				{
					_character.Freeze();
				}
				else
				{
					_character.UnFreeze();
				}
			}
		}
	}

	private void Awake()
	{
		_character = GetComponent<Character>();
		_controller = GetComponent<CorgiController>();
	}

	private void Update()
	{
		if (FreezeIfStopInput  && Mathf.Abs(Input.GetAxis(InputName)) > float.Epsilon && _controller.State.IsGrounded)
		{
			IsFrozen = true;
		}
		else if (FreezeIfNotInPlayMode && PlayModeManager.Instance.playmode != PlayModeManager.PlayModeState.PlayMode)
		{
			IsFrozen = true;
		}

		IsFrozen = false;
	}
}
