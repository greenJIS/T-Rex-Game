using UnityEngine;
using System.Collections;

public class DestructorModel : Model, IDestructorModel  {

	public static IModel Create (IService service){
		return new DestructorModel (service);
	}

	DestructorModel(IService service) : base(service)
	{
		
	}

	public override IEnumerator ServiceAsync(){
		return base.service.Async ();
	}

}
