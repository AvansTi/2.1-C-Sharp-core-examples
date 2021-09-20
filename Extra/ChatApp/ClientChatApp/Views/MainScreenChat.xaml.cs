using Avans.TI.ChatApp.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Avans.TI.ChatApp.Client.Views
{
    /// <summary>
    /// Interaction logic for MainScreenChat.xaml
    /// </summary>
    public partial class MainScreenChat : Window, IMainScreenChatView
    {


        private MainScreenChatViewModel viewModel;
        public MainScreenChat()
        {
            InitializeComponent();
            viewModel = new MainScreenChatViewModel(this);
            this.DataContext = viewModel;

        }
    }
}
