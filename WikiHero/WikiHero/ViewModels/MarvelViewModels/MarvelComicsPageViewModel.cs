﻿using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using WikiHero.Services;

namespace WikiHero.ViewModels.MarvelViewModels
{
    public class MarvelComicsPageViewModel : ComicPageViewModel
    {
    
        private const string MarvelUniverse = "MarvelComic";
        public MarvelComicsPageViewModel(INavigationService navigationService, IPageDialogService dialogService, ApiComicsVine apiComicsVine) : base(navigationService, dialogService, apiComicsVine, MarvelUniverse, 100)
        {

        }
    }
}