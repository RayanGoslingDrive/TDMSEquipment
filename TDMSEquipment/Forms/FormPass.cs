using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Tdms.Api;
using Tdms.Api.Ui.Controls;
using Tdms.Data;
using Tdms.Web.DTO;
using TDMSEquipment;
using static System.Net.Mime.MediaTypeNames;

namespace TDMSWebExtension1.Form
{
    [TdmsApi("FORM_PASSWORDS")]
    public class FormPass
    {
        private readonly TDMSApplication _application;
        private readonly TDMSInputForm _form;

        public FormPass(TDMSApplication application, TDMSInputForm form)
        {
            _form = form;
            _application = application;

        }

        public void Form_BeforeShow(TDMSInputForm form, TDMSObject thisObject)
        {
            if(form.ParentWindowType != TDMSWindowType.tdmsWindowTypeSingleForm)
                form.Controls["ATTR_USER-PASS_TABLE"].Visible = false;
            else
                form.Controls["ATTR_USER-PASS_TABLE"].Visible = true;
        }


      
        public void Close()
        {

        }
    }
}
