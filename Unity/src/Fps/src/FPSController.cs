using UnityEngine;
using System.Collections;
using System;

public class FPSController : IFPSController {
	
	private FPSViewPresenter fpsView;
	private IFPSModel FpsModel;
	private IFPSProcessor fpsProcessor;

	private TextMesh textMesh{ get; set; }

	public FPSController (){
	}

	public void PostConstruct (MonoBehaviour parent, IViewModel modelView) {

		this.FpsModel = (IFPSModel) modelView.model;
		this.FpsModel.ReCalculate += (sender, args) => Debug.Log("FPS Recalculate "+((FPSModel)sender).fps);
		this.FpsModel.ReCalculate += OnGUI ;

		this.fpsView = modelView.view.GetComponent<FPSViewPresenter>();
		this.textMesh = this.fpsView.GetComponent<TextMesh> ();

		this.fpsProcessor = new FPSProcessor(this.FpsModel);
		var coroutine = this.fpsProcessor.Recalculate ();
		parent.StartCoroutine(coroutine);
	}

	private void OnGUI(object sender, EventArgs args){
		var fps = ((FPSModel)sender).fps;
		this.textMesh.text = "FPS: " + string.Format ("{0:0.000}", fps);
	}

}


