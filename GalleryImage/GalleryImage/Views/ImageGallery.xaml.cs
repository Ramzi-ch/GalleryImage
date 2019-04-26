using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GalleryImage.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ImageGallery : ContentPage
	{
        List<ImageModel> ListImage;
        List<ImageModel> ListCat = new List<ImageModel>();
        List<ImageModel> ListDog = new List<ImageModel>();

        public ImageGallery ()
		{
			InitializeComponent ();
            ListImage = new List<ImageModel>
            {
                new ImageModel {Image="cat1.jpg", Categorie="cat"},
                new ImageModel {Image="cat2.jpg", Categorie="cat"},
                new ImageModel {Image="dog1.jpg", Categorie="dog"},
                new ImageModel {Image="dog2.jpg", Categorie="dog"},
                new ImageModel {Image="cat1.jpg", Categorie="cat"},
                new ImageModel {Image="cat2.jpg", Categorie="cat"},
                new ImageModel {Image="dog1.jpg", Categorie="dog"},
                new ImageModel {Image="dog2.jpg", Categorie="dog"}
            };            
            List1.ItemsSource = ListImage;
            BindingContext = this;
        }

        #region for the converter
        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName]string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
        bool stateBox1 = false;
        public bool StateBox1
        {
            get { return stateBox1; }
            set { SetProperty(ref stateBox1, value); }
        }
        bool stateBox2 = false;
        public bool StateBox2
        {
            get { return stateBox2; }
            set { SetProperty(ref stateBox2, value); }
        }
        #endregion

        private void BtnCheckCat_Clicked(object sender, EventArgs e)
        {            
            if (StateBox1 == true)
            {
                StateBox1 = false;
                List1.ItemsSource = ListImage;
            }
            else
            {                
                StateBox1 = true;
                foreach (ImageModel i in ListImage)
                {
                    if (i.Categorie.Equals("cat"))
                    {
                        ListCat.Add(i);
                    }
                }
                List1.ItemsSource = ListCat;
            }
        }

        private void BtnCheckDog_Clicked(object sender, EventArgs e)
        {
            if (StateBox2 == true)
            {
                StateBox2 = false;
                List1.ItemsSource = ListImage;
            }
            else 
            {
                StateBox2 = true;
                foreach (ImageModel i in ListImage)
                {
                    if (i.Categorie.Equals("dog"))
                    {
                        ListDog.Add(i);
                    }
                }
                List1.ItemsSource = ListDog;
            }
        }
        
    }
}