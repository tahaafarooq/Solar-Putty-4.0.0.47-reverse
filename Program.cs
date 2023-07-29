using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter Session File Path : ");
        string data_file = Console.ReadLine();

        using(FileStream fs = new FileStream(data_file, FileMode.Open))
        {
            using(StreamReader sr = new StreamReader(fs))
            {
                string ct = sr.ReadToEnd();
                try
                {
                    byte[] decryptb64 = Convert.FromBase64String(ct);
                    try
                    {
                        byte[] unicode = ProtectedData.Unprotect(decryptb64, null, DataProtectionScope.CurrentUser);
                        string output = Encoding.Unicode.GetString(unicode);
                        Console.WriteLine(output);
                    } catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                } catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}