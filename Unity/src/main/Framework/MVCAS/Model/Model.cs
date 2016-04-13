using System;
using System.Collections;

public class Model : IModel
{
	protected IService service { get; set;}

	public Model (IService service) 
	{
		this.service = service;
	}

	public virtual IEnumerator ServiceAsync(){
		throw new Exception ("Not Implemented");
	}

		
}

