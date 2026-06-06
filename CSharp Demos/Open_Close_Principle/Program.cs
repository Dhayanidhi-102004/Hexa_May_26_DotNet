namespace Open_Close_Principle
{
    internal class Program
    {

        /// <summary>
        /// It states that software entities (such as modules, classes, functions, etc.) should be open for extension but closed for modification
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Invoice Amount : 10000");
            Invoice FInvoice = new FinalInvoice();
            double FInvoideAmount = FInvoice.GetInvoiceDiscount(10000);
            Console.WriteLine($" Final Invoice : {FInvoideAmount} ");

            Invoice PInvoice = new ProposedInvoice();
            double PInvoiceAmount = PInvoice.GetInvoiceDiscount(10000);
            Console.WriteLine($" Proposed Invoice : {PInvoiceAmount} ");

            Invoice RInvoice = new FinalInvoice();
            double RInvoideAmount = FInvoice.GetInvoiceDiscount(10000);
            Console.WriteLine($" Recurring Invoice : {FInvoideAmount} ");
            Console.ReadLine();
        }

        //public class Invoice
        //{
        //    public double GetInvoiceDiscount(double amount, InvoiceType invoiceType)
        //    {
        //        double finalAmount = 0;
        //        if (invoiceType == InvoiceType.FinalInvoice)
        //        {
        //            finalAmount = amount - 100;
        //        }
        //        else if (invoiceType == InvoiceType.ProposedInvoice)
        //        {
        //            finalAmount = amount - 50;
        //        }
        //        return finalAmount;
        //    }
        //}

        public class Invoice
        {
            public virtual double GetInvoiceDiscount(double amount)
            {
                return amount - 10;
            }
        }

        public class FinalInvoice : Invoice
        {
            public override double GetInvoiceDiscount(double amount)
            {
                return base.GetInvoiceDiscount(amount)-50;
            }
        }
        public class ProposedInvoice : Invoice
        {
            public override double GetInvoiceDiscount(double amount)
            {
                return base.GetInvoiceDiscount(amount) - 40;
            }
        }
        public class RecurringInvoice : Invoice
        {
            public override double GetInvoiceDiscount(double amount)
            {
                return base.GetInvoiceDiscount(amount) - 30;
            }
        }


        public enum InvoiceType
        {
            FinalInvoice,
            ProposedInvoice

        };
    }
}
