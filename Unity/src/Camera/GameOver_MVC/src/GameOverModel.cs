using System;

public class GameOverModel : IGameOverModel
{
	private bool _isVisible;

	public event EventHandler Visible;
	public event EventHandler Hidden;

	public GameOverModel ()
	{
		this._isVisible = false;
	}

	public bool isVisible { 
		get { return this._isVisible; }

		set {
			this._isVisible = value;
			if (this._isVisible){
				if (this.Visible != null)
					this.Visible (this, EventArgs.Empty);
			}
			else if (this.Hidden != null)
				this.Hidden (this, EventArgs.Empty);
		}
	}

}
