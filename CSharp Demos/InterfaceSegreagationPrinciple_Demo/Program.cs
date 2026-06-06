namespace InterfaceSegreagationPrinciple_Demo
{

    /// <summary>
    /// This Principle states Clients should not be forced to implement any methods they don’t use. Rather than one fat interface,
    /// numerous little interfaces are preferred based on groups of methods, with each interface serving one submodule.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            //Using HPLaserJetPrinter we can access all Printer Services
            HPLaserJetPrinter hPLaserJetPrinter = new HPLaserJetPrinter();
            hPLaserJetPrinter.Print("Printing");
            hPLaserJetPrinter.Scan("Scanning");
            hPLaserJetPrinter.Fax("Faxing");
            hPLaserJetPrinter.PrintDuplex("PrintDuplex");
            //Using LiquidInkjetPrinter we can only Access Print and Scan Printer Services
            LiquidInkjetPrinter liquidInkjetPrinter = new LiquidInkjetPrinter();
            liquidInkjetPrinter.Print("Printing");
            liquidInkjetPrinter.Scan("Scanning");
            Console.ReadKey();
        }
    }
}

public interface IPrinterTasks
{
    void Print(string PrintContent);
    void Scan(string ScanContent);
    //void Fax(string FaxContent);
    //void PrintDuplex(string PrintDupluxContent);
}
public interface IFaxTasks
{
    void Fax(string FaxContent);
}
public interface IPrintDuplexTasks
{
    void PrintDuplex(string PrintDupluxContent);
}

public class HPLaserJetPrinter : IPrinterTasks, IFaxTasks, IPrintDuplexTasks
{
    public void Fax(string FaxContent)
    {
        Console.WriteLine("Fax Content");
    }

    public void Print(string PrintContent)
    {
        Console.WriteLine("Print Done");
    }

    public void PrintDuplex(string PrintDupluxContent)
    {
        Console.WriteLine("Print Duplux Content");
    }

    public void Scan(string ScanContent)
    {
        Console.WriteLine("Scan Content");
    }
}

public class LiquidInkjetPrinter : IPrinterTasks
{
    public void Scan(string FaxContent)
    {
        Console.WriteLine("Scan Content");
    }

    public void Print(string PrintContent)
    {
        Console.WriteLine("Print Done");
    }
    //void IPrinterTasks.Fax(string FaxContent)
    //{
    //    throw new NotImplementedException();
    //}



    //void IPrinterTasks.PrintDuplex(string PrintDupluxContent)
    //{
    //    throw new NotImplementedException();
    //}


}