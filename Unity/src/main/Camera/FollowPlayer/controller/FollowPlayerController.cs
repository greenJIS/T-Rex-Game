using UnityEngine;
using System.Collections;
using System;

public class FollowPlayerController : Controller, IFollowPlayerController
{
	private static float SEPARACION = 6.61f;

	public static IController Create(IAdapter adapter, IModel fpsModel){
		return new FollowPlayerController (adapter,fpsModel);
	}

	FollowPlayerController (IAdapter adapter, IModel model) : base(adapter,model)
	{
		var followPlayerModel = ((FollowPlayerModel)base.model);
		var followPlayerAdapter = ((FollowPlayerAdapter)base.adapter);

		followPlayerAdapter.UpdateHandler += (sender, e) => Debug.Log ("OnUpdate " + sender.ToString ());
		followPlayerAdapter.UpdateHandler += (sender, e) => {
			if (followPlayerModel.isStop)
				return;
			
			var _followPlayerAdapter = (IFollowPlayerAdapter)sender;
			var t_rextTransform = _followPlayerAdapter.t_RexTransform;
			var parentTransform = _followPlayerAdapter.mainCameraTransform;
			parentTransform.position = new Vector3 (t_rextTransform.position.x + SEPARACION, parentTransform.position.y, parentTransform.position.z);
		};
			
		followPlayerModel.IsStop += (sender, e) => Debug.Log("OnIsStop "+sender.ToString());
		followPlayerModel.IsStop += (sender, e) => {
			
		};

		followPlayerModel.Transform += (sender, e) => Debug.Log("OnPosition "+sender.ToString());
		followPlayerModel.Transform += (sender, e) => {
			
		};
	}

	public override void OnLoadPostContructor ()
	{		 
		base.Coroutine = model.ServiceAsync ();
	}
				
	public void stop(){
		((IFollowPlayerModel)base.model).isStop = true;
	}

	public void start(){
		((IFollowPlayerModel)base.model).isStop = false;
	}
}


