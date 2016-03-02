using UnityEngine;
using System.Collections;

public interface ITimerScoreController : IController {
	ITimerScoreController Init ();
	ITimerScoreController Reset ();
	ITimerScoreController Stop ();
}


