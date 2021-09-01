using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LiveWPF_Week6.Utils
{
    public class ObserverableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
