using System;
using UnityEngine;

public class FPSAdapter : Adapter ,IFPSAdapter
{
	public TextMesh textMesh{ get; set;}

	void Awake()
	{
		
	}

	void Start ()
	{
		this.GetComponent ();
		this.IsInitialize = true;
	}

	public void GetComponent ()
	{
		textMesh = base.GetComponent<TextMesh> ();
	}

	public override void OnLoadCoroutine ()
	{
	}
		

}