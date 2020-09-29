using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AsyncLoadWebsiteWpf
{
    public class WebsiteModel : INotifyPropertyChanged
    {


        public string Url { get; set; } = "";

        public string Content { get; set; } = "";

        public int ContentLength { 
            get
            {
                return Content.Length;
            } 
        }

        public float LoadTime { get; set; } = 0.0f;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
