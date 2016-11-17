using Messenger.Models;
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
        public ObservableCollection<ContactModel> Contacts { get; set; } = new ObservableCollection<ContactModel>
        {
            new ContactModel
            {
                FullName = "Ермилова Мария",
                LastMessage = "Привет!",
                Image="http://333v.ru/uploads/5a/5a8134011451320715be38ebaffc9da7.jpg",
            },

        };
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
            await _page.Navigation.PopToRootAsync();
        }
        public async Task OpenChat ()
        {
            await _page.Navigation.PushAsync(new ChatPage());
        }
    }
}
