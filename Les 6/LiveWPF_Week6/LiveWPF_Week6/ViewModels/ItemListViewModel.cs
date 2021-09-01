using LiveWPF_Week6.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiveWPF_Week6.ViewModels
{
    public class ItemListViewModel : ObserverableObject
    {

        private MainViewModel MainViewModel { get; set; }

        public ItemListViewModel(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
        }

        public string ItemText { get; set; } = "ItemListView Data";
    }

}
