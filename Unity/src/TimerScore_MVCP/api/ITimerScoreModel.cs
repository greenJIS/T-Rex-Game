using UnityEngine;
using System.Collections;
using System;

public interface ITimerScoreModel : IModel {
	 event EventHandler RecalculateHi;
	 event EventHandler Recalculate;
	 event EventHandler SoundPlay;
	 event EventHandler StopCoroutine;
	 event EventHandler InitCoroutine;

	bool isStopCoroutine { get; set;}
	bool playSound { get; set;}
	int score { get; set; }
	int hiScore { get; set; }
}
