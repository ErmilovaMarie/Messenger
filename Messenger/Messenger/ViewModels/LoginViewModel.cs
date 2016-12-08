using Messenger.Services;
using Messenger.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
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
        private async void OpenRegister() //доработать вход
        {
            await _page.Navigation.PushAsync(new RegisterPage());
        }
        private async void OpenContacts()
        {
            var dataService = DataService.GetInstance();
            var status = await dataService.LoginAsync(UserName, Password);
            if (status == HttpStatusCode.OK)
            {
                await _page.Navigation.PushAsync(new ContactsPage());
            }
            else
            {
                await _page.DisplayAlert("Ошибка", "Не удалось выполнить вход", "Закрыть");
            }
        }


    }
}
