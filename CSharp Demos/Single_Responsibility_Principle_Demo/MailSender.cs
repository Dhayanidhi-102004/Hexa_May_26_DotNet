using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Single_Responsibility_Principle_Demo
{
    internal class MailSender
    {
        public string EMailFrom { get; set; }
        public string EmailTo  { get; set; }
        public string EmailSubject  { get; set; }
        public string EmailBody { get; set; }

        public void SendEmail()
        {

        }

    }
}
