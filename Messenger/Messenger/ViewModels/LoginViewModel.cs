using Messenger.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Messenger.ViewModels
{
    public class LoginViewModel : ContentView
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        private Page _page;

        public LoginViewModel (Page page)
        {
            _page = page;
            LoginCommand = new Command(OpenContacts);
            RegisterCommand = new Command(OpenRegister);
        }
        private async void OpenRegister()
        {
            await _page.Navigation.PushAsync(new RegisterPage());
        }
        private async void OpenContacts()
        {
            Debug.WriteLine($"UserName: {UserName}, Password: {Password}");
            await _page.Navigation.PushAsync(new ContactsPage());
        }


    }
}
