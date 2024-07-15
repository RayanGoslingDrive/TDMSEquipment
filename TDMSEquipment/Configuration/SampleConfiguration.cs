using System.ComponentModel;
using Tdms;

namespace TDMSEquipment
{
    /// <summary>
    /// Класс конфигурации, имеет имя такое же как имя dll с добавлением Configuration.<br/>
    /// Можно помещать настройки для текущего расширения.
    /// </summary>
    [ModuleConfiguration]
    public class SampleConfiguration
    {
        public SampleConfiguration()
        {
            PasswordPath = "";
        }

        [Visible, Category("Интеграция"), Description("Файл с Паролем"), DisplayName("Файл с Паролем"), Order(0)]
        public string PasswordPath { get; set; }

    }
}