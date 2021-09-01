using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LiveWPF_Week6.Models
{
    public class ShoppingItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        [Key]
        public int ArtNumber { get; set; }

        public string Name { get; set; }

        public ItemCatogory ItemCatogory { get; set; }

        public string Description { get; set; }

        public string Manufactuer { get; set; }

        public string OrderNumber { get; set; }

        public float Price { get; set; }
    }
}
