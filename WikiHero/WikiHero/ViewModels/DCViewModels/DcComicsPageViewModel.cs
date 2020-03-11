using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using WikiHero.Services;

namespace WikiHero.ViewModels.DCViewModels
{
    public class DcComicsPageViewModel : ComicPageViewModel
    {
        private const string DcUniverse = "DcComic";
        public DcComicsPageViewModel(INavigationService navigationService, IPageDialogService dialogService, ApiComicsVine apiComicsVine) : base(navigationService, dialogService, apiComicsVine, DcUniverse, 100)
        {

        }
    }
}
