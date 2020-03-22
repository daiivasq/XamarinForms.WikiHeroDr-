using MonkeyCache.FileStore;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiHero.Models;
using Xamarin.Essentials;

namespace WikiHero.Services
{
    public class ApiComicsVine
    {
        private bool NetworkAvalible()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet || !Barrel.Current.IsExpired(key: Config.CacheKey))
            {
                return false;
            }
            return true;
        }
        public ApiComicsVine()
        {

            Barrel.ApplicationId = Config.CacheKey;
           
        }
        public async Task<List<Character>> GetAllCharacter(int offset,string publisher)
        {
            if (!NetworkAvalible())
            {
                await Task.Yield();
                return Barrel.Current.Get<List<Character>>(key: $"{nameof(GetAllCharacter)}{publisher}");
            }
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var characters = await getRequest.GetAllCharacter(Config.Apikey,offset);
            var notNull = from item in characters.Characters where item.Publisher != null select item;
            var marvelOrDc = notNull.Where(e => e.Publisher.Name.Contains(publisher));
            Barrel.Current.Add(key: $"{nameof(GetAllCharacter)}/{publisher}", marvelOrDc.ToList(),expireIn: TimeSpan.FromDays(1));
            return marvelOrDc.ToList();
        }

        public async Task<List<Volume>> GetAllVolumes(int offset,string PublisherPrincipal,string PublisherSecond,string PublisherThird)
        {
            if (NetworkAvalible()==false)
            {
                await Task.Yield();
                return Barrel.Current.Get<List<Volume>>(key: $"{nameof(GetAllVolumes)}/{PublisherPrincipal}");
            }
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var volumes = await getRequest.GetAllVolumes(Config.Apikey,offset);
            var notNull = from item in volumes.Volumes where item.Publisher != null select item;
            var marvelOrDc = notNull.Where(e => e.Publisher.Name.Contains(PublisherPrincipal) || e.Publisher.Name.Contains(PublisherSecond) || e.Publisher.Name.Contains(PublisherThird));
            Barrel.Current.Add(key:$"{nameof(GetAllVolumes)}/{PublisherPrincipal}", marvelOrDc, expireIn: TimeSpan.FromDays(1));
            return marvelOrDc.ToList();;
        }
        
        public async Task<List<Serie>> GetAllSeries(int offset,string StudioName,string ExtraStudioName)
        {
            if (!NetworkAvalible())
            {
                await Task.Yield();
                return Barrel.Current.Get<List<Serie>>(key: $"{nameof(GetAllSeries)}/{StudioName}");
            }
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var series = await getRequest.GetAllSeries(Config.Apikey,offset);
            var notNull = from item in series.Series where item.Publisher != null select item;
            var marvelOrDc = notNull.Where(e => e.Publisher.Name.Contains(StudioName) || e.Publisher.Name.Contains(ExtraStudioName));
            Barrel.Current.Add(key: $"{nameof(GetAllSeries)}/{StudioName}", marvelOrDc, expireIn: TimeSpan.FromDays(1));
            return notNull.ToList();
        }
    }
}
