using UnityEngine;
using System.Collections;
using System;

public class FPSController : Controller, IFPSController
{
	private IFPSModel _fpsModel;

	public static IController Create(IModel fpsModel){
		return new FPSController (fpsModel);
	}

	FPSController (IModel fpsModel) : base()
	{
		_fpsModel = (IFPSModel)fpsModel;
	}

	public override void OnLoadPostContructor ()
	{		
		_fpsModel.ReCalculate += (sender, args) => Debug.Log("FPS Recalculate "+((FPSModel)sender).fps);        
		this.Coroutine = ((FPSService)_fpsModel.Service).Recalculate ();

		//Muy importante!!!
		//Llamamos a Papa para decirle que el servicio ya está cargado (Coroutina)
		//De esta manera evitamos "condiciones de carrera" al lanzar el disparado del servicio
		//En el caso de que se colara antes de la llamada al "OnLoadPostContructor"
		base.OnLoadPostContructor ();
	}

}


