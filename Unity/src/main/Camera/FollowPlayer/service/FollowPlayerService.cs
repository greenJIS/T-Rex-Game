using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class FollowPlayerService : Service, IFollowPlayerService {

	public static IFollowPlayerService Create(){
		return new FollowPlayerService ();
	}
		
	FollowPlayerService()
	{
		
	}

	public override IEnumerator Async(){
		yield return null;
	}


}

