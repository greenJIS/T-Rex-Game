using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IViewModel
{
	IModel model { get;  set; }
	GameObject view { get; set;}
}


