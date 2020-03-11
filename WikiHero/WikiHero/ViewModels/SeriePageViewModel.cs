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
    public class SeriePageViewModel : BaseViewModel
    {
        public ObservableCollection<Serie> Series { get; set; } = new ObservableCollection<Serie>();
        public int ItemTreshold { get; set; }
        public bool IsBusy { get; set; }
        public string StudioName { get; set; }
        public DelegateCommand ItemTresholdReachedCommand { get; set; }


        public SeriePageViewModel(INavigationService navigationService, IPageDialogService dialogService, ApiComicsVine apiComicsVine, string studioName, int offeset) : base(navigationService, dialogService, apiComicsVine)
        {
            this.StudioName = studioName;
            ItemTresholdReachedCommand = new DelegateCommand(async () =>
            {
                offeset = offeset + 100;
                await ScrollLoadSeries(offeset);
            });
        }

        protected async Task ScrollLoadSeries(int offset)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var items = await apiComicsVine.GetAllSeries(offset);
                //var marvel = items.Where(e => e.Publisher.Name.Contains(PublisherName));
                foreach (var item in items.Series)
                {
                    Series.Add(item);
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
        protected async Task LoadSeries(int offset)
        {
            try
            {
                var list = await apiComicsVine.GetAllSeries(offset);
                Series = new ObservableCollection<Serie>(list.Series);
            }
            catch (Exception ex)
            {

                await dialogService.DisplayAlertAsync("Error", $"{ex.Message}", "Ok");

            }

        }
    
    }
}
