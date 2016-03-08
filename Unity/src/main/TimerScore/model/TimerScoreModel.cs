using UnityEngine;
using System.Collections;
using System;

public class TimerScoreModel : Model, ITimerScoreModel 
{
	private ITimerScoreService timerScoreService;

	public event EventHandler RecalculateHi;
	public event EventHandler Recalculate;
	public event EventHandler SoundPlay;
	public event EventHandler StopCoroutine;
	public event EventHandler InitCoroutine;

	public static IModel Create (IService fpsService){
		return new TimerScoreModel (fpsService);
	}
		
	TimerScoreModel(IService service) : base(service)
	{
		timerScoreService =(ITimerScoreService)service;

	//	timerScoreService.InitCoroutineUpdate += (sender, e) => Debug.Log ("OnInitCoroutine " +sender.ToString ());
		timerScoreService.InitCoroutineUpdate += (sender, e) => {
			if (InitCoroutine != null)
				InitCoroutine (this, EventArgs.Empty);
		};
						
		//timerScoreService.RecalculateScore += (sender, e) => Debug.Log ("OnGUIScore " +sender.ToString ());
		timerScoreService.RecalculateScore += (sender, e) => {
			if (Recalculate != null)
				Recalculate (this, EventArgs.Empty);
		};

	//	timerScoreService.RecalculateHi += (sender, e) => Debug.Log ("OnGUIHiScore " +sender.ToString ());;
		timerScoreService.RecalculateHi += (sender, e) =>{
			if (RecalculateHi != null)
				RecalculateHi(this, EventArgs.Empty);
		};

	//	timerScoreService.SoundPlay += (sender, e) => Debug.Log ("OnSoundPlay " +sender.ToString ());;
		timerScoreService.SoundPlay += (sender, e) => {
			if (SoundPlay != null)
				SoundPlay(this, EventArgs.Empty);
		};

	//	timerScoreService.StopCoroutineUpdate += (sender, e) => Debug.Log ("OnStopCoroutine " +sender.ToString ());;
		timerScoreService.StopCoroutineUpdate += (sender, e) => {
			if (StopCoroutine != null)
				StopCoroutine(this, EventArgs.Empty);
		};
	}
		

	public override IEnumerator ServiceAsync() {
		return this.service.Async(); 
	}
		
	public int hiScore { 
		get {  return this.timerScoreService.hiScore; }
		set {  this.timerScoreService.hiScore = value; }
	}

	public bool isStopCoroutine { 
		get {  return this.timerScoreService.isStopCoroutine; }
		set { this.timerScoreService.isStopCoroutine = value;}
	}

	public bool playSound { 
		get {  return this.timerScoreService.playSound; }
		set { this.timerScoreService.playSound = value;}
	}

	public int score { 
		get {  return this.timerScoreService.score; }
		set { this.timerScoreService.score = value;}

	}

}
