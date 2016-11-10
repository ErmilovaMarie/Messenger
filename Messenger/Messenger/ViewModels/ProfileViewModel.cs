using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Messenger.ViewModels
{
    public class ProfileViewModel : ContentView
    {
        public ProfileViewModel()
        {
            Content = new Label { Text = "Hello View" };
        }
    }
}
