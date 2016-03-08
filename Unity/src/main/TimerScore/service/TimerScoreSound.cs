using System;
using UnityEngine;

public class TimerScoreSound : ITimerScoreSound
{
	private AudioSource audioSource;

	public static ITimerScoreSound Create (AudioSource audioSource)
	{
		return new TimerScoreSound(audioSource);
	}

	public TimerScoreSound (AudioSource audioSource)
	{
		this.audioSource = audioSource;
	}

	public void CheckPoint(){
		this.audioSource.Play ();
	}

}


