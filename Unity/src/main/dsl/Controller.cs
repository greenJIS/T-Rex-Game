using System;
using System.Collections;
using UnityEngine;

public class Controller : IController
{
	public IEnumerator Coroutine { get; set; }
	public event EventHandler InitializeCoroutine;

	public Controller () {
	}

	protected IModelView postConstruct;
	public IModelView PostConstruct { 
		get {
			return this.postConstruct;
		}
		set {
			this.postConstruct = this.OnLoadPostContructor (value);
			if (InitializeCoroutine != null)
				this.InitializeCoroutine (this, EventArgs.Empty);
		}
	}

	public virtual IModelView OnLoadPostContructor (IModelView modelView){
		return modelView;
	}
		

}

