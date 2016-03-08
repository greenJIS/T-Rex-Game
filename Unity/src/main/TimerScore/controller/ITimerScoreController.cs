using UnityEngine;
using System.Collections;

public interface ITimerScoreController  {

	ITimerScoreController Init ();
	ITimerScoreController Reset ();
	void Stop ();
	int Score ();
		
}


