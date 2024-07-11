using System.Threading;
using System.Threading.Tasks;
using Tdms;
using Tdms.Api;
using Tdms.Web.DTO;
using Tdms.Web.Events;

namespace TDMSEquipment
{
    /// <summary>
    /// Обработчик события загрузки конфигурации WebConfiguration
    /// </summary>
    public class ConfigurationEventHandler : IEventHandler<WebConfigurationLoadEvent>
    {
        public ConfigurationEventHandler()
        {

        }

        public Task Handle(WebConfigurationLoadEvent notification, CancellationToken cancellationToken)
        {
            WebConfiguration config = notification.Configuration;

            var newPage = new WebConfigurationPage()
            {
                Xclass = "tdms.view.panels.IFramePage",
                Caption = "АРМ ГИПа",
                Root = "armgip",
                Persistent = false
            };

#if DEBUG
            newPage.Src = "http://localhost:3000";
#else
            newPage.Src = "/ArmGip/index.html",
            #endif

            config.MainTabs.Add(newPage);

            return Task.CompletedTask;
        }
    }
}