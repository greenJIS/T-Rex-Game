using UnityEngine;
using System.Collections;
using System;

public interface IController {
	void PostConstruct (MonoBehaviour parent, IViewModel viewModel);
}
