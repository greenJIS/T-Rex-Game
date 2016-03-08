using System;
using System.Collections;

public interface IFPSService 
{
	float fps { get; }
	event EventHandler FpsUpdated;
}

