using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans.TI.ChatApp.Client.Models
{
    public class Message : ObservableObject
    {
        public uint Id { get; set; }

        public User Owner { get; set; }

        public ObservableCollection<User> Mentions { get; set; }

    }
}
