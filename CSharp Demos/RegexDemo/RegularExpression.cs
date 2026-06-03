using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexDemo
{
    internal class RegularExpression
    {
        public void sampleExpression()
        {
            string email = "student@gmail.co.in";
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            bool isValid = Regex.IsMatch(email, pattern);
            Console.WriteLine(isValid ? "Valid Email" : "Invalid Email");

            // validate username 
            string username = "Student_123";
            bool result = Regex.IsMatch(username, @"^\w{4,15}$");
            Console.WriteLine(result);

            string input = "This is is a test test sentence";
            MatchCollection matches = Regex.Matches(input, @"\b(\w+)\s+\1\b");

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }

            /*
             *
             *^      Start
$      End
\d     Digit
\w     Word character
\s     Space
.      Any character
+      One or more
*      Zero or more
?      Optional
{n}    Exactly n times
[]     Character set
[^]    Not matching set
()     Group
|      OR
\      Escape
             * 
             */
        }
    }
}
