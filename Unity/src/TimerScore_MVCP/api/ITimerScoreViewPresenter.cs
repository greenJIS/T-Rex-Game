using System;
using System.Collections;
using UnityEngine;

public interface ITimerScoreViewPresenter : IViewPresenter
{
	T[] GetComponentsInChildren<T>();
	Coroutine StartCoroutine(IEnumerator coroutine);
}
