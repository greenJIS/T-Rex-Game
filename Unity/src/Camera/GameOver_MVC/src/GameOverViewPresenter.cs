using System;
using UnityEngine;

public class GameOverViewPresenter: MonoBehaviour, IGameOverViewPresenter
{
	public event EventHandler Initialize;

	void Awake(){

	}

	void Start (){
		this.IsInitialize = true;
	}

	private bool isInitialize;
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


