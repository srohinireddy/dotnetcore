using System;
using System.Collections.Generic;
namespace Common
{
    public class StringConstants
    {
        //TO Do: Change hardcode names
        public static string imdbDatasetURL = "https://datasets.imdbws.com/";
        public static string nameBasicsFile = "name.basics.tsv.gz";
        public static string akasFile = "title.akas.tsv.gz";
        public static string titleBasicsFile = "title.basics.tsv.gz";
        public static string crewFile = "title.crew.tsv.gz";
        public static string episodeFile = "title.episode.tsv.gz";
        public static string principalsFile = "title.principals.tsv.gz";
        public static string ratingsFile = "title.ratings.tsv.gz";
    }

    public class IMDBDataset
    {
        public IMDBDataset()
        {
            TitleAkasMetaData = new List<TitleAkas>();
            TitleBasicsMetaData = new List<TitleBasics>();
            TitleCrewMetaData = new List<TitleCrew>();
            TitleEpisodeMetaData = new List<TitleEpisode>();
            TitlePrincipalsMetaData = new List<TitlePrincipals>();
            TitleRatingsMetaData = new List<TitleRatings>();
            NameBasicsMetaData = new List<NameBasics>();
        }
        public List<TitleAkas> TitleAkasMetaData { get; set; }
        public List<TitleBasics> TitleBasicsMetaData { get; set; }
        public List<TitleCrew> TitleCrewMetaData { get; set; }
        public List<TitleEpisode> TitleEpisodeMetaData { get; set; }
        public List<TitlePrincipals> TitlePrincipalsMetaData { get; set; }
        public List<TitleRatings> TitleRatingsMetaData { get; set; }
        public List<NameBasics> NameBasicsMetaData { get; set; }
    }
    public class TitleAkas
    {
        //Field definition
        public TitleAkas(string[] fields)
        {
            if (fields.Length < 4)
                return;
            //fields order should be as defined  -  define an interface as per Imdb
            //this may need to be updated whenever the csv fields changes in IMdb interfaces
            try
            {
                TitleId = fields[0];
                int order;
                bool isorder = Int32.TryParse(fields[1], out order);
                Ordering = isorder ? order : 0;
                Title = fields[2];
                Region = fields[3];
                int isoriginal;
                bool res = Int32.TryParse(fields[fields.Length - 1], out isoriginal);
                IsOriginalTitle = (res == true && isoriginal == 1) ? true : false;
            }
            catch (Exception ex)
            {
                //Seems something wrong. set default values.
                SetDefault();
            }
        }

        private void SetDefault()
        {
            TitleId = string.Empty;
            Ordering = 0;
            Title = string.Empty;
            Region = string.Empty;
            IsOriginalTitle = false;
        }
        public string TitleId { get; private set; }
        public int Ordering { get; private set; }
        public string Title { get; private set; }
        public string Region { get; private set; }
        //To DO:Types , Attributes need ot be updated
        public bool IsOriginalTitle { get; private set; }
    }

    public class TitleBasics
    {
        public TitleBasics(string[] fields)
        {
            if (fields.Length < 8)
                return;

            try
            {
                TConst = fields[0];
                TitleType = fields[1];
                PrimaryTitle = fields[2];
                OriginalTitle = fields[3];
                int adult;
                bool isad = Int32.TryParse(fields[4], out adult);
                IsAdult = (isad && adult == 1) ? true : false;
                int ystart;
                bool isstart = Int32.TryParse(fields[5], out ystart);
                StartYear = isstart ? ystart : 0;
                int yend;
                bool isend = Int32.TryParse(fields[6], out yend);
                EndYear = isend ? yend : 0;
                int runtime;
                bool isRuntime = Int32.TryParse(fields[7], out runtime);
                RuntimeMinutes = isRuntime ? runtime : 0;
                Geners = new List<string>();
                for (int i = 8; i < fields.Length; i++)
                {
                    Geners.Add(fields[i]);
                }
            }
            catch (Exception ex)
            {
                //something seems to be wrong. set default values
                SetDefault();
            }
        }
        private void SetDefault()
        {
            TConst = string.Empty;
            TitleType = string.Empty;
            PrimaryTitle = string.Empty;
            OriginalTitle = string.Empty;
            IsAdult = false;
            StartYear = 0;
            EndYear = 0;
            RuntimeMinutes = 0;
            Geners = new List<string>();
        }
        public string TConst { get; private set; }
        public string TitleType { get; private set; }
        public string PrimaryTitle { get; private set; }
        public string OriginalTitle { get; private set; }
        public bool IsAdult { get; private set; }
        public int StartYear { get; private set; }
        public int EndYear { get; private set; }
        public int RuntimeMinutes { get; private set; }
        public List<string> Geners { get; private set; }
    }

