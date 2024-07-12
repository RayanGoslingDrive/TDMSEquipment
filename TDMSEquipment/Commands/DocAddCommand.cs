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
    [TdmsApiCommand("CMD_COMMAND_ADD_DOC", description: "Добавить/изменить документацию", roles: "SYSADMIN",icon: "44",objectDefs:"OBJECT_DOCUMENTATION,OBJECT_DOC_DIV,OBJECT_FOLDER")]
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
            doc.Controls["BUTTON_MAKE_AS_DOC"].Enabled = true;
            doc.Controls["BUTTON_MAKE_AS_PAGE"].Enabled = true;
            if(ThisObject.ObjectDefName == "OBJECT_DOC_DIV" || ThisObject.ObjectDefName == "OBJECT_DOCUMENTATION")
            {
                doc.Controls["ATTR_TEXT"].Value = ThisObject.Attributes["ATTR_TEXT"].Value;
                doc.Controls["ATTR_DOC_TITLE"].Value = ThisObject.Attributes["ATTR_DOC_TITLE"].Value;
                if (ThisObject.ObjectDefName == "OBJECT_DOC_DIV")
                {
                    doc.Controls["BUTTON_MAKE_AS_DOC"].Visible = false;
                    doc.Controls["BUTTON_MAKE_AS_PAGE"].Visible = false;
                }
            }
            if (doc.Show() == true)
            { 
                if (doc.Controls["BUTTON_MAKE_AS_DOC"].Enabled == false && (ThisObject.ObjectDefName == "OBJECT_DOC_DIV" || ThisObject.ObjectDefName == "OBJECT_DOCUMENTATION"))
                {
                    TDMSObject tobj = ThisObject.Content.Create("OBJECT_DOCUMENTATION");
                    tobj.Attributes["ATTR_DOC_TITLE"].Value = doc.Controls["ATTR_DOC_TITLE"].Value;
                    tobj.Attributes["ATTR_TEXT"].Value = doc.Controls["ATTR_TEXT"].Value;
                }
                else if (doc.Controls["BUTTON_MAKE_AS_PAGE"].Enabled == false && (ThisObject.ObjectDefName == "OBJECT_DOC_DIV" || ThisObject.ObjectDefName == "OBJECT_DOCUMENTATION"))
                {
                    TDMSObject tobj = ThisObject.Content.Create("OBJECT_DOC_DIV");
                    tobj.Attributes["ATTR_DOC_TITLE"].Value = doc.Controls["ATTR_DOC_TITLE"].Value;
                    tobj.Attributes["ATTR_TEXT"].Value = doc.Controls["ATTR_TEXT"].Value;
                }
                else if (doc.Controls["BUTTON_MAKE_AS_PAGE"].Enabled == true && doc.Controls["BUTTON_MAKE_AS_DOC"].Enabled == true && (ThisObject.ObjectDefName == "OBJECT_DOC_DIV" || ThisObject.ObjectDefName == "OBJECT_DOCUMENTATION"))
                {
                    ThisObject.Attributes["ATTR_DOC_TITLE"].Value = doc.Controls["ATTR_DOC_TITLE"].Value;
                    ThisObject.Attributes["ATTR_TEXT"].Value = doc.Controls["ATTR_TEXT"].Value;
                }else if(ThisObject.ObjectDefName != "OBJECT_DOC_DIV" || ThisObject.ObjectDefName != "OBJECT_DOCUMENTATION")
                {
                    TDMSObject tobj = ThisObject.Content.Create("OBJECT_DOCUMENTATION");
                    tobj.Attributes["ATTR_DOC_TITLE"].Value = doc.Controls["ATTR_DOC_TITLE"].Value;
                    tobj.Attributes["ATTR_TEXT"].Value = doc.Controls["ATTR_TEXT"].Value;
                }
            }
        }
    }
}