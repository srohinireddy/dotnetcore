using System;

namespace Common
{
    public class Common
    {
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
