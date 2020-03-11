using Prism;
using Prism.Ioc;
using Prism.Unity;
using System;
using WikiHero.Helpers;
using WikiHero.Services;
using WikiHero.ViewModels;
using WikiHero.ViewModels.MarvelViewModels;
using WikiHero.Views;
using WikiHero.Views.MarvelViews;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WikiHero
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync(new Uri(ConfigPageUri.MarvelCharactersPage));
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance<ApiComicsVine>(new ApiComicsVine());
            containerRegistry.RegisterForNavigation<MarvelVsDcComicsPage, MarvelVsDcComicsPageViewModel>();
            containerRegistry.RegisterForNavigation<MarvelCharactersPage, MarvelCharacterPageViewModel>();
            containerRegistry.RegisterForNavigation<MarvelComicsPage, MarvelComicsPageViewModel>();
            containerRegistry.RegisterForNavigation<MarvelHomePage, MarvelHomePageViewModel>();
            containerRegistry.RegisterForNavigation<MarvelSeriesPage, MarvelSeriesPageViewModel>();
            containerRegistry.RegisterForNavigation<MarvelMoviesPage, MarvelMoviesPageViewModel>();
            containerRegistry.RegisterForNavigation<TappedMarvelPage, TappedMarvelPageViewModel>();



        }
    }
}
