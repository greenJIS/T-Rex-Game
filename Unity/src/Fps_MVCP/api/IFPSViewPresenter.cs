using System;
using System.Collections;
using UnityEngine;

public interface IFPSViewPresenter : IViewPresenter
{
	T GetComponent<T>();
}
