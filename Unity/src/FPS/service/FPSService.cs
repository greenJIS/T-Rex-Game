using UnityEngine;
using System.Collections;
using System;

public class FPSService : IFPSService {

	public event EventHandler FpsUpdated;
	private float _fps;
	private WaitForSeconds waitForSeconds;


	public static IService Create(){
		return new FPSService ();
	}

	FPSService()
	{
		//MicroOptimizacion
		this.waitForSeconds = new WaitForSeconds(1f);
		this._fps = 0;
	}

	public IEnumerator Recalculate ()
	{
		while(true)
		{
			this._fps = 1 / Time.deltaTime;

			if (FpsUpdated != null)
				FpsUpdated(this, EventArgs.Empty);

			yield return this.waitForSeconds;
		}
	}

	public float fps
	{ 
		get
		{
			return this._fps;
		}
	}
}

