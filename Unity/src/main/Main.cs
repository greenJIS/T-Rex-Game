using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class Main : MonoBehaviour  {

	private IDictionary<Type, IModelViewController> MVC;

	void Awake(){
		this.createContext ();
		DontDestroyOnLoad (this.gameObject);
	}

	//Architecture n-tiers , Model-View-Controller + [Commander & Handler & ObjectValue] Pattern all one.
	// TODO: Factory Methods & lambdas
	private void createContext() {
		
		MVC = new Dictionary<Type, IModelViewController>() {
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
			},
			{
                typeof(GameOverViewPresenter),
                new ModelViewController (
                    new ModelView (
                        new GameOverModel (),
                        Instance.ToViewPresenter<IViewPresenter> (GameObject.Find (Constants.CLASS_TIMER_GAME_OVER_VIEW_PRESENTER), this.LoadViewPresenter)
                    )
                    , new GameOverController ())
            }

			// { ... } 

		};
	}


	// Notification : Avisa de que la vista ya está disponible
	private void LoadViewPresenter(object sender, EventArgs args) {
		var typeView = ((IViewPresenter)sender).GetType();
		var mvc = MVC.ContainsKey(typeView) ? MVC[typeView] : null ; 
		if (mvc == null)
			return;

		this.InitializeController(mvc);
	}

	private void InitializeController(IModelViewController mvc){
		var controller = mvc.controller;
		controller.InitializeCoroutine += (_sender, e) => Debug.Log ("OnPostContructor : " + _sender.ToString ());
		controller.InitializeCoroutine += LoadCoroutine;

		controller.PostConstruct = mvc.modelView;
	}
		
	// Handler : Avisa de que el /modelo/vista/controlador de nuestro componente
	// ya está cargado y lanza el segundo plano tareas adicionales.
	private void LoadCoroutine(object sender, EventArgs args){
		var coroutine = ((IController)sender).Coroutine;
		if(coroutine!=null)
			this.StartCoroutine (coroutine);
	}

	//otorga vidibilidad solamente del controlador, ocultado el modelo y la vista que no deben de ser
    //visibles para la modificación desde fuera de esta clase.
    public IDictionary<Type, IModelViewIController> mvc {
        get { return MVC; }
        private set { MVC = value; }
    }

}
