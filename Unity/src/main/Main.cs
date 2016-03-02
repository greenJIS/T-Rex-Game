using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class Main : MonoBehaviour  {

	private IDictionary<Type, IModelViewController> map;

	void Awake(){
		
		Notificator.GetIntance ().AddAsync (this,Constants.NOTIFICATION_METHOD_LOAD_VIEW_PRESENTER);	

		//Architecture n-tiers , MVC + Commander & Handler Pattern all one.
		this.map = new Dictionary<Type, IModelViewController>() {
			{ 
				typeof(FPSViewPresenter), 
				new ModelViewController(
					new ModelView(
						new FPSModel(),
						Instance.ToViewPresenter<IViewPresenter>(GameObject.Find(Constants.CLASS_FPS_VIEW_PRESENTER), this.LoadViewPresenter)
					)
				,new FPSController())  
			}
		};
	}


	// Notification : Avisa de que la vista ya está disponible
	private void LoadViewPresenter(object sender, EventArgs args) {
		var typeView = ((IViewPresenter)sender).GetType();
		var mvc = this.map.ContainsKey(typeView) ? this.map[typeView] : null ; 
		if (mvc == null)
			return;

		var controller = mvc.controller;
		controller.InitializeCoroutine += (_sender, e) => Debug.Log ("OnPostContructor : " + _sender.ToString ());
		controller.InitializeCoroutine += LoadCoroutine;

		controller.PostConstruct = mvc.modelView;
	}
		


	// Handler : Avisa de que el /modelo/vista/controlador de nuestro componente
	// ya está cargado y lanza el segundo plano tareas adicionales.
	private void LoadCoroutine(object sender, EventArgs args){
		var coroutine = ((IController)sender).Coroutine;
		this.StartCoroutine (coroutine);
	}

}
