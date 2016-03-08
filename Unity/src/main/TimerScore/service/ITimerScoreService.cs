using System;
using System.Collections;

public interface ITimerScoreService
{
	bool isStopCoroutine { get; set;}
	bool playSound { get; set;}
	int score { get; set; }
	int hiScore { get; set; }

	event EventHandler RecalculateHi;
	event EventHandler RecalculateScore;
	event EventHandler SoundPlay;
	event EventHandler StopCoroutineUpdate;
	event EventHandler InitCoroutineUpdate;
}

