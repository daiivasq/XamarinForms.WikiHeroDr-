using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WikiHero.Views.ControlsViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CardCharacterView : ContentView
    {
        // inteligence
        public static readonly BindableProperty InteligentProperty = BindableProperty.Create(
            nameof(Inteligent),
            typeof(string),
            typeof(CardCharacterView),
            propertyChanged: InteligentPropertyChanged);
        public string Inteligent
        {
            get => (string)GetValue(InteligentProperty);
            set => SetValue(InteligentProperty, value);
        }
        private static void InteligentPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is CardCharacterView control)) return;
            var items = (string)newValue;
            control.LabelInteligent.Text = items;
        }
        public static readonly BindableProperty InteligenceImagesProperty = BindableProperty.Create(
            nameof(InteligenceImages),
            typeof(ImageSource),
            typeof(CardCharacterView),
            propertyChanged: InteligenceImagesPropertyChanged);
        public ImageSource InteligenceImages
        {
            get => (ImageSource)GetValue(InteligenceImagesProperty);
            set => SetValue(InteligenceImagesProperty, value);
        }
        private static void InteligenceImagesPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is CardCharacterView control)) return;
            var items = (ImageSource)newValue;
            control.ImageItelligence.Source = items;
        }
        // Power
        public static readonly BindableProperty PowerProperty = BindableProperty.Create(
            nameof(Power),
            typeof(string),
            typeof(CardCharacterView),
            propertyChanged: PowerPropertyChanged);
        public string Power
        {
            get => (string)GetValue(PowerProperty);
            set => SetValue(PowerProperty, value);
        }
        private static void PowerPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is CardCharacterView control)) return;
            var items = (string)newValue;
            control.LabelPower.Text = items;
        }
        public static readonly BindableProperty PowerImagesProperty = BindableProperty.Create(
            nameof(ImagePowers),
            typeof(ImageSource),
            typeof(CardCharacterView),
            propertyChanged: ImagePowerPropertyChanged);
        public ImageSource ImagePowers
        {
            get => (ImageSource)GetValue(PowerImagesProperty);
            set => SetValue(PowerImagesProperty, value);
        }
        private static void ImagePowerPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is CardCharacterView control)) return;
            var items = (ImageSource)newValue;
            control.ImagePower.Source = items;
        }
        // Strength
        public static readonly BindableProperty StrengthProperty = BindableProperty.Create(
            nameof(Inteligent),
            typeof(string),
            typeof(CardCharacterView),
            propertyChanged: StrengthPropertyChanged);
        public string Strength
        {
            get => (string)GetValue(StrengthProperty);
            set => SetValue(StrengthProperty, value);
        }
        private static void StrengthPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is CardCharacterView control)) return;
            var items = (string)newValue;
            control.LabelStrength.Text = items;
        }
        public static readonly BindableProperty StrengthImagesProperty = BindableProperty.Create(
            nameof(StrengthImages),
            typeof(ImageSource),
            typeof(CardCharacterView),
            propertyChanged: StrengthImagesPropertyPropertyChanged);
        public ImageSource StrengthImages
        {
            get => (ImageSource)GetValue(StrengthImagesProperty);
            set => SetValue(StrengthImagesProperty, value);
        }
        private static void StrengthImagesPropertyPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is CardCharacterView control)) return;
            var items = (ImageSource)newValue;
            control.ImageStrength.Source = items;
        }
        // Durability
        public static readonly BindableProperty DurabilityProperty = BindableProperty.Create(
            nameof(Durability),
            typeof(string),
            typeof(CardCharacterView),
            propertyChanged: DurabilityPropertyChanged);
        public string Durability
        {
            get => (string)GetValue(DurabilityProperty);
            set => SetValue(DurabilityProperty, value);
        }
        private static void DurabilityPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is CardCharacterView control)) return;
            var items = (string)newValue;
            control.LabelDurability.Text = items;
        }
        public static readonly BindableProperty DurabilityImagesProperty = BindableProperty.Create(
            nameof(DurabilityImages),
            typeof(ImageSource),
            typeof(CardCharacterView),
            propertyChanged: DurabilityImagesPropertyChanged);
        public ImageSource DurabilityImages
        {
            get => (ImageSource)GetValue(DurabilityImagesProperty);
            set => SetValue(DurabilityImagesProperty, value);
        }
        private static void DurabilityImagesPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is CardCharacterView control)) return;
            var items = (ImageSource)newValue;
            control.ImageDurability.Source = items;
        }
        // Speed
        public static readonly BindableProperty SpeedProperty = BindableProperty.Create(
            nameof(Speed),
            typeof(string),
            typeof(CardCharacterView),
            propertyChanged: SpeedPropertyChanged);
        public string Speed
        {
            get => (string)GetValue(SpeedProperty);
            set => SetValue(SpeedProperty, value);
        }
        private static void SpeedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is CardCharacterView control)) return;
            var items = (string)newValue;
            control.LabelSpeed.Text = items;
        }
        public static readonly BindableProperty SpeedImagesProperty = BindableProperty.Create(
            nameof(SpeedImages),
            typeof(ImageSource),
            typeof(CardCharacterView),
            propertyChanged: SpeedImagesPropertyPropertyChanged);
        public ImageSource SpeedImages
        {
            get => (ImageSource)GetValue(SpeedImagesProperty);
            set => SetValue(SpeedImagesProperty, value);
        }
        private static void SpeedImagesPropertyPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is CardCharacterView control)) return;
            var items = (ImageSource)newValue;
            control.ImageSpeed.Source = items;
        }
        // Combat
        public static readonly BindableProperty CombatProperty = BindableProperty.Create(
            nameof(Combat),
            typeof(string),
            typeof(CardCharacterView),
            propertyChanged: CombatPropertyChanged);
        public string Combat
        {
            get => (string)GetValue(CombatProperty);
            set => SetValue(CombatProperty, value);
        }
        private static void CombatPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is CardCharacterView control)) return;
            var items = (string)newValue;
            control.LabelCombat.Text = items;
        }
        public static readonly BindableProperty CombatImagesProperty = BindableProperty.Create(
            nameof(InteligenceImages),
            typeof(ImageSource),
            typeof(CardCharacterView),
            propertyChanged: CombatImagesPropertyChanged);
        public ImageSource CombatImages
        {
            get => (ImageSource)GetValue(CombatImagesProperty);
            set => SetValue(CombatImagesProperty, value);
        }
        private static void CombatImagesPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is CardCharacterView control)) return;
            var items = (ImageSource)newValue;
            control.ImageCombat.Source = items;
        }
        public static readonly BindableProperty CharacterImageProperty = BindableProperty.Create(
         nameof(CharacterImage),
         typeof(ImageSource),
         typeof(CardCharacterView),
         propertyChanged: CharacterImagePropertyChanged);
        public ImageSource CharacterImage
        {
            get => (ImageSource)GetValue(CharacterImageProperty);
            set => SetValue(CharacterImageProperty, value);
        }
        private static void CharacterImagePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is CardCharacterView control)) return;
            var items = (ImageSource)newValue;
            control.ImageCharacters.Source = items;
        }
            public static readonly BindableProperty AverageProperty = BindableProperty.Create(
            nameof(Average),
            typeof(string),
            typeof(CardCharacterView),
            propertyChanged: AveragePropertyChanged);
        public string Average
        {
            get => (string)GetValue(AverageProperty);
            set => SetValue(AverageProperty, value);
        }
        private static void AveragePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is CardCharacterView control)) return;
            var items = (string)newValue;
            control.LabelAverage.Text = items;
        }
        public CardCharacterView()
        {
            InitializeComponent();
        }
    }
}