using System;
using System.IO;

namespace TxtCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter sw = new StreamWriter(@"C:\ArquivoEditavel\newText.txt");

            for (int i = 1; i <= 50000; i++)
            {
                GenericObject ge = new GenericObject { Id = i, Name = i % 2 == 0 ? "Luan" : "Lucas" };
                sw.WriteLine("{");
                sw.WriteLine($" \"id\": {ge.Id},");
                sw.WriteLine($" \"name\": \"{ge.Name}\"");
                if (i < 50000)
                {
                    sw.WriteLine("},");
                }
                else {
                    sw.WriteLine("}");
                }
            }
            sw.Close();

            StreamReader sr = new StreamReader(@"C:\ArquivoEditavel\newText.txt");
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (line.StartsWith(" \"id\""))
                {
                    var y = line.Length;
                    var count = line.Substring(7, y - 7);
                    var final = count.Substring(0, count.Length - 1);
                    Console.WriteLine(final.ToString());
                }
            }
            sr.Close();
        }
    }
}
