using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;

public class FreezeOnButtonHold : MMMonoBehaviour
{
	/// The input that returns true if currently downn
	[Tooltip("The name of the tested input")]
	public string InputName = "Stop_Movement";
	
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

		IsFrozen = Mathf.Abs(Input.GetAxis(InputName)) > float.Epsilon && _controller.State.IsGrounded;
	}
}
