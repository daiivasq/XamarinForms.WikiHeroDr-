using Prism;
using Prism.Ioc;
using Prism.Unity;
using System;
using WikiHero.Helpers;
using WikiHero.Services;
using WikiHero.ViewModels;
using WikiHero.ViewModels.MarvelViewModels;
using WikiHero.Views;
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

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance<ApiComicsVine>(new ApiComicsVine());
        }
    }
}
