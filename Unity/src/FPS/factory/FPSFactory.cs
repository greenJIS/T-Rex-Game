using System;
using UnityEngine;

public class FPSFactory : IFactory
{
	public static IModule Create(IService fpsService, EventHandler eventHandler) {
		return new FPSFactory()._Create(fpsService, eventHandler);
	}

	FPSFactory(){
	}

	public IModule _Create(IService fpsService, EventHandler eventHandler) {
		var fpsModel = FPSModel.Create(fpsService);
		var fpsController = FPSController.Create(fpsModel);
		var fpsAdapter = Instance.ToAdapter<IAdapter> (GameObject.Find (Constants.CLASS_FPS_VIEW), eventHandler);
		fpsAdapter.model = fpsModel;

		return Module.Create(fpsModel, fpsController, fpsAdapter);
	}
}

