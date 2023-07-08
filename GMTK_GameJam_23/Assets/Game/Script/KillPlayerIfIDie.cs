using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using System;

// This is a bad name
public class KillPlayerIfIDie : MMMonoBehaviour
{
	private Health _health;
	private Character _character;

	private void Awake()
	{
		_health = GetComponent<Health>();
		_character = GetComponent<Character>();
	}

	private void OnEnable()
	{
		_health.OnDeath += KillPlayer;
	}

	private void OnDisable()
	{
		_health.OnDeath -= KillPlayer;
	}

	private void KillPlayer()
	{
		if (_character.CharacterType != Character.CharacterTypes.Player)
		{
			if(LevelManager.Instance.Players[0] != null)
			{
				LevelManager.Instance.Players[0].CharacterHealth.Kill();
			}
		}
	}
}
