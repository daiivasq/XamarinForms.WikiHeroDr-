using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiHero.Models;
using WikiHero.Services;

namespace WikiHero.ViewModels
{
    public class MoviePageViewModel : BaseViewModel
    {
        public ObservableCollection<Movie> Movies { get; set; } = new ObservableCollection<Movie>();
        public int ItemTreshold { get; set; }
        public bool IsBusy { get; set; }
        public string StudioName { get; set; }
        public DelegateCommand ItemTresholdReachedCommand { get; set; }


        public MoviePageViewModel(INavigationService navigationService, IPageDialogService dialogService, ApiComicsVine apiComicsVine, string studioName, int offeset) : base(navigationService, dialogService, apiComicsVine)
        {
            this.StudioName = studioName;
            ItemTresholdReachedCommand = new DelegateCommand(async () =>
            {
                offeset = offeset + 100;
                await ScrollLoadMovies(offeset);
            });
        }

        protected async Task ScrollLoadMovies(int offset)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var items = await apiComicsVine.GetAllMovies(offset);
                //var marvel = items.Where(e => e.Publisher.Name.Contains(PublisherName));
                foreach (var item in items.Results)
                {
                    Movies.Add(item);
                }
                if (offset == 1000)
                {
                    ItemTreshold = -1;
                    return;
                }
            }
            catch (Exception ex)
            {
                await dialogService.DisplayAlertAsync("Error", $"{ex.Message}", "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }
        protected async Task LoadMarvelMovies(int offset)
        {
            try
            {
                var list = await apiComicsVine.GetAllMovies(offset);
                //var comics = list.Where(e => e.Publisher.Name.Contains(PublisherName));
                Movies = new ObservableCollection<Movie>(list.Results);
            }
            catch (Exception ex)
            {

                await dialogService.DisplayAlertAsync("Error", $"{ex.Message}", "Ok");

            }

        }
    }
}
