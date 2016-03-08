using System;
using UnityEngine;

public class TimerScoreAdapter : Adapter, ITimerScoreAdapter
{
	public TextMesh textMeshScore { get; set; }	
	public TextMesh textMeshHiScore { get; set; }	
	public ITimerScoreSound timerScoreSound { get; set;}

	void Awake()
	{
	}

	void Start(){
		this.GetComponentsInChildrenView ();
		this.GetAudioSource ();
		base.IsInitialize = true; 
	}

	public override void OnLoadCoroutine ()
	{
		
	}
		
	private void GetAudioSource ()
	{
		var audioSource = this.GetComponent<AudioSource> ();
		this.timerScoreSound = TimerScoreSound.Create (audioSource);
	}

	private void GetComponentsInChildrenView ()
	{
		var listTextMesh = this.GetComponentsInChildren<TextMesh> ();
		this.textMeshScore = listTextMesh [1];
		this.textMeshHiScore = listTextMesh [0];
	}
		
			
}