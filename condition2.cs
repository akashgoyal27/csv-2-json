using System.IO;
namespace Condition2
{
    class Program
    {
        static StreamWriter streamWriter = new StreamWriter(new FileStream(@"D:\condition2.json", FileMode.OpenOrCreate, FileAccess.Write));
        static long[,] total = new long[35, 4];
        static long illiterate_females, illiterate_males, literate_females, literate_males;
        static void csvreader(StreamReader sr)
        {
             string[] header1 = sr.ReadLine().Split(',');
            while (!sr.EndOfStream)
            {
                string[] values1 = sr.ReadLine().Split(',');
                if ((values1[4] == "Total" && values1[5] == "All ages" && int.Parse(values1[1])==12 )|| (values1[4] == "Total" && values1[5] == "All ages" && int.Parse(values1[1])==13 )|| (values1[4] == "Total" && values1[5] == "All ages" && int.Parse(values1[1]) ==14 )|| (values1[4] == "Total" && values1[5] == "All ages" && int.Parse(values1[1]) ==15 )|| (values1[4] == "Total" && values1[5] == "All ages" && int.Parse(values1[1]) ==16 )|| (values1[4] == "Total" && values1[5] == "All ages" && int.Parse(values1[1]) ==17 )|| (values1[4] == "Total" && values1[5] == "All ages" && int.Parse(values1[1]) ==18 ))
                {
                    illiterate_males += long.Parse(values1[10]);
                    illiterate_females+= long.Parse(values1[11]);
                    literate_males += long.Parse(values1[13]);
                    literate_females += long.Parse(values1[14]);
                }
            }
        }
        static void Main(string[] args)
        {
            csvreader(new StreamReader(new FileStream(@"D:\India2011.csv", FileMode.Open, FileAccess.Read)));
            csvreader(new StreamReader(new FileStream(@"D:\IndiaSC2011.csv", FileMode.Open, FileAccess.Read)));
            csvreader(new StreamReader(new FileStream(@"D:\IndiaST2011.csv", FileMode.Open, FileAccess.Read)));
            streamWriter.WriteLine("[ \r\n { \r\n" + "\"categorie\" : \"Illiterate\" , \r\n \"values\": [ \r\n { \r\n \"value\":" + illiterate_males + ",\r\n \"rate\" : \"Male\" \r\n }," + "\r\n { \r\n \"value\":" + illiterate_females + ",\r\n \"rate\" : \"Female\" \r\n } \r\n ] \r\n }, \r\n" + "{ \r\n" + "\"categorie\" : \"Literate\" , \r\n \"values\": [ \r\n { \r\n \"value\":" + literate_males + ",\r\n \"rate\" : \"Male\" \r\n }," + "\r\n { \r\n \"value\":" + literate_females + ",\r\n \"rate\" : \"Female\" \r\n } \r\n ] \r\n } \r\n ]");
            streamWriter.Flush();
        }
    }
}