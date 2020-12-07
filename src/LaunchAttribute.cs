using System;

namespace Asys.LaunchOptions
{
    /// <summary>
    /// Атрибут обозначающий что данное свойство извлекается из параметров запуска
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
        /// Переопределяет название параметра. Если не задать Name, то будет использоватся имя свойства
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание, которое выводится в help
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Является обязательным. Если параметр не указан, то будет сгененировано исключение
        /// </summary>
        public bool IsRequired { get; set; }
    }
}
