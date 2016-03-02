using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IModelViewController
{
	IModelView modelView { get;  set; }
	IController controller { get; set; }
}


