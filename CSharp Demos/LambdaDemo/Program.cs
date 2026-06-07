namespace LambdaDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
        //    IEnumerable<string> students = new List<string>
        //    {
        //        "Priya","Kamala","Pam","Sam"
        //    };

        //    foreach (var student in students)
        //    {
        //        Console.WriteLine(student);
        //    }

            List<string> students = new List<string>
            {
                "Priya","Kamala","Pam","Sam"
            };

           
            IEnumerator<string> enumerator=students.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }

            /* 
             * MoveNext()
            Current
            Reset();

            */

        }
    }
}
