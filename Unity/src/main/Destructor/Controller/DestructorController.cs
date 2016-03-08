using UnityEngine;
using System.Collections;
using System;

public class DestructorController : Controller, IDestructorController {

	public static IController Create(IAdapter adapter,IModel model){
		return new DestructorController (adapter, model);
	}

	DestructorController (IAdapter adapter, IModel model) : base(adapter,model)
	{
		var destructorAdapter = (IDestructorAdapter)adapter;

		destructorAdapter.TriggerEnter2DHandler += (sender, args) => Debug.Log ("OnTriggerEnter2DHandler: " + sender.ToString ());
		destructorAdapter.TriggerEnter2DHandler += (sender, args) => {
			var triggerCollider2D2DEventArgs = (TriggerCollider2D2DEventArgs)args;
			var collider = triggerCollider2D2DEventArgs.Get;

			if (collider.GetType() == typeof(GroundAdapter))
				return;

			Debug.Log ("Destructor: "+collider.tag);
			GameObject.Destroy(collider.gameObject);
		};

	}

	public override void OnLoadPostContructor ()
	{
		base.Coroutine = model.ServiceAsync ();
	}
}

