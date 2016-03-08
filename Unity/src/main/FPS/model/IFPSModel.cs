using UnityEngine;
using System.Collections;
using System;

public interface IFPSModel  {
	float fps { get; }
	event EventHandler ReCalculate;
}
