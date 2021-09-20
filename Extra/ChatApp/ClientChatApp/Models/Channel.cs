using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans.TI.ChatApp.Client.Models
{
    public class Channel : ObservableObject
    {
        public uint Id { get; set; }
        
        public string Name { get; set; }


        public override string ToString()
        {
            return Name;
        }
    }
}
