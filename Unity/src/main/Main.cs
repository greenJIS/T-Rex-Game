using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class Main : MonoBehaviour  {

	public IContext context { get; set; }

	void Awake(){
		this.CreateContext ();
		this.CreateExtension ();
		DontDestroyOnLoad (this.gameObject);
	}

	// Architecture n-tiers , Model-View-Controller + [Commander & Handler & ObjectValue] Pattern all one.
	// Factory Methods & lambdas
	private void CreateContext() {
		this.context = Context.Create ();
	}

	private void CreateExtension(){
		Context.CreateExtension ();
	}

}
