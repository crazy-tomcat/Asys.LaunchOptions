namespace Asys.LaunchOptions
{
    /// <summary>
    /// Тип опции
    /// </summary>
    public enum LaunchAttributeType
    {
        /// <summary>
        /// Параметр с именем и значением в виде /name=value
        /// </summary>
        Parameter,

        /// <summary>
        /// Переключатель вида -switch
        /// </summary>
        Switch
    }
}
