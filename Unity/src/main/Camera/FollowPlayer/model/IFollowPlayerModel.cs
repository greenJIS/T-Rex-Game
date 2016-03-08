using UnityEngine;
using System.Collections;
using System;

public interface IFollowPlayerModel {
	event EventHandler Transform;
	event EventHandler IsStop;

	Boolean isStop{ get; set; }
	Transform transform{ get; set; }
}
