using HtmlAgilityPack;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CM_LinkChecker
{
    /// <summary>
    /// Assumption 1. HTML tags read from file, please update the file path
    /// 2. The destination URL allows Head Request
    /// </summary>
    class Program
    {        
        static void Main(string[] args)
        {
            try
            {
                // Update the html file path here
                var path = @"PathToFile\File.html";
                Dictionary<string, String> checkedURLs = new Dictionary<string, string>();

                var doc = new HtmlDocument();
                doc.Load(path);

                HtmlNodeCollection anchorNodes = doc.DocumentNode.SelectNodes("//a[not(contains(@href, 'mailto'))]");

                List<Task> tasks = new List<Task>();
                foreach (HtmlNode node in anchorNodes)
                {
                    if (node.Attributes["href"] != null)
                    {
                        string url = node.Attributes["href"].Value;
                        if (!string.IsNullOrEmpty(url))
                        {
                            if (checkedURLs.TryAdd(url, url))
                            {
                                tasks.Add(CheckLinkAsync(url));
                            }
                        }
                    }
                }
                Task.WaitAll(tasks.ToArray());
                Console.ReadKey();
            }
            catch(Exception e)
            { 
                Console.WriteLine("Error in checking the links: " + e.ToString());
                Console.ReadKey();
            }
        }

        static async Task<Task> CheckLinkAsync(string url)
        {
            using (HttpClient client = new HttpClient(new HttpClientHandler() { AllowAutoRedirect = true }))
            {
                try
                {
                    var result = await client.SendAsync(new HttpRequestMessage(HttpMethod.Head, url));
                    if (result.StatusCode == HttpStatusCode.OK || result.StatusCode == HttpStatusCode.Redirect)
                    {
                        Console.WriteLine(string.Format("The URL is valid: {0}", url));
                    }
                    else
                    {
                        Console.WriteLine(string.Format("The URL is not valid: {0}", url));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(string.Format("The URL is not valid: {0}", url));
                    Console.WriteLine("Exception occured: " + e.ToString());
                }
                return Task.CompletedTask;
            }
        }
    }
}
