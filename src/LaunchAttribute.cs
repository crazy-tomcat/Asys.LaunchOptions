using System;

namespace Asys.LaunchOptions
{
	/// <summary>
	/// Attribute indicating that this property is extracted from launch parameters.<br/>
	/// ---<br/>
	/// Атрибут обозначающий, что данное свойство извлекается из параметров запуска.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class LaunchAttribute : Attribute
	{
		public LaunchAttribute(LaunchAttributeType type)
		{
			Type = type;
		}

		public LaunchAttributeType Type { get; }

		/// <summary>
		/// Overrides the parameter name. If Name is not specified, the property name will be used.<br/>
		/// ---<br/>
		/// Переопределяет название параметра. Если не задать Name, то будет использоваться имя свойства.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Description displayed in help output.<br/>
		/// ---<br/>
		/// Описание, которое выводится в help.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Indicates whether the parameter is required. If the parameter is missing, an exception will be thrown.<br/>
		/// ---<br/>
		/// Является обязательным. Если параметр не указан, то будет сгененировано исключение.
		/// </summary>
		public bool IsRequired { get; set; }
	}
}
