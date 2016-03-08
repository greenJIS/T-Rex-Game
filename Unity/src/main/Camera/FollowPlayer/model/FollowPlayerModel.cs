using UnityEngine;
using System.Collections;
using System;

public class FollowPlayerModel : Model, IFollowPlayerModel  {

	public event EventHandler Transform;
	public event EventHandler IsStop;

	private bool _isStop;
	private Transform _transform;

	public static IModel Create (IService service){
		return new FollowPlayerModel (service);
	}
		
	FollowPlayerModel(IService service) : base(service)
	{
		this._isStop = false;
	}
		
	public override IEnumerator ServiceAsync() {
		return this.service.Async(); 
	}

	public Transform transform { 
		get { return this._transform; }
		set { 
			this._transform = value;
			if (Transform != null)
				Transform (this, EventArgs.Empty);
		}
	}

	public bool isStop { 
		get { return this._isStop; }
		set { 
			this._isStop = value;
			if (IsStop != null)
				IsStop (this, EventArgs.Empty);
		}
	}

}
