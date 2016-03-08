using UnityEngine;
using System.Collections;
using System;

public class TimerScoreController : Controller, ITimerScoreController
{
	private const string HI = "HI ";
	private const string SCORE = "SCORE";

	public static IController Create(IAdapter adapter, IModel model){
		return new TimerScoreController (adapter,model);
	}

	TimerScoreController (IAdapter adapter, IModel model) : base(adapter,model)
	{
		var timerScoreAapter = (ITimerScoreAdapter)base.adapter;
		//base.adapter.UpdateHandler += (sender, e) => Debug.Log("OnUpdate " +sender.ToString());
		base.adapter.UpdateHandler += (sender, e) => {
		
		};

		var timerScoreModel = (ITimerScoreModel)base.model;

		//timerScoreModel.InitCoroutine += (sender, e) => Debug.Log ("OnInitCoroutine " +sender.ToString ());
		timerScoreModel.InitCoroutine += (sender, e) =>  {
			base.adapter.StartCoroutine (base.Coroutine);
		};
			
	//	timerScoreModel.Recalculate += (sender, e) => Debug.Log ("OnGUIScore " +sender.ToString ());
		timerScoreModel.Recalculate += (sender, e) => {
			var score = ((ITimerScoreModel)sender).score;
			timerScoreAapter.textMeshScore.text = string.Format ("{0:00000}", score);
		};
 
	//	timerScoreModel.RecalculateHi += (sender, e) => Debug.Log ("OnGUIHiScore " +sender.ToString ());
		timerScoreModel.RecalculateHi += (sender, e) => {
			var hiScore = ((ITimerScoreModel)sender).hiScore;
			timerScoreAapter.textMeshHiScore.text = HI + string.Format ("{0:00000}", hiScore);
		};
			
	//	timerScoreModel.SoundPlay += (sender, e) => Debug.Log ("OnSoundPlay " +sender.ToString ());
		timerScoreModel.SoundPlay += (sender, e) => {
			timerScoreAapter.timerScoreSound.CheckPoint ();
		};
			
	//	timerScoreModel.StopCoroutine += (sender, e) => Debug.Log ("OnStopCoroutine " +sender.ToString ());
		timerScoreModel.StopCoroutine += (sender, e) => {
			base.adapter.StopCoroutine (base.Coroutine);
		};

	}

	public override void OnLoadPostContructor ()
	{		
		//((ITimerScoreModel)base.model).Recalculate += (sender, args) => Debug.Log("InitCoroutine"+sender.ToString()); 
		base.Coroutine = model.ServiceAsync ();
	}

	public void Stop(){
		((ITimerScoreModel)base.model).isStopCoroutine = true;
	}

	public ITimerScoreController Init(){
		((ITimerScoreModel)base.model).isStopCoroutine = false;
		return this;
	}

	public ITimerScoreController Reset(){
		this.ReCalculateHiScore ();
		((ITimerScoreModel)base.model).score = 0;
		return this.Init();
	}

	public int Score(){
		return ((ITimerScoreModel)base.model).score;
	}

	//Se ejecuta automáticamente el handler de HiScore si (model.score > model.hiScore)
	private void ReCalculateHiScore(){
		var model = ((ITimerScoreModel)base.model);
		if(model.score > model.hiScore)
			model.hiScore = model.score;
	}

}


