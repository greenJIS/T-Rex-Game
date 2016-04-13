using UnityEngine;
using System.Collections;
using System;

public interface IController {
	IAdapter adapter { get; set;}
	IModel model { get; set;}

	IEnumerator Coroutine { get; set; }
	void OnLoadPostContructor ();
}
