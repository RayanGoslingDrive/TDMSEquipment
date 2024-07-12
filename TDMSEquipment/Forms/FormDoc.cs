using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Tdms.Api;
using Tdms.Api.Ui.Controls;
using Tdms.Data;
using Tdms.Web.DTO;
using TDMSEquipment;

namespace TDMSWebExtension1.Form
{
    [TdmsApi("FORM_DOCUMENTATION")]
    public class Form1
    {
        private readonly TDMSApplication _application;
        private readonly TDMSInputForm _form;
        private readonly TDMSObject _object;

        public Form1(TDMSApplication application, TDMSInputForm form, TDMSObject thisObject)
        {
            _form = form;
            _application = application;
            _object = thisObject;

        }
        public void Form_BeforeShow(TDMSInputForm form, TDMSObject thisObject)
        {
            ((TDMSEditCtrl)form.Controls["ATTR_TEXT"]).Markdown = true;

            if (form.ParentWindowType == TDMSWindowType.tdmsWindowTypePreviewDialog)
            {
                form.Controls["BUTTON_MAKE_AS_DOC"].Visible = false;
                form.Controls["BUTTON_MAKE_AS_PAGE"].Visible = false;
                
            }
            


        }

        public void BUTTON_MAKE_AS_DOC_OnClick()
        {
            _form.Controls["ATTR_TEXT"].Value = "";
            _form.Controls["ATTR_DOC_TITLE"].Value = "";
            _form.Controls["T_ATTR_DOC_TITLE"].Value = "Наименование документации";
            _form.Controls["BUTTON_MAKE_AS_DOC"].Enabled = false;
            _form.Controls["BUTTON_MAKE_AS_PAGE"].Enabled = true;
        }
        public void BUTTON_MAKE_AS_PAGE_OnClick()
        {
            _form.Controls["ATTR_TEXT"].Value = "";
            _form.Controls["ATTR_DOC_TITLE"].Value = "";
            _form.Controls["T_ATTR_DOC_TITLE"].Value = "Наименование страницы документации";
            _form.Controls["BUTTON_MAKE_AS_DOC"].Enabled = true;
            _form.Controls["BUTTON_MAKE_AS_PAGE"].Enabled = false;
        }

        public void BUTTON_EDIT_SELECTED_OnClick()
        {
           
        }

    }
}
