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
        public bool passwordWasCorrect = false;
        private string correctPassword = "asd";
        private List<int> rowsCount = new List<int>();
        public FormPass(TDMSApplication application, TDMSInputForm form)
        {
            _form = form;
            _application = application;

        }
        //((TDMSEditCtrl)pre_form.Controls["ATTR_PASSWORD"]).Markdown = true;
        //можно использовать окно сообщений для проверки был ли единожды введен пароль
        // вывести создание документации на отдельные кнопки
        //aes ключ
        //пароль админа знает только админ
        //ключ лежит на диске
        public void Form_BeforeShow(TDMSInputForm form, TDMSObject thisObject)
        {
            if(form.ParentWindowType != TDMSWindowType.tdmsWindowTypeSingleForm)
                form.Controls["ATTR_USER-PASS_TABLE"].Visible = false;
            else
                form.Controls["ATTR_USER-PASS_TABLE"].Visible = true;
        }
        /*
                public void Form_TableAttributeChange(TDMSInputForm Form,TDMSObject Object,TDMSTableAttribute TableAttribute,TDMSTableAttributeRow TableRow,TDMSAttributeDef ColumnAttributeDefName, TDMSTableAttributeRow OldTableRow,TDMSButtonCtrl Cancel)
                {

                }*/
        /*table.Table.SetCellValue(table.Table.Rows.Count - 1, 0, Encrypt(table.Table.CellValue(table.Table.Rows.Count,0).ToString(),"a"));
            table.Table.SetCellValue(table.Table.Rows.Count - 1, 1, Encrypt(table.Table.CellValue(table.Table.Rows.Count, 1).ToString(), "a"));
        Encrypt(((TDMSGridCtrl)_form.Controls["ATTR_USER-PASS_TABLE"]).GetCellValue(rowCount-1, 1).ToString(), "a")
         */

        public void Form_TableAttributeRowAdded(TDMSInputForm form, TDMSObject Object, TDMSTableAttribute TableAttribute, TDMSTableAttributeRow TableRow)
        {
            rowsCount.Add(((TDMSGridCtrl)_form.Controls["ATTR_USER-PASS_TABLE"]).RowCount - 1);
        }

        public void OK_OnClick()
        {


               // object encryptedUser = Encrypt(((TDMSGridCtrl)_form.Controls["ATTR_USER-PASS_TABLE"]).GetCellValue(i, 0).ToString(), "a");
               // object encryptedPassword = Encrypt(((TDMSGridCtrl)_form.Controls["ATTR_USER-PASS_TABLE"]).GetCellValue(i, 1).ToString(), "a");

               // ((TDMSGridCtrl)_form.Controls["ATTR_USER-PASS_TABLE"]).SetCellValue(i, 0, encryptedUser);
               // ((TDMSGridCtrl)_form.Controls["ATTR_USER-PASS_TABLE"]).SetCellValue(i, 1, encryptedPassword);


        }

      
        public void Close()
        {

        }
    }
}
