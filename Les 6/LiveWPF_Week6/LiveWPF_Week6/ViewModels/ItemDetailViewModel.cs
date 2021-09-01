using LiveWPF_Week6.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiveWPF_Week6.ViewModels
{
    public class ItemDetailViewModel : ObserverableObject
    {


        public MainViewModel MainViewModel { get; set; }


        public ItemDetailViewModel(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
        }


        public string ItemText { get; set; } = "ItemDetailViewModel Data";
    }
}
