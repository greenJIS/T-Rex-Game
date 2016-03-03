using System;
using System.Collections;
using UnityEngine;

public class Controller : IController
{
	public IEnumerator Coroutine { get; set; }
	public event EventHandler InitializeCoroutine;
	public event EventHandler InitializeLoadPostConstructor;

	private bool _initializeLoadPostConstructor;
	private bool _initializeCoroutine;

	public Controller () {
		this._initializeLoadPostConstructor = false;
		this._initializeCoroutine = false;
	}

	public void OnPostConstruct()
	{
		this.initializeLoadPostConstructor = true;
	}
		
	public virtual void OnLoadPostContructor ()
	{
		this.initializeCoroutine = true;
	}

	private bool initializeLoadPostConstructor
	{
		get { return this._initializeLoadPostConstructor; }
		set { this._initializeLoadPostConstructor = value;
			
				if (this.InitializeLoadPostConstructor != null)
					this.InitializeLoadPostConstructor (this, EventArgs.Empty);
				else
					Debug.Log ("InitializeLoadPostConstructor NO DISPARADO!!!!!");
			
			}
	}

	private bool initializeCoroutine 
	{
		get { return this._initializeCoroutine; }
		set { this._initializeCoroutine = value;
			
			if (this.InitializeCoroutine != null)
				this.InitializeCoroutine (this, EventArgs.Empty);
			else
				Debug.Log ("InitializeCoroutine NO DISPARADO!!!!!");
		}
	}

}

