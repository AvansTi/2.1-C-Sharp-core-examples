using GalaSoft.MvvmLight.Command;
using LiveWPF_Week6.Models;
using LiveWPF_Week6.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace LiveWPF_Week6.ViewModels
{
    public class MainViewModel : ObserverableObject
    {

        public ObservableCollection<ShoppingItem> ShoppingCard { get; set; } = new ObservableCollection<ShoppingItem>();

        //public ShoppingCardContext shoppingCardContext { get; set; } = new ShoppingCardContext();

        public int ItemInShoppingCard {
            get { 
                return ShoppingCard.Count;
            } 
        }


        public ObserverableObject SelectedViewModel { get; set; }


        public ICommand ItemListViewCommand { get; set; }

        public ICommand ItemDetailViewCommand { get; set; }


        public ICommand DataBaseList { get; set; }


        private void TestDatabase()
        {
            using (var context = new ShoppingCardContext())
            {
                context.Database.EnsureCreated();

                var catCPU = new ItemCatogory { Code = "CPU" };
                context.ItemCatogories.Add(catCPU);

                context.ShoppingItem.Add(new ShoppingItem
                {
                    ItemCatogory = catCPU,
                    Name = "I7-9700k",
                    Description = "Fast CPU"
                });
                context.ShoppingItem.Add(new ShoppingItem
                {
                    ItemCatogory = catCPU,
                    Name = "I7-9900k",
                    Description = "Super Fast CPU"
                });

                context.SaveChanges();

            }
        }


        public MainViewModel()
        {
            //shoppingCardContext.Database.EnsureCreated();
            SelectedViewModel = new ItemListViewModel(this);
            ItemListViewCommand = new RelayCommand(() =>
            {
                SelectedViewModel = new ItemListViewModel(this);
            });

            ItemDetailViewCommand = new RelayCommand(() =>
            {
                SelectedViewModel = new ItemDetailViewModel(this);
            });
            DataBaseList = new RelayCommand(() =>
            {
                TestDatabase();
            });
        }
    }
}
