using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class ControllerMain : MonoBehaviour  {

	private IDictionary<IController, IViewModel> map;

	void Awake(){
		this.map = new Dictionary<IController, IViewModel>() {
			{ 
				new FPSController(), 
				new ViewModel(new FPSModel(), GameObject.Find(Constants.CLASS_FPS_VIEW_PRESENTER))  
			}
		};
	}

	void Start () {
		foreach (KeyValuePair<IController, IViewModel> entry in map) {
			var controller = entry.Key;
			var modelView =  entry.Value;
			controller.PostConstruct (this, modelView);
		}
	}
		
	void Update () {
		
	}

}
