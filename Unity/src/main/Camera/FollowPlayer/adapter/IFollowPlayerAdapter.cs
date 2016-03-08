using System;
using UnityEngine;
using System.Collections;

public interface IFollowPlayerAdapter {
	Transform mainCameraTransform { get; }
	Transform t_RexTransform{ get;}
}
