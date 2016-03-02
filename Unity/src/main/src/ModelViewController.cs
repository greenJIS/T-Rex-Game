using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelViewController : IModelViewController
{
	public IController controller { get; set; }
	public IModelView modelView { get; set; }

	public ModelViewController (IModelView modelView, IController controller)
	{
		this.modelView = modelView;
		this.controller = controller;
	}

}


