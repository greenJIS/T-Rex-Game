using UnityEngine;
using System.Collections;
using System;

public class FPSModel : IFPSModel 
{
	private IFPSService _fpsService;

	public event EventHandler ReCalculate;

	public static IModel Create (IService fpsService){
		return new FPSModel (fpsService);
	}

	FPSModel(IService fpsService)
	{
		_fpsService = (IFPSService)fpsService;
		_fpsService.FpsUpdated += OnFpsUpdated;
	}

	private void OnFpsUpdated(object sender, EventArgs args)
	{
		OnRecalculate();
	}

	protected virtual void OnRecalculate()
	{
		if (ReCalculate != null)
			ReCalculate(this, EventArgs.Empty);
	}

	public float fps
	{ 
		get
		{            
			return this._fpsService.fps;
		}
	}

	public IService Service {
		get { return _fpsService; }
	}

}
