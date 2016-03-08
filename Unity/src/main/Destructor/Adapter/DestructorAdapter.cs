using UnityEngine;
using System.Collections;
using System;

public class DestructorAdapter : Adapter, IDestructorAdapter
{
	public event EventHandler TriggerEnter2DHandler;

	void Start ()
	{
	
	}

	public override void OnLoadCoroutine ()
	{
		
	}

	void OnTriggerEnter2D(Collider2D collider){
		if(TriggerEnter2DHandler != null )
			TriggerEnter2DHandler(this,new TriggerCollider2D2DEventArgs(collider));
	}
		
}

