using UnityEngine;
using System.Collections;
using System;

public interface IController {
	IEnumerator Coroutine { get; set; }
	event EventHandler InitializeCoroutine;
	event EventHandler InitializeLoadPostConstructor;

	void OnPostConstruct ();
	void OnLoadPostContructor ();
		
}
