using System;

namespace Common
{
    public class StringConstants
    {
        //TO Do: Change hardcode names
        public static string imdbDatasetURL = "https://datasets.imdbws.com/";
        public static string nameBasicsFile = "name.basics.tsv.gz";
        public static string akasFile = "title.akas.tsv.gz";
        public static string titleBasicsFile = "title.basics.tsv.gz";
        public static string  crewFile = "title.crew.tsv.gz";
        public static string episodeFile = "title.episode.tsv.gz";
        public static string principalsFile = "title.principals.tsv.gz";
        public static string ratingsFile = "title.ratings.tsv.gz";
    }
}
namespace IMDBDataset
{
    struct akas
    {
        string titleId;
        int ordering;
        string title;
        string region;
    }
    struct titlebasics
    {
        string tconst;
        string titleType;
        string primaryTitle;
        string originalTitle;
        bool isAdult;
    }
    struct crew
    {
        string tconst;
    }

    struct episode
    {
        string tconst;
        string  parentTconst;
        int seasonNumber;
        int episodeNumber;
    }

    struct principals
    {
        string tconst;
        int ordering;
        string nconst;
        string category;
        string job;
        string characters;
    }
    struct ratings
    {
        string tconst;
        float averageRating;
        int numVotes;
    }

    struct namebasics
    {
        string nconst;
        string primaryName;

    }
}
