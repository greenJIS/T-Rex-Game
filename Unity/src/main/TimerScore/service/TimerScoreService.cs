using UnityEngine;
using System.Collections;
using System;

public class TimerScoreService : Service, ITimerScoreService {

	private const int CHECK_POINT = 100;
	private const float SLEEP = 0.100f;

	private int _score;
	private int _hiScore;
	private bool _playSound;
	private bool _isStopCoroutine;

	public event EventHandler RecalculateHi;
	public event EventHandler RecalculateScore;
	public event EventHandler SoundPlay;
	public event EventHandler StopCoroutineUpdate;
	public event EventHandler InitCoroutineUpdate;


	public static IService Create(){
		return new TimerScoreService ();
	}

	TimerScoreService()
	{
		//MicroOptimizacion
		base.waitForSeconds = new WaitForSeconds(0.1f);

		this._playSound = false;
		this._score = 0;
		this._hiScore = 0;
		this._isStopCoroutine = true;
	}

	public override IEnumerator Async(){
		Debug.Log ("*************************");
		while (!this._isStopCoroutine) {
			this.score++;

			if (this._score % CHECK_POINT == 0)
				this.playSound = true;

			yield return this.waitForSeconds;
		}

		//Obligado si quiero utilizar la coroutina es otro punto que no sea la inicializacion del contexto
		yield return this.waitForSeconds;
	}
		

	public bool isStopCoroutine{ 
		get {
			return _isStopCoroutine;
		}
		set {
			_isStopCoroutine = value;
			if (_isStopCoroutine)
				this.OnStopCoroutine ();
			else
				this.OnInitCoroutine ();
		}
	}

	protected virtual void OnInitCoroutine(){
		if (InitCoroutineUpdate != null)
			InitCoroutineUpdate (this, EventArgs.Empty);
	}

	protected virtual void OnStopCoroutine(){
		if (StopCoroutineUpdate!= null)
			StopCoroutineUpdate (this, EventArgs.Empty);
	}


	public bool playSound{ 
		get { return _playSound; }
		set {
			_playSound = value;
			if(_playSound)
				this.OnSoundPlay ();
		}
	}


	protected virtual void OnSoundPlay(){
		if (SoundPlay != null)
			SoundPlay (this, EventArgs.Empty);
	}

	public int score { 
		get { return _score; }
		set {
			_score = value;
			this.OnRecalculateScore ();
		}
	}


	protected virtual void OnRecalculateScore(){
		if (RecalculateScore != null)
			RecalculateScore (this, EventArgs.Empty);
	}

	public int hiScore { 
		get { return _hiScore; }
		set {
			_hiScore = value;
			this.OnRecalculateHi ();
		}
	}

	protected virtual void OnRecalculateHi(){
		if (RecalculateHi != null)
			RecalculateHi (this, EventArgs.Empty);
	}
}

