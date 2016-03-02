using System;
using UnityEngine;

public class FPSViewPresenter : MonoBehaviour, IFPSViewPresenter
{
	public event EventHandler Initialize;
	private bool isInitialize;

	void Awake(){
		
	}

	void Start (){
		this.IsInitialize = true;
		//Notificator.GetIntance ().PostAsync (this,Constants.NOTIFICATION_METHOD_LOAD_VIEW_PRESENTER,this)
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
