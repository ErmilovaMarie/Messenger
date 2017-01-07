using Messenger.Models;
using Messenger.Services;
using Messenger.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Messenger.ViewModels
{
    public class ContactsViewModel : ContentView
    {
        public ObservableCollection<ContactModel> Contacts { get; set; } = new ObservableCollection<ContactModel>();

        public async Task LoadContactsAsync()
        {
            var dataService = DataService.GetInstance();
            var contacts = await dataService.LoadContactsAsync();

            foreach (var contact in contacts)
            {
                contact.Image = "http://192.168.43.80:9000/" + contact.Image;
                Contacts.Add(contact);
            }
        }
        
        public ICommand ProfileCommand { get; set;}
        public ICommand ExitCommand { get; set; }

        private Page _page;

        public ContactsViewModel (Page page)
        {
            _page = page;
            ProfileCommand = new Command(OpenProfile);
            ExitCommand = new Command(OpenLogin);
        }

        private async void OpenProfile ()
        {
            await _page.Navigation.PushAsync(new ProfilePage());
        }
        private async void OpenLogin ()
        {
            var app = (App)Application.Current;
            app.MainPage = new NavigationPage(new LoginPage());

            var logout = DataService.GetInstance().LogoutAsync();
            await _page.Navigation.PopToRootAsync();
        }
        public async Task OpenChat ()
        {
            await _page.Navigation.PushAsync(new ChatPage());
        }
    }
}
