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
            UseSSL = false;
            Port = 555;
        }

        [Visible, Category("Интеграция"), Description("Пользователь"), DisplayName("Логин"), Order(0)]
        public string User { get; set; }

        [Visible, Category("Интеграция"), Description("Пароль"), DisplayName("Пароль"), Order(1)]
        public string Password { get; set; }

        [Visible, Category("Интеграция"), Description("Адрес сервера"), DisplayName("Сервер"), Order(2)]
        public string Host { get; set; }

        [Visible, Category("Интеграция"), Description("Порт"), DisplayName("Порт"), Order(3)]
        public int Port { get; set; }

        [Visible, Category("Интеграция"), Description("Использовать SSL"), DisplayName("SSL"), Order(4)]
        public bool UseSSL { get; set; }
    }
}