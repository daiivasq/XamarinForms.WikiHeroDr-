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
            var characters = await getRequest.GetAllCharacter(Config.Apikey,offset, DateTime.Now);
            var notNull = from item in characters.Characters where item.Publisher != null select item;
            return notNull.ToList(); ;
        }
    }
}
