using System;
using UnityEngine;

public class TriggerCollider2D2DEventArgs : EventArgs
{
	private readonly Collider2D collider2D;
	public TriggerCollider2D2DEventArgs(Collider2D collider2D)
	{
		this.collider2D = collider2D;
	}
	public Collider2D Get
	{
		get { return this.collider2D; }
	}
}
