using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Create2KWebContentTypeForSP10
{
    class Program
    {
        static void Main(string[] args)
        {
            String webUrl = String.Empty;
            Console.Write("Please input site URL:");
            webUrl = Console.ReadLine();
            try
            {
                using (var webContentTypeCreator = new CreateWebContentType(webUrl))
                {
                    for (int i = 0; i < 2000; i++)
                    {
                        webContentTypeCreator.CreateContentType("WCT" + (i + 1).ToString());
                    }
                    webContentTypeCreator.Update();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.Write("Create Job is over, put any key to exit.");
            Console.ReadKey();
        }
    }
}
