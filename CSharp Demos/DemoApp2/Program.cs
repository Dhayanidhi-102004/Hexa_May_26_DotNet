namespace DemoApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine("Number of Arguments : "+args.Length);
            //Console.WriteLine("Arguments Received ");
            //for (int i = 0; i < args.Length; i++)
            //{
            //    Console.WriteLine($" Argument {i} : {args[i]}");
            //}
            //Console.WriteLine("Hello, World!");
           // DatatypesDemo.datatypes_demo();

            //ReadDataFromUser readDataFromUser= new ReadDataFromUser();
            //readDataFromUser.GetDifferentEmployeeDetails();

            // Declare the array of four elements:
            int[][] jaggedArray = new int[4][];

            // Initialize the elements:
            jaggedArray[0] = new int[2] { 7, 9 };
            jaggedArray[1] = new int[4] { 12, 42, 26, 38 };
            jaggedArray[2] = new int[6] { 3, 5, 7, 9, 11, 13 };
            jaggedArray[3] = new int[3] { 4, 6, 8 };

            // Display the array elements:
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                System.Console.Write("Element({0}): ", i + 1);

                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    System.Console.Write(jaggedArray[i][j] + "\t");
                }
                System.Console.WriteLine();
            }
            Console.ReadLine();
            Console.ReadLine();
        }
    }
}
