using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WikiHero.Models;

namespace WikiHero.Services
{
    public interface IApiComicsVine
    {
        [Get("/api/characters?api_key={api_key}&format=json&limit=100&offset={offset}&filter=date_last_updated: 2018-12-18 10:49:41|2020-03-06 13:15:56")]
        Task<ResultCharacter> GetAllCharacter(string api_key, int offset);


        [Get("/api/movies?api_key=25ad183b2735436b99524296c511af292c8a011f&format=json&format=json&limit=100&filter=name: {name}")]
        Task<ResultMovies> GetFindMovies(string api_key, string name);

        [Get("/api/issues?api_key={api_key}&format=json&offset={offset}&filter=date_last_updated : 2018-09-02 17:47:38|2020-03-10 11:00:00&sort=date_last_updated : desc")]
        Task<ResultComics> GetAllComics(string api_key, int offset);
        
        [Get("/api/series_list?api_key={api_key}&format=json&offset={offset}&filter=date_last_updated : 2018-09-02 17:47:38|2020-03-10 11:00:00&sort=date_last_updated : desc")]
        Task<ResultSeries> GetAllSeries(string api_key, int offset);

        
    }
}
