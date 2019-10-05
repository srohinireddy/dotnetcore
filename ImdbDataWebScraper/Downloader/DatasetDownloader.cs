using System;
using System.Net;
using Common;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HtmlAgilityPack;

namespace Downloader
{
    public class DatasetDownloader
    {

        public DatasetDownloader()
        {
            Download(StringConstants.imdbDatasetURL);
        }
        private void Download(string url)
        {
            HtmlWeb hw = new HtmlWeb();
            HtmlDocument doc = hw.Load(url);
            string[] urls = doc.DocumentNode.Descendants("a").Select(node => node.Attributes["href"].Value).ToArray();
            string[] names = doc.DocumentNode.Descendants("a").Select(node => node.InnerText).ToArray();
            for (int i = 0; i < urls.Length; i++)
            {
                string u = urls[i];
                if (u.Contains("dataset"))
                {
                    var webClient = new WebClient();
                    //To DO: Optimize in asyc way 
                    webClient.DownloadFile(u, names[i]);
                }
            }
        }
    }
}
