using UnityEngine;
using System.Collections;
using System;

public interface IViewPresenter {
	event EventHandler Initialize;
	bool IsInitialize{ get; set;}
	T GetComponent<T>();
	T[] GetComponentsInChildren<T>();
	Coroutine StartCoroutine(IEnumerator coroutine);
}
