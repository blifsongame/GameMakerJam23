using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour
{
	[SerializeField]
	private PlayModeManager playModeManager;

	public AudioSource playModeAudioSource;
	public AudioSource buildModeAudioSource;
	public AudioSource otherAudioSource;
	public AudioClip victoryTheme;

	private PlayModeManager.PlayModeState playmode = PlayModeManager.PlayModeState.None;

	private void Awake()
	{
		if (otherAudioSource == null)
			otherAudioSource = GetComponent<AudioSource>();
	}
	private void Start()
	{
		playModeAudioSource.mute = true;
		buildModeAudioSource.mute = false;
	}

	private void OnEnable()
	{
		playModeManager.OnPlayModeChanged += UpdateMusic;
		UpdateMusic(playModeManager.playmode);
	}

	private void OnDisable()
	{
		playModeManager.OnPlayModeChanged -= UpdateMusic;
	}

	private void PlayBuildModeAudio()
	{
		if (!playModeAudioSource.isPlaying)
		{
			playModeAudioSource.Play();
		}
		playModeAudioSource.mute = true;

		
		if (!buildModeAudioSource.isPlaying)
		{
			buildModeAudioSource.Play();
		}
		buildModeAudioSource.mute = false;

		if (otherAudioSource.isPlaying)
		{
			otherAudioSource.Stop();
		}
	}

	private void PlayPlayModeAudio() // Bad name. Oh well
	{
		if (!playModeAudioSource.isPlaying)
		{
			playModeAudioSource.Play();
		}
		playModeAudioSource.mute = false;

		
		if (!buildModeAudioSource.isPlaying)
		{
			buildModeAudioSource.Play();
		}
		buildModeAudioSource.mute = true;

		if (otherAudioSource.isPlaying)
		{
			otherAudioSource.Stop();
		}
	}

	public void PlayVictoryMusic()
	{
		buildModeAudioSource.Stop();
		playModeAudioSource.Stop();
		otherAudioSource.loop = false;
		otherAudioSource.PlayOneShot(victoryTheme);
	}

	private void UpdateMusic(PlayModeManager.PlayModeState playmode)
	{
		if (this.playmode != playmode)
		{
			this.playmode = playmode;
			if (playmode == PlayModeManager.PlayModeState.BuildMode)
			{
				PlayBuildModeAudio();
			}
			else if (playmode == PlayModeManager.PlayModeState.PlayMode)
			{
				PlayPlayModeAudio();
			}
		}
	}
}
