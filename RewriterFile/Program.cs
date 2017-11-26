using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace RewriterFile
{
    class Program
    {
        private const string FILE_NAME = "original.txt";
        private const string OUTPUT_FILE_NAME = "result.txt";

        private const string REGEX_DATE_EXPRESSION = "[0-9]{2}/[0-9]{2}/[0-9]{1,4}";

        static void Main(string[] args)
        {

            try
            {
                string originalContext = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FILE_NAME));

                Regex regex = new Regex(REGEX_DATE_EXPRESSION);
                MatchCollection matches = regex.Matches(originalContext);

                string newContext = string.Empty;
                foreach(Match match in matches)
                {
                    newContext += string.Format("{0}{1}", match.Value, Environment.NewLine);
                }

                if(string.IsNullOrEmpty(newContext))
                {
                    newContext = "No date was found";
                }

                string resultFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, OUTPUT_FILE_NAME);
                File.WriteAllText(resultFileName, newContext);
                Console.WriteLine("Finish");
            }
            catch (Exception ex)
            {
                Console.WriteLine("oops Error: {0}", ex);
            }

            Console.ReadLine();
        }
    }
}
