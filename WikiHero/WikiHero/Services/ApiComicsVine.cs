﻿using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiHero.Models;

namespace WikiHero.Services
{
    public class ApiComicsVine
    {
        public async Task<List<Character>> GetAllCharacter(int offset)
        {
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var characters = await getRequest.GetAllCharacter(Config.Apikey,offset);
            var notNull = from item in characters.Characters where item.Publisher != null select item;
            return notNull.ToList(); ;
        }
<<<<<<< HEAD
        public async Task<List<Movie>> GetFindMarvelMovies(string name)
        {
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var movies = await getRequest.GetFindMovies(Config.Apikey, name);
            var comics = movies.Results.Where(e => e.Studios.Exists(x => x.Id != 574 && x.Id != 10));
            return comics.ToList();
        }
        public async Task<List<Movie>> GetFindDcMovies(string name)
        {
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var movies = await getRequest.GetFindMovies(Config.Apikey, name);
            var comics = movies.Results.Where(e => e.Studios.Exists(x => x.Id != 5453 && x.Id != 31));
            return comics.ToList();
        }

        public async Task<List<Volume>> GetAllVolumes(int offset)
=======
 
        public async Task<ResultComics> GetAllComics(int offset)
>>>>>>> ac9cfc1bceee1d03ef676228543d69a29a14e5b5
        {
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var volumes = await getRequest.GetAllVolumes(Config.Apikey,offset);
            var notNull = from item in volumes.Volumes where item.Publisher != null select item;
            return notNull.ToList();;
        }
        
        public async Task<List<Serie>> GetAllSeries(int offset)
        {
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var series = await getRequest.GetAllSeries(Config.Apikey,offset);
            var notNull = from item in series.Series where item.Publisher != null select item;
            return notNull.ToList();
        }
    }
}
