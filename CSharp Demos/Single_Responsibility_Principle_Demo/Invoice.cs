using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Single_Responsibility_Principle_Demo
{
    internal class Invoice
    {
        public long  InvoiceAmount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public ILogger fileLogger { get; set; }
        public MailSender emailSender;

        public void AddInvoice()
        {
            try
            {
                fileLogger.Info("Add Method start");
                emailSender.EMailFrom = "abc@mail.com";
                emailSender.EmailTo = "xyz@mail.com";
                emailSender.EmailSubject = "Sampole Single Responsibility Principle";
                emailSender.EmailBody = " A Class should have only one reason to change";
                emailSender.SendEmail();

              }
            catch (Exception ex)
            {
                fileLogger.Error("Error Occured while generating Invoice", ex);
            }


        }

        public void DeleteInvoice()
        {
            try
            {
                fileLogger.Info("Delte Invoice Start @ " + DateTime.Now);
            }
            catch (Exception ex)
            {
                fileLogger.Error("Error Occured during Deleting inovice",ex);
            }

        }
        //public void AddInvoice()
        //{
        //    try
        //    {
        //        MailMessage mailMesage = new MailMessage("EmailFrom", "EmailTo", "EmailSubject", "EmailBody");
        //        this.SendInvoiceMail(mailMesage);
        //    }
        //    catch (Exception ex)
        //    {
        //        File.WriteAllText(@"C:\\Temp\\ErrorLog.txt", ex.ToString());
        //    }


        //}

        //public void DeleteInvoice()
        //{
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {
        //        File.WriteAllText(@"C:\\Temp\\ErrorLog.txt", ex.ToString());
        //    }

        //}

        //public void SendInvoiceMail(MailMessage mailMessage)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {
        //        File.WriteAllText(@"C:\\Temp\\ErrorLog.txt", ex.ToString());
        //    }

        //}
    }
}
