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
    public class ChatViewModel : ContentView
    {
        public ObservableCollection<ChatModel> Chat { get; set; } = new ObservableCollection<ChatModel>
        {
            new ChatModel
            {
                Image ="https://pp.vk.me/c836720/v836720977/63ab/YwAqQd3shfE.jpg",
                FullName = "Звягина Дарья",
                Message = "Привет)",
            },
        };
    }
}
