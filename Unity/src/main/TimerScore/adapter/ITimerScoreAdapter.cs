using System;
using System.Collections;
using UnityEngine;

public interface ITimerScoreAdapter 
{
	 TextMesh textMeshScore { get;  }	
	 TextMesh textMeshHiScore { get;  }	
	 ITimerScoreSound timerScoreSound { get;}
}
