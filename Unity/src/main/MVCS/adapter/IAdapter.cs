using UnityEngine;
using System.Collections;
using System;

public interface IAdapter {
	event EventHandler Initialize;
	bool IsInitialize{ get; set;}
	T GetComponent<T>();
	T[] GetComponentsInChildren<T>();
	T GetComponentInChildren<T>();
	Coroutine StartCoroutine(IEnumerator coroutine);


	IModel model { get; set; }
	IController controller{ get; set; } 
}
