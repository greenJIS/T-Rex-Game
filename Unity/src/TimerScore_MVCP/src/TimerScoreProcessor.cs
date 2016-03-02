using UnityEngine;
using System.Collections;


public class TimerScoreProcessor  : ITimerScoreProcessor
{
	private const int CHECK_POINT = 100;
	private const float SLEEP = 0.100f;
	private WaitForSeconds waitForSeconds;
	private ITimerScoreModel timerScoreModel;

	public TimerScoreProcessor (ITimerScoreModel timerScoreModel) {
		this.timerScoreModel = timerScoreModel;
		this.waitForSeconds = new WaitForSeconds (SLEEP);
	}
		
	public IEnumerator Coroutine(){
		while (!this.timerScoreModel.isStopCoroutine) {
			this.timerScoreModel.score++;

			if (this.timerScoreModel.score % CHECK_POINT == 0)
				this.timerScoreModel.playSound = true;

			yield return this.waitForSeconds;
		}
	}
}

