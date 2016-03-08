using UnityEngine;
using System.Collections;
using System;

public class FPSService : Service , IFPSService {

	public event EventHandler FpsUpdated;
	private float _fps;


	public static IService Create(){
		return new FPSService ();
	}

	FPSService()
	{
			//MicroOptimizacion
		base.waitForSeconds = new WaitForSeconds(1f);
		this._fps = 0;
	}

	public override IEnumerator Async()
	{
		while(true)
		{
			this._fps = 1 / Time.deltaTime;

			if (FpsUpdated != null)
				FpsUpdated(this, EventArgs.Empty);

			yield return base.waitForSeconds;
		}
    }

	public float fps
	{ 
		get { return this._fps; }
	}
}

