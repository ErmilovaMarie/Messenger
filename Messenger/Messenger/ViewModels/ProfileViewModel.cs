using Messenger.Models;
using Messenger.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Messenger.ViewModels
{
    public class ProfileViewModel : ContentView
    {
        public string FullName { get; set; }
        public string Image { get; set; }

        public ICommand PhotoCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public ObservableCollection<ProfileModal> Profile = new ObservableCollection<ProfileModal>
        {
            new ProfileModal
            {
               Image = "https://pp.vk.me/c626419/v626419904/3b7c/HLU1EcNpWPY.jpg"
            },
        };

        private Page _page;

        public ProfileViewModel (Page page)
        {
            _page = page;
            SaveCommand = new Command(OpenContacts);
        }
        private async void OpenContacts()
        {
            Debug.WriteLine($"FullName: {FullName}, Image: {Image}");
            await _page.Navigation.PushAsync(new ContactsPage());
        }
    }
}
