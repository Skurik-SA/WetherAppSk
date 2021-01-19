using System.ComponentModel;
using Weather3.ViewModels;
using Xamarin.Forms;

namespace Weather3.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}