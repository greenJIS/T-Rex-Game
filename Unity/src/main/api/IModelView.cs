using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IModelView
{
	IModel model { get;  set; }
	IViewPresenter viewPresenter { get; set;}
}


