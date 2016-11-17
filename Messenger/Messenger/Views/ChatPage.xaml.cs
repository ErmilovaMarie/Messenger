using Messenger.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Messenger.Views
{
    public partial class ChatPage : ContentPage
    {
        public ChatPage()
        {
            InitializeComponent();
            BindingContext = new ChatViewModel();
        }
    }
}
