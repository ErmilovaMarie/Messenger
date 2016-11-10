using Messenger.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text; 
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
    }
}
