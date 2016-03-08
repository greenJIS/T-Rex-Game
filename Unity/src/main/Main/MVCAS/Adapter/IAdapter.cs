using UnityEngine;
using System.Collections;
using System;

public interface IAdapter {
	event EventHandler UpdateHandler;
	event EventHandler FixedUpdateHandler;
	event EventHandler Initialize;
	bool IsInitialize{ get; set;}

	void OnLoadCoroutine ();

	void StopCoroutine(IEnumerator coroutine);
	Coroutine StartCoroutine (IEnumerator coroutine);
	//T Instantiate<T> (T obj, UnityEngine.Vector3 vector3, UnityEngine.Quaternion quaternion) where T : UnityEngine.Object;

	T GetComponent<T>();
	T[] GetComponentsInChildren<T>();
	T GetComponentInChildren<T>();
	T GetComponentInParent<T>();
}

