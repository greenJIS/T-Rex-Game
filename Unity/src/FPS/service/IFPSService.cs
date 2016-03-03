using System;
using System.Collections;

public interface IFPSService : IService
{
	float fps { get; }
	IEnumerator Recalculate ();
	event EventHandler FpsUpdated;
}

