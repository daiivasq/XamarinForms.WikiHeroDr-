using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using WikiHero.Services;

namespace WikiHero.ViewModels
{
   public class MarvelVsDcComicsPageViewModel:BaseViewModel
    {
        public DelegateCommand DcComicsCommand { get; set; }
        public DelegateCommand MarvelCommand { get; set; }
        public MarvelVsDcComicsPageViewModel(INavigationService navigationService, IPageDialogService dialogService, ApiComicsVine apiComicsVine) :base(navigationService, dialogService, apiComicsVine)
        {

        }
    }
}
