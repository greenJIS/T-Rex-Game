using System;
using UnityEngine;
using System.Collections;

public class FollowPlayerAdapter : Adapter, IFollowPlayerAdapter
{
	public Transform mainCameraTransform { get; set; }
	public Transform t_RexTransform { get; set; }

	void Awake()
	{
	}

	void Start(){	
		this.t_RexTransform = GameObject.Find(Constants.CLASS_PLAYER_VIEW).transform;
		this.mainCameraTransform = Camera.main.transform;

		base.IsInitialize = true;
	}

	public override void OnLoadCoroutine ()
	{

	}
		
}