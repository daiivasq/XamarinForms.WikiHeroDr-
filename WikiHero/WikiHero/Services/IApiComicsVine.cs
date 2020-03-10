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
        Task<ResultCharacter> GetAllCharacter(string api_key, int offset,DateTime actualTime);
    }
}
