using System;

public class TimerScoreModel : ITimerScoreModel
{
	private int _score;
	private int _hiScore;
	private bool _playSound;
	private bool _isStopCoroutine;

	public event EventHandler RecalculateHi;
	public event EventHandler Recalculate;
	public event EventHandler SoundPlay;
	public event EventHandler StopCoroutine, InitCoroutine;

	public TimerScoreModel()
	{
		this._playSound = false;
		this._score = 0;
		this._hiScore = 0;
		this._isStopCoroutine = false;
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
		if (InitCoroutine != null)
			InitCoroutine (this, EventArgs.Empty);
	}

	protected virtual void OnStopCoroutine(){
		if (StopCoroutine != null)
			StopCoroutine (this, EventArgs.Empty);
	}


	public bool playSound{ 
		get {
			return _playSound;
		}
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
		get {
			return _score;
		}
		set {
			_score = value;
			this.OnRecalculate ();
		}
	}


	protected virtual void OnRecalculate(){
		if (Recalculate != null)
			Recalculate (this, EventArgs.Empty);
	}
		
	public int hiScore { 
		get {
			return _hiScore;
		}
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