    public class TitleCrew
    {
        public TitleCrew(string[] fields)
        {
            if (fields.Length < 2) // need to update
                return;
            TConst = fields[0];
            //To Do:set directors and writers
            Directors = new List<string>();
            Writers = new List<string>();
        }
        public string TConst { get; private set; }
        public List<string> Directors { get; private set; }
        public List<string> Writers { get; private set; }
    }

    public class TitleEpisode
    {
        public TitleEpisode(string[] fileds)
        {
            if (fileds.Length < 4)
                return;
            try
            {

                TConst = fileds[0];
                ParentTconst = fileds[1];
                int sNum;
                bool isseason = Int32.TryParse(fileds[2], out sNum);
                SeasonNumber = isseason ? sNum : 0;
                int eNum;
                bool isepi = Int32.TryParse(fileds[3], out eNum);
                EpisodeNumber = isepi ? eNum : 0;
            }
            catch (Exception ex)
            {
                //Something went wrong. set to default.
                TConst = string.Empty;
                ParentTconst = string.Empty;
                SeasonNumber = 0;
                EpisodeNumber = 0;
            }
        }
        public string TConst { get; private set; }
        public string ParentTconst { get; private set; }
        public int SeasonNumber { get; private set; }
        public int EpisodeNumber { get; private set; }
    }

    public class TitlePrincipals
    {
        public TitlePrincipals(string[] fields)
        {
            if (fields.Length < 4)
                return;
            try
            {
                tConst = fields[0];
                int order;
                bool isorder = Int32.TryParse(fields[1], out order);
                Ordering = isorder ? order : 0;
                nConst = fields[2];
                Category = fields[3];
                Job = (fields.Length > 4) ? fields[4] : string.Empty;//its optional
                Characters = (fields.Length > 5) ? fields[5] : string.Empty;
            }
            catch (Exception ex)
            {
                //Something went wrong. set to default.
            }
        }
        public string tConst { get; private set; }
        public int Ordering { get; private set; }
        public string nConst { get; private set; }
        public string Category { get; private set; }
        public string Job { get; private set; }
        public string Characters { get; private set; }
    }

    public class TitleRatings
    {
        public TitleRatings(string[] fields)
        {
            if (fields.Length < 3)
                return;
            try
            {
                tConst = fields[0];
                float averageRating;
                bool resAvg = float.TryParse(fields[1], out averageRating);
                AverageRating = resAvg ? averageRating : 0;
                int noVotes;
                bool resVotes = int.TryParse(fields[2], out noVotes);
                NumberOfVotes = resVotes ? noVotes : 0;
            }
            catch (Exception ex)
            {
                //Something went wrong. set to default.
                tConst = string.Empty;
                AverageRating = 0;
                NumberOfVotes = 0;
            }
        }
        public string tConst { get; private set; }
        public float AverageRating { get; private set; }
        public int NumberOfVotes { get; private set; }
    }

    public class NameBasics
    {
        public NameBasics(string[] fields)
        {
            if (fields.Length < 3)
                return;
            try
            {
                nConst = fields[0];
                PrimaryName = fields[1];
                int ybirth;
                bool resBirth = int.TryParse(fields[2], out ybirth);
                BirthYear = resBirth ? ybirth : 0;
                int ydeath;
                bool resDeath = int.TryParse(fields[3], out ydeath);
                DeathYear = resDeath ? ydeath : 0;
                //To DO: set below fields properly
                PrimaryProfession = new List<string>();
                KnownForTitles = new List<string>();
            }
            catch (Exception ex)
            {
                //Something went wrong. set to default.
                nConst = string.Empty;
                PrimaryName = string.Empty;
                BirthYear = DeathYear = 0;
                PrimaryProfession = new List<string>();
                KnownForTitles = new List<string>();
            }
        }
        public string nConst { get; private set; }
        public string PrimaryName { get; private set; }

        public int BirthYear { get; private set; }
        public int DeathYear { get; private set; }
        public List<string> PrimaryProfession { get; private set; }
        public List<string> KnownForTitles { get; private set; }
    }
}
