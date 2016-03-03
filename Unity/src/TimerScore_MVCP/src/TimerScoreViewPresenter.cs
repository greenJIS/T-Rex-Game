using UnityEngine;
using System.Collections;
using System;

public class TimerScoreViewPresenter : MonoBehaviour, ITimerScoreViewPresenter
{
	public event EventHandler Initialize;
	private bool isInitialize;

	void Awake(){

	}

	void Start (){
		this.IsInitialize = true;
	}

	public bool IsInitialize { 
		get {
			return this.isInitialize;
		}
		set {
			this.isInitialize = value;

			if (Initialize != null)
				this.Initialize (this, EventArgs.Empty);
		}
	}

}



