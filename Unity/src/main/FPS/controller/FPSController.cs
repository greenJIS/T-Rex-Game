using UnityEngine;
using System.Collections;
using System;

public class FPSController : Controller, IFPSController
{
	public static IController Create(IAdapter adapter,IModel fpsModel){
		return new FPSController (adapter,fpsModel);
	}

	FPSController(IAdapter adapter, IModel model) : base(adapter,model)
	{
	//	base.adapter.UpdateHandler += (sender, e) => Debug.Log ("OnUpdate " + sender.ToString ());
		base.adapter.UpdateHandler += (sender, e) => {
		
		};

		var fpsAdapter = ((IFPSAdapter)base.adapter);
		var fpsModel =  ((IFPSModel)base.model);

	//	fpsModel.ReCalculate += (sender, args) => Debug.Log("FPS Recalculate "+((FPSModel)sender).fps);        
		fpsModel.ReCalculate += (sender, e) => {
			var fps = ((FPSModel)sender).fps;
			fpsAdapter.textMesh.text = "FPS: " + string.Format("{0:0.000}", fps);
		};

	}

	public override void OnLoadPostContructor ()
	{		
		base.Coroutine = model.ServiceAsync();
		base.adapter.StartCoroutine (base.Coroutine);
	}

}


