using MonkeyCache.FileStore;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiHero.Models.CharacterStatModel;
using Xamarin.Essentials;

namespace WikiHero.Services
{
    public class ApiStatsCharacters
    {
        public ApiStatsCharacters()
        {
            Barrel.ApplicationId = Config.CacheKey;
        }
        private bool NetworkAvalible()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet || !Barrel.Current.IsExpired(key: Config.CacheKey))
            {
                return false;
            }
            return true;
        }
        public async Task<List<CharacterStats>> GetCharacterStats()
        {
            if (!NetworkAvalible())
            {
                await Task.Yield();
                return Barrel.Current.Get<List<CharacterStats>>(key: nameof(GetCharacterStats));
            }

            var getRequest = RestService.For<IApiCharacterStats>(Config.UrlApiCharactersStats);
            var stats = await getRequest.CharacterStats();
            var characters = stats.Where(e => e.Biography.Publisher != null).ToList(); 
            Barrel.Current.Add(key: nameof(GetCharacterStats), characters, expireIn: TimeSpan.FromDays(1));
            return characters;

        }
    }
}
