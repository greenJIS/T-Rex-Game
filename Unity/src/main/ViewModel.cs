using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewModel : IViewModel
{
	public IModel model { get; set; }
	public GameObject view { get; set;}

	public ViewModel (IModel model, GameObject view)
	{
		this.model = model;
		this.view = view;
	}

}


