using System.IO;
namespace condition3
{
    class Program
    {
        static StreamWriter streamWriter = new StreamWriter(new FileStream(@"D:\condition3.json", FileMode.OpenOrCreate, FileAccess.Write));
        static long[,] total = new long[35, 2];
        static string[] statename = new string[35];
        static void csvreader(StreamReader sr)
        {
            string[] header1 = sr.ReadLine().Split(',');
            int i = 1, j = 0;
            while (!sr.EndOfStream)
            {
                string[] values1 = sr.ReadLine().Split(',');
                if (values1[4] == "Total" && values1[5] == "All ages" && int.Parse(values1[1]) == i)
                {
                    total[j, 0] += long.Parse(values1[9]);
                    total[j, 1] += long.Parse(values1[12]);
                    statename[j] = values1[3];
                    j++;
                    i++;
                }
            }
        }
        static void Main(string[] args)
        {
            csvreader(new StreamReader(new FileStream(@"D:\India2011.csv", FileMode.Open, FileAccess.Read)));
            csvreader(new StreamReader(new FileStream(@"D:\IndiaSC2011.csv", FileMode.Open, FileAccess.Read)));
            csvreader(new StreamReader(new FileStream(@"D:\IndiaST2011.csv", FileMode.Open, FileAccess.Read)));
            streamWriter.WriteLine("[");
            for (int i = 0; i < 35; i++)
            {
                streamWriter.WriteLine("{ \r\n" + "\"" + "Area" + "\"" + " : " + "\""+statename[i] +"\","+"\r\n"+"\"Total_Illiterate_Persons\"" + " : " + total[i, 0] + ",\r\n" + "\"Total_literate_Persons\"" + " : " + total[i, 1] );
                if (i == 34) streamWriter.WriteLine("}");
                else
                    streamWriter.WriteLine("},");
            }
            streamWriter.WriteLine("]");
            streamWriter.Flush();
        }
    }
}
