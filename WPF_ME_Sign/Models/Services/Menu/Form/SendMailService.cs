using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using WPF_ME_Sign.Models.Repositories.Menu.Form;
using System.Windows;

namespace WPF_ME_Sign.Models.Services.Menu.Form
{
    public class SendMailService
    {
        SendMailRespository _sendMailRespository;

        public SendMailService()
        {
            _sendMailRespository = new SendMailRespository();
        }

        public void OpenFile(string filePath)
        {
            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        }

        public ObservableCollection<string> GetToAddress() => _sendMailRespository.LoadMailList();

        public bool SentToMail(MailModel mail)
        {
            return SendEmailViaOutlook(mail.FromAddress, mail.ToAddress, mail.Title, mail.Content, mail.FileList);
        }

        public static bool SendEmailViaOutlook(string fromAddress, ObservableCollection<string> toAddress, string title, string content, ObservableCollection<FileModel> fileList)
        {
            bool result = false;

            try
            {
                //Get Outlook COM objects
                Outlook.Application app = new Outlook.Application();
                Outlook.MailItem newMail = (Outlook.MailItem)app.CreateItem(Outlook.OlItemType.olMailItem);

                foreach (string str in toAddress)
                {
                    if (!String.IsNullOrEmpty(str))
                    {
                        newMail.Recipients.Add(str);
                    }
                }

                //Resolve all recepients
                if (!newMail.Recipients.ResolveAll())
                {
                    throw new Exception("Failed to resolve all recipients: " + toAddress + ";");
                }

                if (fileList != null)
                {
                    //Add attachments
                    foreach (var strPath in fileList)
                    {
                        if (File.Exists(strPath.FileName))
                        {
                            newMail.Attachments.Add(strPath.FileName);
                        }
                        else
                            throw new Exception("Attachment file is not found: \"" + strPath + "\"");
                    }
                }

                //Add title
                if (!string.IsNullOrWhiteSpace(title)) newMail.Subject = title;

                if (!string.IsNullOrWhiteSpace(content)) newMail.Body = content;


                Outlook.Accounts accounts = app.Session.Accounts;
                Outlook.Account acc = null;

                //Look for our account in the Outlook
                foreach (Outlook.Account account in accounts)
                {
                    if (account.SmtpAddress.Equals(fromAddress, StringComparison.CurrentCultureIgnoreCase))
                    {
                        //Use it
                        acc = account;
                        break;
                    }
                }

                //Did we get the account
                if (acc != null)
                {
                    //Use this account to send the e-mail. 
                    newMail.SendUsingAccount = acc;

                    //And send it
                    ((Outlook._MailItem)newMail).Send();

                    //Done
                    result = true;
                }
                else
                {
                    throw new Exception("Account does not exist in Outlook: " + fromAddress);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: Failed to send mail: " + ex.Message);
            }

            return result;
        }

        public bool FileSizeLimit(string file)
        {
            FileInfo fi = new FileInfo(file);
            decimal i = 0;
            i = Convert.ToInt32(fi.Length.ToString());
            decimal d = 0;
            d = i / (1024 * 1024); //1024*1024 Kb đổi sang Mb

            if (d > 20)
            {
                MessageBox.Show("The software only supports up to 20Mb. Please change size of file!", "Notification", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }
    }
}
