using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tdms.Api;
using Tdms.Api.Base;
using Tdms.Data;
using Tdms.Tasks;
using TDMSWebExtension1.Form;
using static System.Net.Mime.MediaTypeNames;

namespace TDMSEquipment
{  
    /// <summary>
    /// Демонстрационная команда, которая будет зарегистрирована <br/>
    /// При выполнении команды выполнится метод <see cref="Execute"/>
    /// </summary>
    [TdmsApiCommand("CMD_COMMAND_ADD_DOC", description: "добавить документацию", roles: "SYSADMIN",icon: "44")]
    public class DocAddCommand : CommandBase
    {
        private readonly TDMSObject ThisObject;
        TDMSApplication App;
        public bool passwordWasCorrect = false;

        public DocAddCommand(TDMSApplication app, TDMSObject thisObject)
            : base(app)
        {
            App = app;
            ThisObject = thisObject;
        }
        //пароли зашифрованные
        //
        public void Execute()
        {
            
            
            TDMSInputForm doc = App.InputForms["FORM_DOCUMENTATION"];
            if (doc.Show() == true)
            {
                if (doc.Controls["BUTTON_MAKE_AS_DOC"].Enabled == false)
                {
                    TDMSObject tobj = ThisObject.Content.Create("OBJECT_DOCUMENTATION");
                    tobj.Attributes["ATTR_DOC_TITLE"].Value = doc.Controls["ATTR_DOC_TITLE"].Value;
                    tobj.Attributes["ATTR_TEXT"].Value = doc.Controls["ATTR_TEXT"].Value;
                }
                else if (doc.Controls["BUTTON_MAKE_AS_PAGE"].Enabled == false)
                {
                    TDMSObject tobj = ThisObject.Content.Create("OBJECT_DOC_DIV");
                    tobj.Attributes["ATTR_DOC_TITLE"].Value = doc.Controls["ATTR_DOC_TITLE"].Value;
                    tobj.Attributes["ATTR_TEXT"].Value = doc.Controls["ATTR_TEXT"].Value;
                }
            }
        }
    }
}