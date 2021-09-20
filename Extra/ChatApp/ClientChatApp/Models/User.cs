using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Avans.TI.ChatApp.Client.Models
{
    public class User : ObservableObject
    {
        public uint intId { get; set; }


        public string Username { get; set; }

        public Image Image { get; set; }


        public override string ToString()
        {
            return $"{Username}";
        }
    }
}
