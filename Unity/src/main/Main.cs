using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class Main : MonoBehaviour  {

	//Es estatico porque estoy reestructurando todo el proyecto y quitando las notificiaciones.
	//Necesito accedes a objetos que tengo fuera del Main, mal estructurados.
	public static IDictionary<Type, IModuleGame> _context;

	void Awake(){
		this.createContext ();
		DontDestroyOnLoad (this.gameObject);
	}

	//Architecture n-tiers , Model-View-Controller + [Commander & Handler & ObjectValue] Pattern all one.
	// TODO: Factory Methods & lambdas
	private void createContext() {
		
		context = new Dictionary<Type, IModuleGame> () { 
			{ 
				typeof(FPSAdapter), FPSFactory.Create(FPSService.Create() , LoadAdapter)
			}
		/*	{ 
				typeof(TimerScoreViewPresenter), 
				new ModelViewController (
					new ModelView (
						new TimerScoreModel (),
						Instance.ToViewPresenter<IViewPresenter> (GameObject.Find (Constants.CLASS_TIMER_SCORE_VIEW_PRESENTER), this.LoadViewPresenter)
					)
				, new TimerScoreController ())  
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
*/
			// { ... } 

		};
	}


	// Notification : Avisa de que la vista ya está disponible
	private void LoadAdapter(object sender, EventArgs args) {
		var typeView = ((IAdapter)sender).GetType();
		var mvc = _context.ContainsKey(typeView) ? _context[typeView] : null ; 
		if (mvc == null)
			return;

		this.InitializeController(mvc);
	}

	private void InitializeController(IModuleGame module){
		var controller = module.controller;
		controller.InitializeLoadPostConstructor += (sender_, e) => Debug.Log ("OnLoadPostContructor : " + sender_.ToString ());
		controller.InitializeLoadPostConstructor += OnLoadPostContructor;

		controller.InitializeCoroutine += (_sender, e) => Debug.Log ("OnLoadCoroutine : " + _sender.ToString ());
		controller.InitializeCoroutine += OnLoadCoroutine;

		//Dispara los dos manejadores de arriba por separado
		controller.OnPostConstruct ();
	}

	// Handler : Avisa a los controladores de que el contexto locañ se ha iniciado. 
	private void OnLoadPostContructor(object sender, EventArgs args){
		var controller = ((IController)sender);
		controller.OnLoadPostContructor ();
	}

	// Handler : Avisa de que el modelo/vista/controlador de nuestro componente
	// ya está cargado y lanza el segundo plano servicios adicionales.
	private void OnLoadCoroutine(object sender, EventArgs args){
		var controller = ((IController)sender);
		var coroutine = controller.Coroutine;
		if (coroutine == null)
			return;
		
		this.StartCoroutine (coroutine);
	}

	//otorga vidibilidad solamente del controlador, ocultado el modelo y la vista que no deben de ser
	//visibles para la modificación desde fuera de esta clase.
	public IDictionary<Type, IModuleGame> context { 
		get { return _context; }
		private set { _context = value; } 
	}
}
