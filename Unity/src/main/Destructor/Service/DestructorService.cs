using UnityEngine;
using System.Collections;

public class DestructorService : Service, IDestructorService{


	public static IService Create(){
		return new DestructorService ();
	}

	DestructorService() : base(){
	
	}

	public override IEnumerator Async ()
	{
		yield return null;
	}
}
