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
	

	private PlayModeManager.PlayModeState playmode = PlayModeManager.PlayModeState.None;

	private void Start()
	{
		playModeAudioSource.mute = true;
		buildModeAudioSource.mute = true;
	}

	private void OnEnable()
	{
		playModeManager.OnPlayModeChanged += UpdateMusic;
		UpdateMusic(playModeManager.playmode);
	}

	// This is a cheat way to do it, but fast

	/*
	public void PlayBuildModeAudio()
	{
		int timesamples = audioSource.timeSamples;
		audioSource.Stop();
		audioSource.clip = buildModeAudioClip;
		audioSource.timeSamples = timesamples;
		audioSource.Play();
		
	}

	public void PlayPlayModeAudio() // Bad name, but whatever
	{
		int timesamples = audioSource.timeSamples;
		audioSource.Stop();
		audioSource.clip = playModeAudioClip;
		audioSource.timeSamples = timesamples;
		audioSource.Play();
	}
	*/

	private void PlayBuildModeAudio()
	{
		playModeAudioSource.mute = true;
		buildModeAudioSource.mute = false;
	}

	private void PlayPlayModeAudio() // Bad name. Oh well
	{
		playModeAudioSource.mute = false;
		buildModeAudioSource.mute = true;
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
