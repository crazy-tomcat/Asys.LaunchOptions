namespace Asys.LaunchOptions
{
	/// <summary>
	/// Type of the launch option.<br/>
	/// ---<br/>
	/// Тип опции.
	/// </summary>
	public enum LaunchAttributeType
	{
		/// <summary>
		/// A parameter with a name and value in the format /name=value.<br/>
		/// ---<br/>
		/// Параметр с именем и значением в виде /name=value.
		/// </summary>
		Parameter,

		/// <summary>
		/// A switch in the form -switch.<br/>
		/// ---<br/>
		/// Переключатель вида -switch.
		/// </summary>
		Switch
	}
}