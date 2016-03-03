using UnityEngine;
using System.Collections;
using System;

public interface IFPSModel : IModel {
	float fps { get; }
	event EventHandler ReCalculate;
}
