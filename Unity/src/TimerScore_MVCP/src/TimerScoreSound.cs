using System;
using UnityEngine;

public class TimerScoreSound : ITimerScoreSound
{
	private AudioSource audioSource;

	public TimerScoreSound (AudioSource audioSource)
	{
		this.audioSource = audioSource;
	}

	public void CheckPoint(){
		this.audioSource.Play ();
	}

}


