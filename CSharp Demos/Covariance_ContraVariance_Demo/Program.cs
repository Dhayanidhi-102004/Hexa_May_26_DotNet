namespace Covariance_ContraVariance_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Co-variance -> Usedwhen read only and return the data 
            //  List<CreditCardPayment> creditCardPayments = new List<CreditCardPayment>
            //{
            //    new CreditCardPayment{PaymentId=101,Amount=2500,CardNumber="XXXX-1111"},
            //    new CreditCardPayment{PaymentId=102,Amount=3500,CardNumber="XXXX-2222"}
            //};
            //  List<UpiPayment> upiPayments = new List<UpiPayment>
            //{
            //    new UpiPayment{PaymentId=101,Amount=500,UpiId="customer1@upi"},
            //    new UpiPayment{PaymentId=102,Amount=900,UpiId="customer2@upi"}
            //};
            //  PrintPaymentReport(creditCardPayments);
            //  PrintPaymentReport(upiPayments);
            //  Console.ReadLine();

            //  //List<CreditCardPayment> ccPayment=new List<CreditCardPayment>();
            //  //List<Payment> payments = ccPayment; //error 



            //// contra-variance

            //Action<Payment> generalPaymentProcessor = payment =>
            //{
            //    Console.WriteLine($"Processing Payemnt Id : {payment.PaymentId}, Amount : {payment.Amount}");
            //};

            //Action<CreditCardPayment> creditCardProcessor = generalPaymentProcessor;

            //CreditCardPayment creditCardPayment = new CreditCardPayment
            //{
            //    PaymentId = 101,
            //    Amount = 45657,
            //    CardNumber = "XXXX-33333"
            //};

            //creditCardProcessor( creditCardPayment );

        }

        //for covariance
       //public  static void PrintPaymentReport(IEnumerable<Payment> payments)
       // {
       //     foreach (Payment payment in payments)
       //     {
       //         Console.WriteLine($"Payment Id: {payment.PaymentId}, Amount : {payment.Amount}");

       //     }
       // }
    }
}
