using System;
using UnityEngine;

public class Instance
{
	//Obtenemos del editor el Script que se aloja en la vista del componente.
	public static T ToViewPresenter<T>(GameObject gameObject, EventHandler eventHandler) where T : IViewPresenter {
		T viewPresenter = gameObject.GetComponent<T>();
		viewPresenter.Initialize += (_sender, e) => Debug.Log ("OnPLoadViewPresenter : " + _sender.ToString ());
		viewPresenter.Initialize += eventHandler;
		return viewPresenter;
	}
}

