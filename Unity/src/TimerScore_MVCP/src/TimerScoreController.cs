using UnityEngine;
using System;
using System.Collections;

public class TimerScoreController : Controller, ITimerScoreController {
	
	private const string HI = "HI ";
	private const string SCORE = "SCORE";

	private ITimerScoreModel timerScoreModel;
	private ITimerScoreViewPresenter timerScoreViewPresenter;
	private ITimerScoreProcessor timerScoreProcessor;
	private ITimerScoreSound timerScoreSound;

	private TextMesh textMeshScore{ get; set; }	
	private TextMesh textMeshHiScore{ get; set; }	

	public TimerScoreController (): base () {
	}

	public override  IModelView OnLoadPostContructor (IModelView modelView) {
		
		timerScoreModel = (TimerScoreModel) modelView.model;
		timerScoreModel.Recalculate  += (sender, e) =>  Debug.Log("OnRecalculate  "+sender.ToString());
		timerScoreModel.Recalculate += OnGUIScore;

		timerScoreModel.RecalculateHi += (sender, e) =>  Debug.Log("OnRecalculateHi "+sender.ToString());
		timerScoreModel.RecalculateHi += OnGUIHiScore;

		timerScoreModel.SoundPlay += (sender, e) =>  Debug.Log("OnSoundPlay "+sender.ToString());
		timerScoreModel.SoundPlay += OnSoundPlay;

		timerScoreModel.StopCoroutine += (sender, e) =>  Debug.Log("OnStopCoroutine "+sender.ToString());
		timerScoreModel.StopCoroutine += OnStopCoroutine;

		timerScoreModel.InitCoroutine += (sender, e) =>  Debug.Log("OnInitCoroutine "+sender.ToString());
		timerScoreModel.InitCoroutine += OnInitCoroutine;

		this.timerScoreViewPresenter = (ITimerScoreViewPresenter) modelView.viewPresenter;
		var listTextMesh = this.timerScoreViewPresenter.GetComponentsInChildren<TextMesh> ();
		this.textMeshScore = listTextMesh[1];
		this.textMeshHiScore = listTextMesh[0];

		var audioSource = this.timerScoreViewPresenter.GetComponent<AudioSource> ();
		this.timerScoreSound = new TimerScoreSound (audioSource);

		return modelView;
	}

	private void OnGUIScore(object sender, EventArgs args){
		var score = ((TimerScoreModel)sender).score;
		textMeshScore.text = string.Format ("{0:00000}", score);
	}

	private void OnGUIHiScore(object sender, EventArgs args){
		var hiScore = ((TimerScoreModel)sender).hiScore;
		textMeshHiScore.text = HI + string.Format ("{0:00000}", hiScore);
	}

	private void OnSoundPlay(object sender, EventArgs args){
		timerScoreSound.CheckPoint ();
	}
		
	public void OnStopCoroutine(object sender, EventArgs args){
	
	}

	//método channeable
	public ITimerScoreController Stop(){
 		timerScoreModel.isStopCoroutine = true;
		return this;
	}

	private void OnInitCoroutine(object sender, EventArgs args){
		this.timerScoreProcessor = new TimerScoreProcessor (timerScoreModel);
		this.Coroutine = this.timerScoreProcessor.Coroutine ();
		this.timerScoreViewPresenter.StartCoroutine (this.Coroutine);
	}

	//método channeable
	public ITimerScoreController Init(){
		timerScoreModel.isStopCoroutine = false;
		return this;
	}

	//método channeable
	public ITimerScoreController Reset(){
		this.ReCalculateHiScore ();
		timerScoreModel.score = 0;
		return this.Init();
	}

	//Se ejecuta automáticamente el handler de HiScore si (model.score > model.hiScore)
	private void ReCalculateHiScore(){
		var model = timerScoreModel;
		if(model.score > model.hiScore)
			model.hiScore = model.score;
	}

}




