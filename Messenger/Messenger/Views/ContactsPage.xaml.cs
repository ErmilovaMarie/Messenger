﻿using Messenger.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Messenger.Views
{
    public partial class ContactsPage : ContentPage
    {
        public ContactsViewModel _viewmodel;

        public ContactsPage()
        {
            InitializeComponent();
            _viewmodel = new ContactsViewModel(this);
            BindingContext = _viewmodel;
            listview.ItemsSource = _viewmodel.Contacts;
        }

        private async void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            await _viewmodel.OpenChat();
        }
    }
}
