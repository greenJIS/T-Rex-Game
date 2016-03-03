using System;
using UnityEngine;

public class FPSAdapter : MonoBehaviour, IFPSAdapter
{
	public event EventHandler Initialize;

	private TextMesh _textMesh;
	private bool _isInitialize;

	private IFPSModel _fpsModel;
	private IFPSController _fpsController;

	void Awake()
	{
		_textMesh = GetComponent<TextMesh>();
		_fpsModel.ReCalculate += OnUpdateFPS;
	}

	void Start ()
	{
		this.IsInitialize = true;
	}
		
	public bool IsInitialize
	{ 
		get
		{
			return this._isInitialize;
		}
		set
		{
			this._isInitialize = value;

			if (Initialize != null)
				this.Initialize (this, EventArgs.Empty);
		}
	}    

	public IModel model
	{
		set { this._fpsModel = (FPSModel)value; }
		get { return this._fpsModel; }
	}

	public IController controller {
		set { this._fpsController = (FPSController)value; }
		get { return (IController)this._fpsController; }
	}

	private void OnUpdateFPS(object sender, EventArgs args)
	{
		var fps = ((FPSModel)sender).fps;
		_textMesh.text = "FPS: " + string.Format("{0:0.000}", fps);
	}


}