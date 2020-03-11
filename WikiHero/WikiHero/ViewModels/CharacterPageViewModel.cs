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
    public class CharacterPageViewModel : BaseViewModel
    {
        public ObservableCollection<Character> Characters { get; set; } = new ObservableCollection<Character>();
        public int ItemTreshold { get; set; }
        public bool IsBusy { get; set; }
        public string PublisherName { get; set; }
        public DelegateCommand ItemTresholdReachedCommand { get; set; }
        public CharacterPageViewModel(INavigationService navigationService, IPageDialogService dialogService, ApiComicsVine apiComicsVine,string publisherName,int offeset) : base(navigationService, dialogService, apiComicsVine)
        {
            this.PublisherName = publisherName;
            ItemTresholdReachedCommand = new DelegateCommand(async () =>
            {
                offeset = offeset + 100;
                await ScrollLoadCharacters(offeset);
            });

        }
       protected async Task ScrollLoadCharacters(int offset)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var items = await apiComicsVine.GetAllCharacter(offset);
                var marvel = items.Where(e => e.Publisher.Name.Contains(PublisherName));
                foreach (var item in marvel)
                {
                    Characters.Add(item);
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
      protected async Task LoadCharacters(int offset)
        {
            try
            {
                var list = await apiComicsVine.GetAllCharacter(offset);
                var characters = list.Where(e => e.Publisher.Name.Contains(PublisherName));
                Characters = new ObservableCollection<Character>(characters);
            }
            catch (Exception ex)
            {

               await dialogService.DisplayAlertAsync("Error",$"{ex.Message}","Ok");

            }

        }
    }
}
