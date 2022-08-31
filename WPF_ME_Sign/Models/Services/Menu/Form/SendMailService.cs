﻿using DocumentFormat.OpenXml.Wordprocessing;
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

        public static bool SendEmailViaOutlook(string fromAddress, ObservableCollection<string> toAddress, string title, string content, ObservableCollection<string> fileList)
        {
            bool bRes = false;

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
                    foreach (string strPath in fileList)
                    {
                        if (File.Exists(strPath))
                        {
                            newMail.Attachments.Add(strPath);
                        }
                        else
                            throw new Exception("Attachment file is not found: \"" + strPath + "\"");
                    }
                }

                //Add title
                if (!string.IsNullOrWhiteSpace(title))
                    newMail.Subject = title;

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
                    bRes = true;
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

            return bRes;
        }
    }
}