using System;
using System.Collections.Generic;
using System.ComponentModel;
using Weather3.Models;
using Weather3.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weather3.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}