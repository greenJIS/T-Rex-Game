using UnityEngine;
using System.Collections;
using System;

public class FPSModel : Model, IFPSModel 
{
	public event EventHandler ReCalculate;

	public static IModel Create (IService fpsService){
		return new FPSModel (fpsService);
	}

	FPSModel(IService service) : base(service)
	{
		((IFPSService)this.service).FpsUpdated += (sender, e) => {
			if (ReCalculate != null)
				ReCalculate (this, EventArgs.Empty);
		};
	}
		
	public override IEnumerator ServiceAsync() {
		 return this.service.Async(); 
	}

	public float fps { 
		get { return ((IFPSService)this.service).fps; }
	}

}
