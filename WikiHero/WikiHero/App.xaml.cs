using Prism;
using Prism.Ioc;
using Prism.Unity;
using System;
using WikiHero.Helpers;
using WikiHero.Services;
using WikiHero.ViewModels;
using WikiHero.ViewModels.DCViewModels;
using WikiHero.ViewModels.MarvelViewModels;
using WikiHero.Views;
using WikiHero.Views.DcComicsViews;
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
            NavigationService.NavigateAsync(new Uri($"{ConfigPageUri.MarvelVsDcComicsPage}"));
            
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance<ApiComicsVine>(new ApiComicsVine());
            containerRegistry.RegisterForNavigation<MarvelVsDcComicsPage, MarvelVsDcComicsPageViewModel>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            //RegisterMarvel
            containerRegistry.RegisterForNavigation<MarvelCharactersPage, MarvelCharacterPageViewModel>();
            containerRegistry.RegisterForNavigation<MarvelComicsPage, MarvelComicsPageViewModel>();
            containerRegistry.RegisterForNavigation<MarvelHomePage, MarvelHomePageViewModel>();
            containerRegistry.RegisterForNavigation<MarvelSeriesPage, MarvelSeriesPageViewModel>();
            containerRegistry.RegisterForNavigation<TappedMarvelPage, TappedMarvelPageViewModel>();
            //RegisterDC
            containerRegistry.RegisterForNavigation<DcCharactersPage, DCCharactersPageViewModel>();
            containerRegistry.RegisterForNavigation<DcComicsPage, DcComicsPageViewModel>();
            containerRegistry.RegisterForNavigation<DcHomePage, DcHomePageViewModel>();
            containerRegistry.RegisterForNavigation<DcSeriesPage, DcSeriesPageViewModel>();
            containerRegistry.RegisterForNavigation<TappedDcComicsPage, TappedDcComicsPageViewModel>();




        }
    }
}
