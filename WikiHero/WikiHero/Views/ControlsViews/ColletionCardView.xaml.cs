using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WikiHero.Views.ControlsViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ColletionCardView : ContentView
    {
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
          nameof(ItemsSource),
          typeof(IList),
          typeof(ColletionCardView),
          propertyChanged: ColletionViewChanged);
        public IList ItemsSource
        {
            get => (IList)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }
        private static void ColletionViewChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is ColletionCardView control)) return;
            var items = (IList)newValue;
            control.publisherList.ItemsSource = items;
        }
            public ColletionCardView()
        {
            InitializeComponent();
        }
    }
}