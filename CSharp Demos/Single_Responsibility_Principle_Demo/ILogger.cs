using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Single_Responsibility_Principle_Demo
{
    internal interface ILogger
    {
        void Info(string info);
        void Debud(string info);
        void Error(string message, Exception ex);
    }
    public class Logger : ILogger
    {
        public void Debud(string info)
        {
           // throw new NotImplementedException();
        }

        public void Error(string message, Exception ex)
        {
           // throw new NotImplementedException();
        }

        public void Info(string info)
        {
            //throw new NotImplementedException();
        }
    }
}
