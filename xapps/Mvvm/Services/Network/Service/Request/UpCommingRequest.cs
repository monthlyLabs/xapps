﻿using System;
namespace xapps
{
    public class UpCommingRequest
    {
        //https://api.themoviedb.org/3/movie/upcoming?api_key=54284155412142a62e518c006e50d5ce&language=en-US&page=1
        public static string localeListRestUrl = "https://api.themoviedb.org/3/movie/upcoming?";
        public static string api_key = "&api_key=54284155412142a62e518c006e50d5ce";
        public static string language = "&language=ko-KR";
        public static string page = "&page=";
    }
}
