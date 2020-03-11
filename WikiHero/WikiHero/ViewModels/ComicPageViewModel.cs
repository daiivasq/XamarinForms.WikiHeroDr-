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
    public class ComicPageViewModel : BaseViewModel
    {
        public ObservableCollection<Comic> Comics { get; set; } = new ObservableCollection<Comic>();
        public int ItemTreshold { get; set; }
        public bool IsBusy { get; set; }
        public string WriterName { get; set; }
        public DelegateCommand ItemTresholdReachedCommand { get; set; }


        public ComicPageViewModel(INavigationService navigationService, IPageDialogService dialogService, ApiComicsVine apiComicsVine, string writerName, int offeset) : base(navigationService, dialogService, apiComicsVine)
        {
            this.WriterName = writerName;
            ItemTresholdReachedCommand = new DelegateCommand(async () =>
            {
                offeset = offeset + 100;
                await ScrollLoadComics(offeset);
            });
        }


        protected async Task ScrollLoadComics(int offset)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var items = await apiComicsVine.GetAllComics(offset);
                //var marvel = items.Where(e => e.Publisher.Name.Contains(PublisherName));
                foreach (var item in items.Results)
                {
                    Comics.Add(item);
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
        protected async Task LoadComics(int offset)
        {
            try
            {
                var list = await apiComicsVine.GetAllComics(offset);
                //var comics = list.Where(e => e.Publisher.Name.Contains(PublisherName));
                Comics = new ObservableCollection<Comic>(list.Results);
            }
            catch (Exception ex)
            {

                await dialogService.DisplayAlertAsync("Error", $"{ex.Message}", "Ok");

            }

        }
    }
}
