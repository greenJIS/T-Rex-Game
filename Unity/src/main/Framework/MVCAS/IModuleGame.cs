using System;

//Está interfaz permite solo tener visibilidad del controlador.
public interface IModuleGame
{
	IController controller { get;  set; }
}

