using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using WikiHero.Models;
using WikiHero.Services;

namespace WikiHero.ViewModels.MarvelViewModels
{
    public class MarvelMoviesPageViewModel : BaseViewModel
    {

        public ObservableCollection<Movie> Movies { get; set; } = new ObservableCollection<Movie>();
        public DelegateCommand<string> SearhCommand { get; set; }
        public MarvelMoviesPageViewModel(INavigationService navigationService, IPageDialogService dialogService, ApiComicsVine apiComicsVine) : base(navigationService, dialogService, apiComicsVine)
        {
            SearhCommand = new DelegateCommand<string>(async (param) =>
            {
                await LoadMovies(param);
            });
        }
        public async Task LoadMovies(string nameMovie)
        {
            try
            {
                var list = await apiComicsVine.GetFindMarvelMovies(nameMovie);
                Movies = new ObservableCollection<Movie>(list);
            }
            catch (Exception ex)
            {

                await dialogService.DisplayAlertAsync("Error", $"{ex.Message}", "Ok");

            }
        }
    }
}
