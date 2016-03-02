using UnityEngine;
using System.Collections;

public class FPSProcessor : IFPSProcessor  {

	private IFPSModel fpsModel;

	public FPSProcessor(IFPSModel fpsModel){
		this.fpsModel = fpsModel;
	}

	public IEnumerator Recalculate () {
		while(true){
			fpsModel.fps = 1 / Time.deltaTime;
			yield return new WaitForSeconds(1f);
		}
	}


}
