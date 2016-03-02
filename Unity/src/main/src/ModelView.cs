using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelView : IModelView
{
	public IModel model { get; set; }
	public IViewPresenter viewPresenter { get; set;}


	public ModelView (IModel model, IViewPresenter viewPresenter)
	{
		this.model = model;
		this.viewPresenter = viewPresenter;
	}
		
}

