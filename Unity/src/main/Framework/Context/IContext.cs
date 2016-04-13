using UnityEngine;
using System.Collections;

public interface IContext
{
	IController Get (string key) ;
	T GetExtension<T> (string key) where T : IExtension;
		
}

