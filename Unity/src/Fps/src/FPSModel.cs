using UnityEngine;
using System.Collections;
using System;

public class FPSModel : IFPSModel {

	private float _fps;

	public FPSModel(){
		this.fps = 0;
	}

	//public void PostConstruct(){}

	public event EventHandler ReCalculate;

	public float fps { 
		get { return this._fps; }
		set {

			this._fps = value;
			this.OnRecalculate ();
		}
	}

	protected virtual void OnRecalculate(){
		if (ReCalculate != null)
			ReCalculate (this, EventArgs.Empty);
	}
}
