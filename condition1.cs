using System.IO;
namespace condition1
{
    class Program
    {
        static StreamWriter streamWriter = new StreamWriter(new FileStream(@"D:\condition1.json", FileMode.OpenOrCreate, FileAccess.Write));
        static long totalPersons, totalMale, totalFemale, illiteratePersons, literatePersons;
        static void csvreader(StreamReader sr)
        {
            string[] header1 = sr.ReadLine().Split(',');
            while (!sr.EndOfStream)
            {
                string[] values1 = sr.ReadLine().Split(',');
                if (values1[4] == "Total" && values1[5] == "All ages")
                {
                    totalPersons += long.Parse(values1[6]);
                    totalMale += long.Parse(values1[7]);
                    totalFemale += long.Parse(values1[8]);
                    illiteratePersons += long.Parse(values1[9]);
                    literatePersons += long.Parse(values1[12]);
                }
            }
        }
        static void Main(string[] args)
        {
            csvreader(new StreamReader(new FileStream(@"D:\India2011.csv", FileMode.Open, FileAccess.Read)));
            csvreader(new StreamReader(new FileStream(@"D:\IndiaSC2011.csv", FileMode.Open, FileAccess.Read)));
            csvreader(new StreamReader(new FileStream(@"D:\IndiaST2011.csv", FileMode.Open, FileAccess.Read)));
            streamWriter.WriteLine("[ \r\n { \r\n " + "\"Property\" : \"TotalMales\" ," + "\r\n" + "\"Value\" : " + totalMale + "\r\n }," + "\r\n { \r\n " + "\"Property\" : \"TotalFemales\" ," + "\r\n" + "\"Value\" : " + totalFemale + "\r\n }," + "\r\n { \r\n " + "\"Property\" : \"IlliteratePersons\" ," + "\r\n" + "\"Value\" : " + illiteratePersons + "\r\n }, " + "\r\n { \r\n " + "\"Property\" : \"LiteratePersons\" ," + "\r\n" + "\"Value\" : " + literatePersons + "\r\n } \r\n ]");
            streamWriter.Flush();
        }
    }
}