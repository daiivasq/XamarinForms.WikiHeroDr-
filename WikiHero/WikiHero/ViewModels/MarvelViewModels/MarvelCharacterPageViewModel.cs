using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiHero.Models;
using WikiHero.Services;

namespace WikiHero.ViewModels.MarvelViewModels
{
    public class MarvelViewModels : CharacterPageViewModel
    {
        private const string Marvel = "Marvel";
        public MarvelViewModels(INavigationService navigationService, IPageDialogService dialogService, ApiComicsVine apiComicsVine, int offeset=100) :base(navigationService, dialogService, apiComicsVine,Marvel, offeset)
        {
            LoadMarvelCharacters(offeset);
        }
    }
}
