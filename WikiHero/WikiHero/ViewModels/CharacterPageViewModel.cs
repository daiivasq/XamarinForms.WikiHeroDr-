﻿using Prism.Commands;
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
                offeset += 100;
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
                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                {
                    var items = await apiComicsVine.GetAllCharacter(offset, PublisherName);
                  
                    foreach (var item in items)
                    {
                        Characters.Add(item);
                    }
                    if (offset == 1000)
                    {
                        ItemTreshold = -1;
                        return;
                    }
                }
                else await dialogService.DisplayAlertAsync("Connection error ", Connectivity.NetworkAccess.ToString(), "Ok");
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
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                try
                {
                    var list = await apiComicsVine.GetAllCharacter(offset, PublisherName);
                    Characters = new ObservableCollection<Character>(list);
                }
                catch (Exception ex)
                {

                    await dialogService.DisplayAlertAsync("Error", $"{ex.Message}", "Ok");

                }
            }
            else
                await dialogService.DisplayAlertAsync("Connection error ", Connectivity.NetworkAccess.ToString(), "Ok");

        }
    }
}
