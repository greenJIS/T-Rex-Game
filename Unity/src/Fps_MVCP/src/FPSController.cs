using UnityEngine;
using System.Collections;
using System;

public class FPSController : Controller, IFPSController {

	private TextMesh textMesh{ get; set; }	
	private IFPSViewPresenter fpsView;
	private IFPSModel FpsModel;
	private IFPSProcessor fpsProcessor;

	public FPSController () : base() {
	}
		
	public override IModelView OnLoadPostContructor (IModelView modelView) {

		this.FpsModel = (IFPSModel) modelView.model;
		this.FpsModel.ReCalculate += (sender, args) => Debug.Log("FPS Recalculate "+((FPSModel)sender).fps);
		this.FpsModel.ReCalculate += OnGUI ;

		this.fpsView = (IFPSViewPresenter) modelView.viewPresenter;
		this.textMesh = this.fpsView.GetComponent<TextMesh> ();

		this.fpsProcessor = new FPSProcessor(this.FpsModel);
		this.Coroutine = this.fpsProcessor.Recalculate ();

		return modelView;
	}
		
	private void OnGUI(object sender, EventArgs args){
		var fps = ((FPSModel)sender).fps;
		this.textMesh.text = "FPS: " + string.Format ("{0:0.000}", fps);
	}



}


