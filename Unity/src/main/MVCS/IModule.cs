using System;

//Encapsulamiento de interfaces
public interface IModule : IModuleGame
{
	IModel model { get; set; }
	IAdapter adapter { get; set; }
}

