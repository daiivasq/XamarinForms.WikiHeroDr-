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
using Xamarin.Essentials;

namespace WikiHero.ViewModels
{
    public class VolumePageViewModel : BaseViewModel
    {
        public ObservableCollection<Volume> Comics { get; set; } = new ObservableCollection<Volume>();
        public int ItemTreshold { get; set; }
        public bool IsBusy { get; set; }
        public string PublisherPrincipal { get; set; }
        public string PublisherSecond{ get; set; }
        public string PublisherThird { get; set; }

        public DelegateCommand ItemTresholdReachedCommand { get; set; }


        public VolumePageViewModel(INavigationService navigationService, IPageDialogService dialogService, ApiComicsVine apiComicsVine, string publisherPrincipal, string publisherSecond, string publisherThird, int offeset) : base(navigationService, dialogService, apiComicsVine)
        {
            this.PublisherPrincipal =publisherPrincipal;
            this.PublisherSecond = publisherSecond;
            this.PublisherThird = publisherThird;
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
                var items = await apiComicsVine.GetAllVolumes(offset, PublisherPrincipal, PublisherSecond, PublisherThird);
                foreach (var item in items)
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
                var comics = await apiComicsVine.GetAllVolumes(offset,PublisherPrincipal,PublisherSecond,PublisherThird);
                Comics = new ObservableCollection<Volume>(comics);
            }
            catch (Exception ex)
            {

                await dialogService.DisplayAlertAsync("Volume", $"{ex.Message}", "Ok");

            }
            }
        }
    }

