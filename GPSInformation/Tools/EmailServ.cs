﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace GPSInformation.Tools
{
    public class EmailServ
    {
        #region Propiedades
        private string Server { get; set; }
        private string Account { get; set; }
        private string Port { get; set; }
        private string User { get; set; }
        private string Password { get; set; }
        private bool ActiveSSL { get; set; }

        public List<string> ListTo { get; set; }
        public List<string> ListCC { get; set; }
        public List<string> ListBCC { get; set; }
        public List<string> ListReply { get; set; }

        private List<FileInfo> Attachments { get; set; }
        private MailMessage Email { get; set; }
        private MailPriority MailPryority_ { get; set; }
        private SmtpClient SmtpClient_ { get; set; }
        private Attachment Attachment_ { get; set; }
        private readonly string PathScript = @"C:\Splittel\GestionPersonal\Scripts\ManualEmail.ps1";
        private readonly string PathText = @"C:\Splittel\GestionPersonal\Scripts\DraftEmailManual.txt";
        #endregion

        #region Contructores
        public EmailServ(string Server, string Account, string Port, string User, string Password, bool ActiveSSL)
        {
            this.Server = Server;
            this.Account = Account;
            this.Port = Port;
            this.User = User;
            this.Password = Password;
            this.Password = Password;
        }
        #endregion

        #region Metodos
        private void CreateScript(string Body, string SubJec)
        {
            string ScriptPS = File.ReadAllText(PathText);
            ScriptPS = ScriptPS.Replace("@Server", this.Server);
            ScriptPS = ScriptPS.Replace("@Accout", this.Account);
            ScriptPS = ScriptPS.Replace("@Subject", SubJec);
            ScriptPS = ScriptPS.Replace("@IsHtml", true ? "true" : "false");
            ScriptPS = ScriptPS.Replace("@Body", Body.Replace("#","'#"));
            ScriptPS = ScriptPS.Replace("@Password", this.Password);
            ScriptPS = ScriptPS.Replace("@Port", this.Port + "");
            ScriptPS = ScriptPS.Replace("@SSL", this.ActiveSSL ? "true" : "false");

            string DireccionesTo = "";
            string DireccionesCC = "";
            string DireccionesBcc = "";
            string DireccionesReply = "";

            if (ListReply != null)
            {
                ListReply.ForEach(a => DireccionesReply += $"$Email.ReplyToList.Add('{a}');");
            }
            if (ListBCC != null)
            {
                ListBCC.ForEach(a => DireccionesBcc += $"$Email.Bcc.Add('{a}');");
            }
            if (ListCC != null)
            {
                ListCC.ForEach(a => DireccionesCC += $"$Email.CC.Add('{a}');");
            }
            if (ListTo != null)
            {
                ListTo.ForEach(a => DireccionesTo += $"$Email.To.Add('{a}');");
            }
            ScriptPS = ScriptPS.Replace("@DireccionesTo", DireccionesTo);
            ScriptPS = ScriptPS.Replace("@DireccionesCC", DireccionesCC);
            ScriptPS = ScriptPS.Replace("@DireccionesBcc", DireccionesBcc);
            ScriptPS = ScriptPS.Replace("@DireccionesReply", DireccionesReply);

            StreamWriter sw = new StreamWriter(PathScript, false, System.Text.Encoding.GetEncoding(1252));
            sw.Write(ScriptPS);
            sw.Close();
        }
        public void Senda(string Body, string SubJec)
        {
            CreateScript(Body, SubJec);
            var startInfo = new ProcessStartInfo()
            {
                FileName = "powershell.exe",
                Arguments = $"-NoProfile -ExecutionPolicy unrestricted \"{PathScript}\"",
                UseShellExecute = false
            };
            Process.Start(startInfo);
        }
        public void Send(string Body, string SubJect)
        {
            try
            {
                this.Email = new MailMessage();
                this.SmtpClient_ = new SmtpClient(this.Server);
                Email.From = new MailAddress(this.Account.Trim());
                Email.IsBodyHtml = true;
                Email.Subject = SubJect;
                Email.Priority = MailPriority.Normal;

                if (ListReply != null)
                {
                    ListReply.ForEach(a => Email.ReplyToList.Add(a));
                }
                if (ListBCC != null)
                {
                    ListBCC.ForEach(a => Email.Bcc.Add(a));
                }
                if (ListCC != null)
                {
                    ListCC.ForEach(a => Email.CC.Add(a));
                }
                if (ListTo != null)
                {
                    ListTo.ForEach(a => Email.To.Add(a));
                }

                SmtpClient_.Port = int.Parse(this.Port);
                SmtpClient_.Credentials = new System.Net.NetworkCredential(this.User, this.Password);
                SmtpClient_.EnableSsl = ActiveSSL;
                Email.Body = Body;
                SmtpClient_.Send(Email);
            }
            catch (SmtpFailedRecipientException ex)
            {
                SmtpStatusCode statusCode = ex.StatusCode;

                if (statusCode == SmtpStatusCode.MailboxBusy || statusCode == SmtpStatusCode.MailboxUnavailable || statusCode == SmtpStatusCode.TransactionFailed)
                {
                    SmtpClient_.Send(Email);
                }
                else
                {
                    throw ex;
                }
            }
            catch (SmtpException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                Email.Dispose();

            }
        }

        public void AddListReply(string correos)
        {
            if (ListReply == null)
                ListReply = new List<string>();

            GetEmails(correos).ForEach(a =>
            {
                if (!IsValidEmail(a))
                {
                    Funciones.EscribeLog(string.Format("El correo '{0}' no es valido para destinatario reply", a));
                    //throw new Exceptions.GpExceptions();
                }
                else
                {
                    ListReply.Add(a);
                }
            });
        }

        public void AddListBCC(string correos)
        {
            if (ListBCC == null)
                ListBCC = new List<string>();

            GetEmails(correos).ForEach(a =>
            {
                if (!IsValidEmail(a))
                {
                    Funciones.EscribeLog(string.Format("El correo '{0}' no es valido para destinatario Bcc", a));
                    //throw new Exceptions.GpExceptions();
                }
                else
                {
                    ListBCC.Add(a);
                }
            });
        }

        public void AddListCC(string correos)
        {
            if (ListCC == null)
                ListCC = new List<string>();

            GetEmails(correos).ForEach(a =>
            {
                if (!IsValidEmail(a))
                {
                    Funciones.EscribeLog(string.Format("El correo '{0}' no es valido para destinatario cc", a));
                    //throw new Exceptions.GpExceptions();
                }
                else
                {
                    ListCC.Add(a);
                }
                
            });
        }

        public void AddListTO(string correos)
        {
            if(ListTo == null)
                ListTo = new List<string>();

            GetEmails(correos).ForEach(a =>
            {
                if (!IsValidEmail(a))
                {
                    Funciones.EscribeLog(string.Format("El correo '{0}' no es valido para destinatario To", a));
                    //throw new Exceptions.GpExceptions();
                }
                else
                {
                    ListTo.Add(a);
                }
               
            });
        }

        private bool IsValidEmail(string email)
        {
            bool errorStatus = false;
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                              @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                              @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (!re.IsMatch(email.Trim()))
                errorStatus = false;
            else
            {
                errorStatus = true;
            }
            return errorStatus;
        }
        private List<string> GetEmails(string dataset)
        {
            List<string> list = new List<string>();
            string[] allAddresses = dataset.Split(";,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            foreach (string emailAddress in allAddresses)
            {
                list.Add(emailAddress);
            }

            return list;
        }
        #endregion

    }
}
