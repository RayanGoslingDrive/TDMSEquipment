using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Tdms.Api;
using Tdms.Api.Base;
using Tdms.Api.Ui.Controls;
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
    [TdmsApiCommand("CMD_PASSWORD", description: "добавить пароль", roles: "SYSADMIN")]
    public class PasswordCommand : CommandBase
    {
        private readonly TDMSObject ThisObject;
        TDMSApplication App;
        private string correctPassword = "primer";
                public bool passwordWasCorrect = false;
        private TDMSObject passObject = null;
        private byte[] IV =
{
    0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
    0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
};

        public PasswordCommand(TDMSApplication app, TDMSObject thisObject)
            : base(app)
        {
            App = app;
            ThisObject = thisObject;
        }

        public void Execute()
        {
            string pass ="";
            // Open the text file using a stream reader.
            try
            {
                using StreamReader reader = new("C:\\Users\\student\\Documents\\files\\pas");

                // Read the stream as a string.
                pass = reader.ReadToEnd();
            }
            catch { }
/*
            TDMSInputForm pre_form = App.InputForms["FORM_PREPASS"];
            pre_form.Show();
            try
            {
                pass = pre_form.Controls["ATTR_PASSWORD"].Value.ToString();   
            }
            catch
            {
            }*/
            if (pass == correctPassword)
            {


                Find(App.Root);
            
                TDMSInputForm preform = App.InputForms["FORM_PASSWORDS"];
                foreach (TDMSTableAttributeRow row in passObject.Attributes["ATTR_USER-PASS_TABLE"].Rows)
                {
                    TDMSTableAttributeRow formRow = preform.Attributes["ATTR_USER-PASS_TABLE"].Rows.Create();
                    for (int i = 0; i < formRow.Attributes.Count; i++)
                    {

                        using (Aes aes = Aes.Create())
                        {
                            aes.Key = GenerateKey("asd", 256 / 8);
                            aes.IV = GenerateKey("asd", 128 / 8);
                            aes.Padding = PaddingMode.PKCS7;
                            var encryptedstring = row.Attributes[i].Value.ToString();
                            List<int> values = new List<int>();
                            string[] strings = encryptedstring.Split("-");
                            byte[] data = new byte[strings.Length];
                            for (global::System.Int32 j = 0; j < strings.Length; j++)
                            {
                                data[j] = Convert.ToByte(strings[j]);
                            }
                            var encryptedstringasbytes = System.Text.Encoding.ASCII.GetBytes(encryptedstring);
                            var decryptedMessage = DecryptString(data, aes.Key, aes.IV, aes.Padding);
                            formRow.Attributes[i].Value = System.Text.Encoding.ASCII.GetString(decryptedMessage);
                        }

                        //formRow.Attributes[i].Value = row.Attributes[i].Value;
                    }
                }

                if (preform.Show() == true)
                {
                    passObject.Attributes["ATTR_USER-PASS_TABLE"].Rows.RemoveAll();
                    foreach (TDMSTableAttributeRow row in preform.Attributes["ATTR_USER-PASS_TABLE"].Rows)
                    {
                        TDMSTableAttributeRow newrow = passObject.Attributes["ATTR_USER-PASS_TABLE"].Rows.Create();
                        for (int i = 0; i < newrow.Attributes.Count; i++)
                        {
                            string str = "";
                            using (Aes aes = Aes.Create())
                            {
                                aes.Key = GenerateKey("asd", 256 / 8);
                                aes.IV = GenerateKey("asd", 128 / 8);
                                aes.Padding = PaddingMode.PKCS7;
                                var valuestring = row.Attributes[i].Value.ToString();
                                var valuestringasbytes = System.Text.Encoding.ASCII.GetBytes(valuestring);
                                var encryptedMessage = EncryptString(valuestring, aes.Key, aes.IV, aes.Padding);
                                for (global::System.Int32 j = 0; j < encryptedMessage.Length; j++)
                                {

                                    List<int> ints = new List<int>();

                                    if (j == encryptedMessage.Length - 1)
                                    {
                                        str += encryptedMessage[j];
                                    }
                                    else { str += encryptedMessage[j] + "-"; }
                                }
                                newrow.Attributes[i].Value = str;
                            }

                            //newrow.Attributes[i].Value = row.Attributes[i].Value;
                        }
                    }
                }
               /* for (int i = 0; i < passObject.Attributes["ATTR_USER-PASS_TABLE"].Rows.Count; i++)
                {

                    for (int j = 0; j < passObject.Attributes["ATTR_USER-PASS_TABLE"].Rows[i].Attributes.Count; j++)
                    {
                        using (Aes aes = Aes.Create())
                        {
                            aes.Key = Hash("asd");
                            aes.IV = IV;
                            aes.Padding = PaddingMode.PKCS7;
                            var decryptedMessage = EncryptString(System.Text.Encoding.ASCII.GetBytes(row.Attributes[i].Value.ToString()), aes.Key, aes.IV, aes.Padding);
                            passObject.Attributes["ATTR_USER-PASS_TABLE"].Rows[i].Attributes[j].Value = System.Text.Encoding.ASCII.GetString(decryptedMessage);
                        }
                        var encrypted = EncryptString(passObject.Attributes["ATTR_USER-PASS_TABLE"].Rows[i].Attributes[j].Value.ToString(), Hash("asd"), IV);
                        string asd = System.Text.Encoding.ASCII.GetString(encrypted);
                        passObject.Attributes["ATTR_USER-PASS_TABLE"].Rows[i].Attributes[j].Value = asd;
                    }
                }*/

            }

        }

        public void Find(TDMSObject thisobj)
        {
            foreach (var treeElement in thisobj.Objects)
            {
                if (treeElement.ObjectDefName == "OBJECT_PASS")
                {
                    passObject = treeElement;
                    break;
                    
                }
                else{
                    Find(treeElement);
                }
            }
        }

        public byte[] Hash(string str)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(str);
            data = new System.Security.Cryptography.HMACSHA256().ComputeHash(data);
            return data;
        }

        public static byte[] EncryptString(string plainText, byte[] key, byte[] iv,PaddingMode paddingMode)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                aes.Padding = paddingMode;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                byte[] encryptedData = encryptor.TransformFinalBlock(Encoding.UTF8.GetBytes(plainText), 0, plainText.Length);
                encryptor.Dispose();

                return encryptedData;
            }
        }
        public static byte[] GenerateKey(string pass,int size)
        {
            
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] key = Encoding.UTF8.GetBytes(pass);
                byte[] hash = sha256.ComputeHash(key);
                Array.Resize(ref hash, size);
                return hash;

            }
        }

        public static byte[] DecryptString(byte[] encryptedData, byte[] key, byte[] iv , PaddingMode paddingMode)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                aes.Padding = paddingMode;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                byte[] decryptedData = decryptor.TransformFinalBlock(encryptedData, 0, encryptedData.Length);
                decryptor.Dispose();

                return decryptedData;
            }
        }
    }
}