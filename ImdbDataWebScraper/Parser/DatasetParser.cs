using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Common;
namespace Parser
{
    //Parse the datasets
    public class DatasetParser
    {
        private IMDBDataset imdbDataset;
        public DatasetParser()
        {
            imdbDataset = new IMDBDataset();
        }
        public string ProcessAsJSON(string fileName)
        {
            return ""; //to do
        }
        public IMDBDataset GetIMDBDataset()
        {
            return imdbDataset;
        }
        public void Process(string fileName)
        {
            try
            {
                ReadGZFile(fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to parse:" + ex.Message);
            }
        }
        private void ReadGZFile(string fileName)
        {
            using (var input = File.OpenRead(fileName))
            {
                string newFileName = fileName.Replace(".gz", ".csv");

                using (FileStream decompressedFileStream = File.Create(newFileName))
                {
                    using (GZipStream decompressionStream = new GZipStream(input, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(decompressedFileStream);
                    }
                }
                string[] lines = File.ReadAllLines(newFileName, System.Text.Encoding.UTF8);
                AddToDataSet(fileName, lines);
            }
        }
        private void AddToDataSet(string fileName, string[] lines)
        {
            if (lines.Length == 0)
                return;
            string seperator = "\t";
            string[] header = lines[0].Split(seperator.ToCharArray()); // think to build class using header - TypeBuilder?
            if (fileName.Equals(StringConstants.akasFile))
            {
                for (int i = 1; i < lines.Length; i++)
                {
                    TitleAkas akas = new TitleAkas(lines[i].Split(seperator.ToCharArray()));
                    imdbDataset.TitleAkasMetaData.Add(akas);
                }
            }
            else if (fileName.Equals(StringConstants.titleBasicsFile))
            {
                for (int i = 1; i < lines.Length; i++)
                {
                    TitleBasics basics = new TitleBasics(lines[i].Split(seperator.ToCharArray()));
                    imdbDataset.TitleBasicsMetaData.Add(basics);
                }
            }
            else if (fileName.Equals(StringConstants.crewFile))
            {
                for (int i = 1; i < lines.Length; i++)
                {
                    TitleCrew crew = new TitleCrew(lines[i].Split(seperator.ToCharArray()));
                    imdbDataset.TitleCrewMetaData.Add(crew);
                }
            }
            else if (fileName.Equals(StringConstants.episodeFile))
            {
                for (int i = 1; i < lines.Length; i++)
                {
                    TitleEpisode episode = new TitleEpisode(lines[i].Split(seperator.ToCharArray()));
                    imdbDataset.TitleEpisodeMetaData.Add(episode);
                }
            }
            else if (fileName.Equals(StringConstants.principalsFile))
            {
                for (int i = 1; i < lines.Length; i++)
                {
                    TitlePrincipals principals = new TitlePrincipals(lines[i].Split(seperator.ToCharArray()));
                    imdbDataset.TitlePrincipalsMetaData.Add(principals);
                }
            }
            else if (fileName.Equals(StringConstants.ratingsFile))
            {
                for (int i = 1; i < lines.Length; i++)
                {
                    TitleRatings ratings = new TitleRatings(lines[i].Split(seperator.ToCharArray()));
                    imdbDataset.TitleRatingsMetaData.Add(ratings);
                }
            }
            else if (fileName.Equals(StringConstants.nameBasicsFile))
            {
                for (int i = 1; i < lines.Length; i++)
                {
                    NameBasics basics = new NameBasics(lines[i].Split(seperator.ToCharArray()));
                    imdbDataset.NameBasicsMetaData.Add(basics);
                }
            }

        }
    }
}
