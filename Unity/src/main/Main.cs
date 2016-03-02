using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class Main : MonoBehaviour  {

	private IDictionary<Type, IModelViewController> map;

	void Awake(){
		//Architecture n-tiers , MVC + Commander & Handler Pattern all one. Optimize!
		this.map = new Dictionary<Type, IModelViewController>() {
			{ 
				typeof(FPSViewPresenter), 
				new ModelViewController(
					new ModelView(
						new FPSModel(),
						Instance.ToViewPresenter<IViewPresenter>(GameObject.Find(Constants.CLASS_FPS_VIEW_PRESENTER), this.LoadViewPresenter)
					)
				,new FPSController())  
			},
			{
            	typeof(TimerScoreViewPresenter),
              	new ModelViewController(
              		new ModelView(
              			new TimerScoreModel(),
              			Instance.ToViewPresenter<IViewPresenter>(GameObject.Find(Constants.CLASS_TIMER_SCORE_VIEW_PRESENTER), this.LoadViewPresenter)
              		)
              	,new TimerScoreController())
            }
		};
	}


	// Handler : Avisa de que la vista ya está disponible
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
		


	// Handler : Avisa de que el modelo/vista/controlador de nuestro componente
	// ya está cargado en el render y lanza en segundo plano tareas adicionales Asíncronas.
	private void LoadCoroutine(object sender, EventArgs args){
		var coroutine = ((IController)sender).Coroutine;
		if(coroutine==null)
		    return;

        this.StartCoroutine (coroutine);
	}

}
