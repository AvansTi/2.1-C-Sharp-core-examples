using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MemeGenerator.Models
{
    public class MemeModel : INotifyPropertyChanged
    {
        private string imageFilePath;
        private string topText;
        private string bottomText;


        public string ImageFilePath
        {
            get { return imageFilePath; }
            set
            {
                if (value != imageFilePath)
                {
                    imageFilePath = value;
                    OnPropertyChanged();
                }
            }
        }

        public string TopText
        {
            get { return topText; }
            set
            {
                if (topText != value)
                {
                    topText = value;
                    OnPropertyChanged();
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;



        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
