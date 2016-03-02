using System;
using System.Collections;
using UnityEngine;

public interface IFPSViewPresenter
{
	void OnGUI();
	Coroutine StartCoroutine(IEnumerator coroutine);
	T GetComponent<T>();
}
