using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tdms.Api;
using TDMSEquipment;

namespace TDMSWebExtension1.Form
{
    [TdmsApi("FORM_PREPASS")]
    public class FormPrePass
    {
        private readonly TDMSApplication _application;
        private readonly TDMSInputForm _form;

        public FormPrePass(TDMSApplication application, TDMSInputForm form)
        {
            _form = form;
            _application = application;

        }

        public void Form_BeforeShow(TDMSInputForm form, TDMSObject thisObject)
        {
            //2-filsizemin 3-filsizemax 6-minobjcount 7-maxobjcount 10-min folders 11-maxfolders 14-dept

        }

        public void Close()
        {

        }
    }
}
