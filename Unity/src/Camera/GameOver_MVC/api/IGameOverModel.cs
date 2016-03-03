using System;


	public interface IGameOverModel : IModel
	{
		bool isVisible { get; set;}
		event EventHandler Visible;
		event EventHandler Hidden;
	}


