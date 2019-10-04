using System;
using System.Net;
using Common;

namespace Downloader
{
    public class DatasetDownloader
    {
        public DatasetDownloader()
        {
            //TO Do: Change hardcode names and local download
            var webClient = new WebClient();
            webClient.DownloadFile(StringConstants.imdbDatasetURL,"name.basics.tsv.gz");
            webClient.DownloadFile(StringConstants.akasFile, "title.akas.tsv.gz");
            webClient.DownloadFile(StringConstants.titleBasicsFile, "title.basics.tsv.gz");
            webClient.DownloadFile(StringConstants.crewFile, "title.crew.tsv.gz");
            webClient.DownloadFile(StringConstants.episodeFile, "title.episode.tsv.gz");
            webClient.DownloadFile(StringConstants.principalsFile, "title.principals.tsv.gz");
            webClient.DownloadFile(StringConstants.ratingsFile, "title.ratings.tsv.gz");
        }
    }
}
