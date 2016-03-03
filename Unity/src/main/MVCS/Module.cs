public class Module : IModule
{
	public IModel model { get; set; }
	public IController controller { get; set; }
	public IAdapter adapter { get; set; }

	public static IModule Create(IModel model, IController controller, IAdapter adapter)
	{
		return new Module (model, controller, adapter);
	}

	Module (IModel model, IController controller, IAdapter adapter)
	{
		this.model = model;
		this.controller = controller;
		this.adapter = adapter;
	}

}