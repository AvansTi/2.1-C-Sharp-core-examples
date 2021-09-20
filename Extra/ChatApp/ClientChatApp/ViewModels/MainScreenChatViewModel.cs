
using Avans.TI.ChatApp.Client.Models;
using Avans.TI.ChatApp.Client.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans.TI.ChatApp.Client.ViewModels
{
    public class MainScreenChatViewModel : ObservableObject
    {


        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();

        private IMainScreenChatView mView;
        public MainScreenChatViewModel(IMainScreenChatView pView)
        {
            this.mView = pView;
            Users.Add(new User()
            {
                Username = "Jan",
                intId = 1,
            });
            Users.Add(new User()
            {
                Username = "Piet",
                intId = 2,
            });
            Users.Add(new User()
            {
                Username = "Klaas",
                intId = 3,
            });
        }
    }
}
