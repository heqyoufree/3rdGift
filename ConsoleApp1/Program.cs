using System;
using System.Net;
using System.Web;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex reg = new Regex("dalao");
            string url1 = "https://api.mihayo.com/bh3-event-e20190926statistics/api/gift?cipher=";
            WebClient client = new WebClient();
            string url;
            string gift;
            for (long i = 3709732133; i < 43709732133; i++)
            {
                url = url1 + HttpUtility.UrlEncode(Base64Code(i + "!android01")) + "#/share";
                try
                {
                    gift = client.DownloadString(url);
                    if (reg.IsMatch(gift))
                    {
                        Console.WriteLine("match");
                        Console.WriteLine("https://webstatic.mihayo.com/bh3/event/e20190926statistics/index.html?cipher=" + HttpUtility.UrlEncode(Base64Code(i + "!android01")) + "#/share");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("发生错误，可能ip被ban，请指定秒数后重试");
                    string s = Console.ReadLine();
                    Thread.Sleep(int.Parse(s) * 1000);
                }
            }
        }
        static string Base64Code(string Message)
        {
            byte[] bytes = Encoding.Default.GetBytes(Message);
            return Convert.ToBase64String(bytes);
        }
    }
}
