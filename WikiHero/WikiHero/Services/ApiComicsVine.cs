using Refit;
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
        public async Task<ResultMovies> GetAllMovies(int offset)
        {
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var movies = await getRequest.GetAllMovies(Config.Apikey,offset);
            return movies;
        } 

        public async Task<ResultComics> GetAllComics(int offset)
        {
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var comics = await getRequest.GetAllComics(Config.Apikey,offset);
            return comics;
        }
        
        public async Task<ResultSeries> GetAllSeries(int offset)
        {
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var series = await getRequest.GetAllSeries(Config.Apikey,offset);
            return series;
        }
    }
}
