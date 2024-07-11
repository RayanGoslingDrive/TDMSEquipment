using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tdms;
using Tdms.Api;
using Tdms.Data;
using Tdms.Web.DTO;
using Tdms.Web.Events;

namespace TDMSEquipment
{
    /// <summary>
    /// Расширенный обработчик контекстного меню 
    /// </summary>
    public class WebConfigurationMenuEventHandler : IEventHandler<WebConfigurationMenuEvent>
    {
        private readonly TDMSApplication ThisApplication;

        public WebConfigurationMenuEventHandler(TDMSApplication app)
        {
            ThisApplication = app;
        }

        public Task Handle(WebConfigurationMenuEvent notification, CancellationToken cancellationToken)
        {
            var selector = notification.Selector;
            if (selector.SysId != "TDMS_TOOLBAR_OBJECT") return Task.CompletedTask;
            var commandItems = notification.CommandItems;
            TDMSCommand cmd = ThisApplication.Commands["CMD_PASSWORD"];
            long id = cmd.Icon.InternalObject.IconId;
            CommandItem item = new CommandItem { Description = cmd.Description, SysId = cmd.SysName, IconId = id.ToString() };
            commandItems.Add(item);
            if (selector.SysId != "TDMS_TOOLBAR_OBJECT") return Task.CompletedTask;
            var commandItems1 = notification.CommandItems;
            TDMSCommand cmd1 = ThisApplication.Commands["CMD_COMMAND_ADD_DOC"];
            long id1 = cmd1.Icon.InternalObject.IconId;
            CommandItem item1 = new CommandItem { Description = cmd1.Description, SysId = cmd1.SysName, IconId = id1.ToString() };
            commandItems.Add(item1);
            return Task.CompletedTask;
        }
    }
}
