using System;
using UnityEngine;

public class Instance
{
	//Obtenemos del editor el Script que se aloja en la vista del componente.
	public static T ToAdapter<T>(GameObject gameObject, EventHandler eventHandler) where T : IAdapter {
		T adpater = gameObject.GetComponent<T>();
		adpater.Initialize += (_sender, e) => Debug.Log ("OnLoadAdpater : " + _sender.ToString ());
		adpater.Initialize += eventHandler;
		return adpater;
	}
}

