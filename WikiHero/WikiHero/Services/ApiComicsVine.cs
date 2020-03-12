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

        public async Task<List<Volume>> GetAllVolumes(int offset)
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
